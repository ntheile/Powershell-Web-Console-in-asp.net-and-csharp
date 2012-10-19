Powershell-Web-Console-in-asp.net-and-csharp
============================================

This project allows you to create a powershell console on a webpage and invoke commands to a specified server. 
It uses IIS app pool identity on the server to run the code and windows authenication to get to the web console. 
This project largly uses the `System.Management.Automation namespace`.

To get powershell to work with an asp.net web page you must enable the following on the 
destination server that you are trying to run the command:

1. Open Powershell
2. Run this > Enable-PSRemoting –force
3. Add you remote computer to the trusted list >  winrm s winrm/config/client '@{TrustedHosts="compName"}'
4. *note for windows server 2008 you just need to enable powershell remoting http://searchsystemschannel.techtarget.com/feature/PowerShell-remoting-in-Windows-Server-2008-R2

**You must have admin access on the remote server you are trying to execute the script on.**


