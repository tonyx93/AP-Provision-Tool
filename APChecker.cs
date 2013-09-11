using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Timers;
using System.Diagnostics;
using System.Net;
using System.Web;


namespace WindowsFormsApplication1
{
    public partial class AP_Provision_Form : Form
    {
        // Global Variables
        public string mac = "", apname = "", group = "", username = "", password = "", line = "";
        public bool havemac = false, haveapname = false, havegroup= false,
            haveuser = false, havepass = false, havevars = false, havefile = false, haveport = false;
        public int portnum = 1;
        Stopwatch sw = new Stopwatch(); // Initialize stopwatch timer
        SerialPort sp = new SerialPort("COM1", 9600); // Initialize Serial port communications
                        
        public AP_Provision_Form()
        {
            InitializeComponent();
        }

        // To do: Clean up
        // Redesign using threads (Mayyyybe)
        // Optimize Code

        private void InitializeVars() // Function to reinitialize Global Vars
        {
            mac = ""; apname = ""; group = "";
            havemac = false; haveapname = false;
            havegroup = false; havevars = false;
        }
                
        private void CheckVars() // Checks variable acquisition
        {
            if (username == "")
            {
                MessageBox.Show("No username entered");
                haveuser = false;
            }
            else if (password == "")
            {
                MessageBox.Show("No password entered");
                havepass = false;
            }
            else if (mac == "")
            {
                MessageBox.Show("No MAC acquired");
                havemac = false;
            }
            else if (apname == "")
            {
                MessageBox.Show("No AP name acquired");
                haveapname = false;
            }
            else
            {
                havevars = true;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e) // Click on status bar pops up messagebox in case message is too long
        {
            MessageBox.Show(toolStripStatusLabel1.Text);
        }

        private void provision_Click(object sender, EventArgs e) // Function to perform when Configure button is pressed
        {
            // Variables
            consolebox.Clear();
            if (configure_AP() == 0 && !configureCheck.Checked)
            {
                addToDatabase();
            }
        }

        private int configure_AP()
        {
            if (!haveapname)
            {
                MessageBox.Show("No name entered!");
                toolStripStatusLabel1.Text = "Please Enter an AP Name";
                return 1;
            }

            while (!sp.IsOpen)
            {
                if (haveport)   // Stored port from previous iterations
                {
                    sp = new SerialPort("COM" + portnum, 9600);
                    sp.ReadTimeout = 5000;
                    sp.WriteTimeout = 2000;
                    try
                    {
                        sp.Open();
                    }
                    catch (IOException ioe)
                    {
                        MessageBox.Show("COM" + portnum + " failed, retrying ports");
                        haveport = false; portnum = 0;
                        break;
                    }
                    sendSigInt();
                }
                else
                {
                    String com = "COM" + portnum;
                    sp = new SerialPort(com, 9600);
                    sp.ReadTimeout = 5000;
                    sp.WriteTimeout = 2000;
                    toolStripStatusLabel1.Text = "Waiting on connection...";
                    try // accessing serial port
                    {
                        sp.Open();
                    }
                    catch (UnauthorizedAccessException uae)
                    {
                        MessageBox.Show("COM" + portnum + " failed, trying next port");
                    }
                    catch (IOException ioe)
                    {
                        MessageBox.Show("COM" + portnum + " failed, trying next port");
                    }

                    if (sp.IsOpen)     // Check if port opened successfully
                    {
                        sendSigInt();
                        if (!sp.IsOpen)
                        {
                            MessageBox.Show("COM" + portnum + " failed, trying next port");
                        }
                        else
                        {
                            haveport = true;
                            break;
                        }
                    }

                    if (portnum > 5)    // if past COM5 give up
                    {
                        MessageBox.Show("Could not access AP, please ensure AP is connected and try again");
                        toolStripStatusLabel1.Text = "Please ensure AP is connected and try again";
                        portnum = 0;
                        return 1;
                    }
                    portnum++;
                }
            }

            // Error checking vars
            int iteration = 0;
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            while (!apname.Contains(AP_Name.Text) || !group.Contains(apgroup.Text) || iteration < 1)
            {
                toolStripStatusLabel1.Text = "Configuring AP...";

                // Purge AP
                WriteErrorCheck("purgeenv", consolebox);
                wait_OutToConsole(2500, consolebox);

                // Configure AP
                WriteErrorCheck("setenv name " + AP_Name.Text + ";setenv group " + apgroup.Text + ";save", consolebox);
                wait_OutToConsole(2500, consolebox);

                // Printeenv
                WriteErrorCheck("printenv", consolebox);

                InitializeVars();

                while (apname == "" || group == "" || mac == "" && sw2.ElapsedMilliseconds < 30000) // retrieves information from printenv
                {
                    if (line.StartsWith("name="))
                    {
                        apname = line.Substring(5);
                        haveapname = true;
                    }
                    else if (line.StartsWith("group="))
                    {
                        group = line.Substring(6);
                        havegroup = true;
                    }
                    else if (line.StartsWith("ethaddr="))
                    {
                        mac = line.Substring(8);
                        havemac = true;
                    }
                    try
                    {
                        line = sp.ReadLine();
                        consolebox.Text += line + "\n";
                    }
                    catch (TimeoutException te)
                    {
                        break;
                    }
                }
                iteration++;
            }
            sw2.Reset();

            sp.Close(); // Close serial port

            if (haveapname == true)
            {
                MessageBox.Show("AP configured!\nname=" + apname + "\ngroup=" + group);
                toolStripStatusLabel1.Text = "Done configuring!";
            }


            if (havefile == true && (apnames.SelectedItem.ToString() == AP_Name.Text || AP_Name.Text == ""))
            {
                try // advance listbox selection by 1
                {
                    apnames.SelectedIndex += 1;
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    apnames.SelectedIndex = 0; // reset list to top
                }
            }
            return 0;
        }

        private void addToDatabase()
        {
            toolStripStatusLabel1.Text = "Adding to database";            // Add to Database via Website php
            CheckVars(); // checks if all variables acquired
            if (havevars == true)
            {
                try // To add to server database
                {
                    toolStripStatusLabel1.Text = "Authenticating";
                    // Open web request
                    HttpWebRequest webreq =
                        (HttpWebRequest)WebRequest.Create("https://netcenter.studentaffairs.ohio-state.edu/approvisioner/provisioner.php");

                    // encodes data as byte
                    ASCIIEncoding dataenc = new ASCIIEncoding();
                    password = Uri.EscapeDataString(password);
                    username = Uri.EscapeDataString(username);
                    apname = Uri.EscapeDataString(apname);
                    string postData = "user=" + username + "&pass=" + password + "&mac=" + mac + "&name=" + apname;
                    byte[] data = dataenc.GetBytes(postData);

                    // Sets web request variables
                    webreq.Method = "POST";
                    webreq.ContentType = "application/x-www-form-urlencoded";
                    webreq.ContentLength = data.Length;

                    // open stream from web request server
                    Stream dataStream = webreq.GetRequestStream();
                    dataStream.Write(data, 0, data.Length);
                    dataStream.Close();

                    // reads response
                    WebResponse response = webreq.GetResponse();
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    MessageBox.Show(responseFromServer);
                    toolStripStatusLabel1.Text = responseFromServer;

                    //Close streams
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                }
                catch (WebException we) // Show error message
                {
                    MessageBox.Show(we.Message + "\nPlease check if mac is a duplicate");
                    toolStripStatusLabel1.Text = we.Message;
                }
            }
        }

        private void csource_Click(object sender, EventArgs e) // function for Browse button
        {
            // opens file browser dialog
            apnames.Items.Clear();
            fchoice.ShowDialog();
        }


        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e) // reads in file from file browser
        {
            try
            {
                StreamReader stream = new StreamReader(fchoice.OpenFile());
                while (!stream.EndOfStream) // add apnames to list
                {
                    string apitem = stream.ReadLine();
                    apnames.Items.Add(apitem);
                }
                apnames.SelectedIndex++; // set selected item to first one in the list
                AP_Name.Text = apnames.SelectedItem.ToString();
                toolStripStatusLabel1.Text = "Ready";
                havefile = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("File open error: " + ex.Message);
                toolStripStatusLabel1.Text = "File open error: " + ex.Message;
                havefile = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            apname = AP_Name.Text;
            if (AP_Name.Text != "")
            {
                haveapname = true;
            }
            else
            {
                haveapname = false;
            }
        }

        private void apnames_SelectedIndexChanged(object sender, EventArgs e)
        {
            apname = apnames.SelectedItem.ToString();
            if (havefile == true)
            {
                AP_Name.Text = apnames.SelectedItem.ToString();
                haveapname = true;
            }
        }

        private void apgroup_TextChanged(object sender, EventArgs e)
        {
            group = apgroup.Text;
        }

        private void WriteErrorCheck(string cmd, RichTextBox textbox)
        {
            while (true)
            {
                try
                {
                    sp.WriteLine(cmd);
                    line = sp.ReadLine();
                    textbox.Text += line + "\n";
                    if (line.Contains(cmd))
                    {
                        break;
                    }
                }
                catch (TimeoutException te)
                {
                    continue;
                }
            }
        }

        private void wait_OutToConsole(int ms, RichTextBox textbox)
        {
            sw.Reset();
            sw.Start();
            while (sw.ElapsedMilliseconds < ms)
            {
                try
                {

                    line = sp.ReadLine();
                    textbox.Text += line + "\n";
                }
                catch (TimeoutException te)
                {
                    break;
                }
            }
            sw.Reset();
        }

        private void sendSigInt()
        {
            byte[] sigint = new byte[1]; // interrupt signal byte
            sigint[0] = 0x03;

            try // send sigint until command line
            {
                while (true)
                {
                    sp.Write(sigint, 0, 1);
                    if (line.Contains("apboot") || line.Contains("INTERRUPT"))
                    {
                        break;
                    }
                    line = sp.ReadLine();
                }
                sp.WriteLine("\r\n");
            }
            catch (TimeoutException te) // catches end of stream timeout exception from ReadLine()
            {
                //MessageBox.Show("Could not access AP, please ensure AP is connected and try again");
                //toolStripStatusLabel1.Text = "Please ensure AP is connected and try again";
                haveport = false;
                sp.Close();
            }
        }

        private void consolebox_TextChanged(object sender, EventArgs e) // scroll consolebox to bottom
        {
            consolebox.SelectionStart = consolebox.Text.Length;
            consolebox.ScrollToCaret();
        }

        private void userbox_TextChanged(object sender, EventArgs e)    // acquire username
        {
            username = userbox.Text;
            if (username != "")
            {
                haveuser = true;
            }
            else
            {
                haveuser = false;
            }
        }

        private void passbox_TextChanged(object sender, EventArgs e)    // acquire password
        {
            password = passbox.Text;
            if (password != "")
            {
                havepass = true;
            }
            else
            {
                havepass = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, "readme.txt");
                Process.Start(path);
            }
            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show("Readme.txt could not be found! Please reinstall to recover readme file");
            }
        }

    }
}
