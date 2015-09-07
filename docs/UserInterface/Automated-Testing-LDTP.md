write me

# Linux - Basic Setup

# Windows - Basic Setup

Download from http://cobra.codeplex.com/ and install
Example code https://github.com/ldtp/cobra/tree/master/Example/VB.NET/TestLdtpClient_by_VB

Add as reference to project C:\Program Files (x86)\VMware\CobraWinLDTP\Ldtp.dll

By default LDTP listens in localhost, to listen in all ports, set environment variable LDTP_LISTEN_ALL_INTERFACE and then run WinLdtpdService.exe as an user with administrator privileges in Windows 7, else you will get exception Access Denied. 


**Other option** is:
Disable ACL in Control Panel->User Accounts->Change User Account Control settings Other option (Still you need to set LDTP_LISTEN_ALL_INTERFACE), you need to run as administrator:
set LDTP_LISTEN_ALL_INTERFACE=1 # To listen on all interface
Required for Windows >= 7

netsh http add urlacl url=http://localhost:4118/ user=User
netsh http add urlacl url=http://+:4118/ user=User
netsh http add urlacl url=http://*:4118/ user=User