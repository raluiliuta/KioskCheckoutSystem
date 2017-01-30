#Kiosk Checkout System

##Running the application

The application accepts basket file from commmand line or from the location configured in App.config.
It prioritizes the command line given path, if it exists.

If any of the required resources: regular prices list, promotion list or basket are missing, the console application will display an "OutOfOrder" error message.
It accepts a file that has no promotions defined.


##Supported functionality

##Assumptions
*
*
*

##Application Flow


##Libraries used

##Implementation observations
* All the items from the basket are identified by name for human redability. In a real scenario GUID should be used.
* Move all strings and fixed values to a configuration file.
