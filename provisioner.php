<?
/*
	Create Author:  Lucas Damicone
	Create Date: 12/21/2012

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

	if (! isset($_POST["mac"]) || ! isset($_POST["name"]) )
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
			
			$hexmac = str_replace(':','',$_POST["mac"]);
			
			$mac = hexdec($hexmac);
			
			$name = $_POST["name"];
			
            //$params = array ($mac, $hexmac, $name, $userID);
	        //$rs_insert_vlan_map_ap = sqlsrv_query ($dbconn, "Exec insert_vlan_map_ap ?, ?, ?, ?", $params);
	
	        //if ($rs_insert_vlan_map_ap === false)
   	            //print("Error: $name insert has failed. Please contact an administrator for assistance.\n");
				//) //format_sql_errors(sqlsrv_errors()));			
			//else	
				//printf("VLAN Management has been updated");				
				
			//sqlsrv_free_stmt($rs_insert_vlan_map_ap);
		}
		else
    		print("You do not have access to the NetCenter, if you believe this is an error, please contact the site administrator."); 

	    // housekeeping
    	sqlsrv_free_stmt($sp_verify_username);
    	ldap_unbind($ldap_conn);	 
  	}
	else
	  print("You did not authenticate properly, please try again.");

	
include("../library/dbfooter.inc");
?>