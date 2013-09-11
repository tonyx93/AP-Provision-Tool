<?
/*
	Create Author:  Lucas Damicone
	Create Date: 4/24/2009

# TODO: Definitely, definitely, sanitize inputs, many ways. Stuff!
# TODO: Along with the rest of the netcenter, handle multiple line cards better. !!
	
	Change Log: 
*/
include("../library/dbheader.inc");

# We really don't want the client to cache, and we really don't
# want to recompile the client....
//header("Cache-control: no-cache, must-revalidate");
//header("Pragma: no-cache");
//header("Expires: Mon, 26 Jul 1997 05:00:00 GMT");

if (isset($_POST["update"]))
{
	if ($_POST["update"] == "version") {
    	print "2.0.3";
        exit;
	}
}
else   // we're mapping
{
	if (! isset($_POST["roomnumber"]) || ! isset($_POST["jack"]) || ! isset($_POST["deviceid"]) || ! isset($_POST["portid"]))
	{
		print("Error: All required data was not passed to the server.  Please contact an administrator for assistance.\n");
		exit;
	}
	
	// allow for backup domain controllers	
	$ldap_host = "adc01 adc02 adc03 adc04";
	
	// builds the qualified domain
	$ldap_user = $_POST["user"] . "@studentaffairs";
	$ldap_pass = $_POST["pass"];
	
	$ldap_conn = ldap_connect($ldap_host) or ($error = "The Authentication Server is unavailable, Please Contact the Server Administrator.");
	//print("if $connect == \"Resource id #1\"  then successConnect Result is " . $connect . "<br />");
	
	ldap_set_option($ldap_conn, LDAP_OPT_PROTOCOL_VERSION, 3);
	
	if (($ldap_pass != "") && ($ldap_bind = ldap_bind($ldap_conn, $ldap_user, $ldap_pass))) {


        $params = array ($_POST["user"]);
	    $rs_verify_username = sqlsrv_query ($dbconn, "Exec verify_username ?", $params);
	
	    if ($rs_verify_username === false)
		 die (format_sql_errors(sqlsrv_errors()));

		if ($row_verify_username = sqlsrv_fetch_array($rs_verify_username)) {
			$userID = $row_verify_username["userID"];
			
			$port = preg_replace("/.+-/","",$_POST["portid"]);
			
			if ((substr($_POST["portid"], 0, 1) == "G") || (substr($_POST["portid"], 0, 1) == "g"))
				$gigabit = 1;
			else
				$gigabit = 0;
				
			$room = $_POST["roomnumber"];
			$jack = $_POST["jack"];
			$switchNameparts = explode(".", $_POST["deviceid"]);
			$switchName = $switchNameparts[0];
			$portidparts = explode(".", $port);
			$port = $portidparts[0];
			
            $params = array ($userID, $room, $jack, $switchName, $port, $gigabit);
	        $rs_portmap_switchport = sqlsrv_query ($dbconn, "Exec portmap_switchport ?, ?, ?, ?, ?, ?", $params);
	
	        if ($rs_portmap_switchport === false)
   	            print("Error: $switchName $gigabit $port Database update has failed. Please contact an administrator for assistance.\n");
				//) //format_sql_errors(sqlsrv_errors()));			
			else	
				printf("The jack is connected to %s %s0/%s", $switchName, $gigabit ? "Gi" : "Fa" , $port);				
				
			sqlsrv_free_stmt($rs_portmap_switchport);
		}
		else
    		print("You do not have access to the NetCenter, if you believe this is an error, please contact the site administrator."); 

	    // housekeeping
    	sqlsrv_free_stmt($sp_verify_username);
    	ldap_unbind($ldap_conn);	 
  	}
	else
	  print("You did not authenticate properly, please try again.");
}	
	
include("../library/dbfooter.inc");
?>