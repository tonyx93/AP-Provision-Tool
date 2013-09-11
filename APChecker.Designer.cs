namespace WindowsFormsApplication1
{
    partial class AP_Provision_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fchoice = new System.Windows.Forms.OpenFileDialog();
            this.Configurator = new System.Windows.Forms.TabPage();
            this.configureCheck = new System.Windows.Forms.CheckBox();
            this.passbox = new System.Windows.Forms.TextBox();
            this.userbox = new System.Windows.Forms.TextBox();
            this.consolebox = new System.Windows.Forms.RichTextBox();
            this.AP_Name = new System.Windows.Forms.TextBox();
            this.apgroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.conslabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.apnames = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.provision = new System.Windows.Forms.Button();
            this.csource = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.Configurator.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 330);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(554, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(539, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // fchoice
            // 
            this.fchoice.DefaultExt = "txt";
            this.fchoice.FileName = "aplist";
            this.fchoice.Filter = "Text files|*.txt|All files|*.*";
            this.fchoice.RestoreDirectory = true;
            this.fchoice.Title = "Browse File";
            this.fchoice.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk_1);
            // 
            // Configurator
            // 
            this.Configurator.BackColor = System.Drawing.Color.Transparent;
            this.Configurator.Controls.Add(this.configureCheck);
            this.Configurator.Controls.Add(this.passbox);
            this.Configurator.Controls.Add(this.userbox);
            this.Configurator.Controls.Add(this.consolebox);
            this.Configurator.Controls.Add(this.AP_Name);
            this.Configurator.Controls.Add(this.apgroup);
            this.Configurator.Controls.Add(this.label8);
            this.Configurator.Controls.Add(this.label9);
            this.Configurator.Controls.Add(this.conslabel);
            this.Configurator.Controls.Add(this.label6);
            this.Configurator.Controls.Add(this.apnames);
            this.Configurator.Controls.Add(this.label5);
            this.Configurator.Controls.Add(this.label4);
            this.Configurator.Controls.Add(this.provision);
            this.Configurator.Controls.Add(this.csource);
            this.Configurator.Location = new System.Drawing.Point(4, 22);
            this.Configurator.Name = "Configurator";
            this.Configurator.Padding = new System.Windows.Forms.Padding(3);
            this.Configurator.Size = new System.Drawing.Size(546, 280);
            this.Configurator.TabIndex = 0;
            this.Configurator.Text = "Configure";
            // 
            // configureCheck
            // 
            this.configureCheck.AutoSize = true;
            this.configureCheck.Location = new System.Drawing.Point(197, 216);
            this.configureCheck.Name = "configureCheck";
            this.configureCheck.Size = new System.Drawing.Size(93, 17);
            this.configureCheck.TabIndex = 24;
            this.configureCheck.Text = "Configure only";
            this.configureCheck.UseVisualStyleBackColor = true;
            // 
            // passbox
            // 
            this.passbox.Location = new System.Drawing.Point(190, 190);
            this.passbox.Name = "passbox";
            this.passbox.PasswordChar = '*';
            this.passbox.Size = new System.Drawing.Size(100, 20);
            this.passbox.TabIndex = 23;
            this.passbox.TextChanged += new System.EventHandler(this.passbox_TextChanged);
            // 
            // userbox
            // 
            this.userbox.Location = new System.Drawing.Point(190, 144);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(100, 20);
            this.userbox.TabIndex = 22;
            this.userbox.TextChanged += new System.EventHandler(this.userbox_TextChanged);
            // 
            // consolebox
            // 
            this.consolebox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consolebox.Location = new System.Drawing.Point(308, 30);
            this.consolebox.Name = "consolebox";
            this.consolebox.ReadOnly = true;
            this.consolebox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.consolebox.Size = new System.Drawing.Size(233, 224);
            this.consolebox.TabIndex = 19;
            this.consolebox.TabStop = false;
            this.consolebox.Text = "";
            this.consolebox.TextChanged += new System.EventHandler(this.consolebox_TextChanged);
            // 
            // AP_Name
            // 
            this.AP_Name.Location = new System.Drawing.Point(190, 76);
            this.AP_Name.Name = "AP_Name";
            this.AP_Name.Size = new System.Drawing.Size(100, 20);
            this.AP_Name.TabIndex = 3;
            this.AP_Name.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // apgroup
            // 
            this.apgroup.Location = new System.Drawing.Point(190, 30);
            this.apgroup.Name = "apgroup";
            this.apgroup.Size = new System.Drawing.Size(100, 20);
            this.apgroup.TabIndex = 2;
            this.apgroup.TextChanged += new System.EventHandler(this.apgroup_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Username";
            // 
            // conslabel
            // 
            this.conslabel.AutoSize = true;
            this.conslabel.Location = new System.Drawing.Point(305, 14);
            this.conslabel.Name = "conslabel";
            this.conslabel.Size = new System.Drawing.Size(45, 13);
            this.conslabel.TabIndex = 18;
            this.conslabel.Text = "Console";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "AP Name";
            // 
            // apnames
            // 
            this.apnames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.apnames.FormattingEnabled = true;
            this.apnames.Location = new System.Drawing.Point(11, 30);
            this.apnames.Name = "apnames";
            this.apnames.Size = new System.Drawing.Size(145, 199);
            this.apnames.TabIndex = 4;
            this.apnames.SelectedIndexChanged += new System.EventHandler(this.apnames_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "AP List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "AP Group";
            // 
            // provision
            // 
            this.provision.Location = new System.Drawing.Point(215, 239);
            this.provision.Name = "provision";
            this.provision.Size = new System.Drawing.Size(75, 23);
            this.provision.TabIndex = 5;
            this.provision.Text = "Provision";
            this.provision.UseVisualStyleBackColor = true;
            this.provision.Click += new System.EventHandler(this.provision_Click);
            // 
            // csource
            // 
            this.csource.Location = new System.Drawing.Point(215, 102);
            this.csource.Name = "csource";
            this.csource.Size = new System.Drawing.Size(75, 23);
            this.csource.TabIndex = 1;
            this.csource.Text = "Browse";
            this.csource.UseVisualStyleBackColor = true;
            this.csource.Click += new System.EventHandler(this.csource_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Configurator);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 306);
            this.tabControl1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.instructionsToolStripMenuItem.Text = "Instructions";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.instructionsToolStripMenuItem_Click);
            // 
            // AP_Provision_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 352);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 390);
            this.Name = "AP_Provision_Form";
            this.Text = "AP Provision Tool";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Configurator.ResumeLayout(false);
            this.Configurator.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.OpenFileDialog fchoice;
        private System.Windows.Forms.TabPage Configurator;
        private System.Windows.Forms.TextBox passbox;
        private System.Windows.Forms.TextBox userbox;
        private System.Windows.Forms.RichTextBox consolebox;
        private System.Windows.Forms.TextBox AP_Name;
        private System.Windows.Forms.TextBox apgroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label conslabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox apnames;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button provision;
        private System.Windows.Forms.Button csource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox configureCheck;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;

    }
}

