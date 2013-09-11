AP Provision Tool Readme

Authors: Mei (Mike) Liu and Tony Xu

Purpose:
All-in-one application to configure and check APs

Functionality:

- Accepts a list of AP names in a *.txt file
- Manually enter group
- May manually enter name or select from list
- Configures AP with provided information in text box fields
- Checks AP and returns information in info box
- Adds to database on click
- Console display for monitoring progress

To do:

- Figure out how to properly configure pre-configured APs
- Add button to purge AP
- Add multi-threading support (maybe)
...

Note: This program may not work for APs that have already been configured as
they do not display the same command prompt as a blank AP when sent the
interrupt signal.

Release Notes:

Version 2.0.0.00
- Changed functionality
	- One click configure and add to database
	- Check box for configure only
- Added support for Keyspanner
	- Works by iterating through COM1 - COM6
		- May still break if COM is greater than 6
- Added menu bar
	- File->Close
	- Help->Instructions (opens this file)

Version 1.0.0.11
- Cleaned up code
- Added error checking
	- Code will now check for missing characters during configuration
	  and attempt to fix them
- Added console box for easier trouble shooting
- Cleaned up GUI
- Cleaned up exception handling

Version 1.0.0.9
- Initial Release