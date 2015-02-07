
REM Run this script on the windows vm that will be controlled by ansible.
REM The script will enable everything that is needed to let ansible connect and control the machine.
REM See http://docs.ansible.com/intro_windows.html#windows-system-prep

REM Install chocolatey
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
cinst dotnet4.5
cinst powershell

REM Ansible specific config
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/ansible/ansible/devel/examples/scripts/ConfigureRemotingForAnsible.ps1'))"

REM Vagrant specific config
winrm quickconfig -q
winrm set winrm/config/winrs @{MaxMemoryPerShellMB="512"}
winrm set winrm/config @{MaxTimeoutms="1800000"}
winrm set winrm/config/service @{AllowUnencrypted="true"}
winrm set winrm/config/service/auth @{Basic="true"}
sc config WinRM start= auto

netsh firewall add portopening TCP 5985 "Port 5985"
winrm set winrm/config/listener?Address=*+Transport=HTTP @{Port="5985"}
netsh advfirewall firewall add rule profile=any name="Allow WinRM HTTPS" dir=in localport=5985 protocol=TCP action=allow

REM Add vagrant user

NET USER vagrant "vagrant" /ADD
NET LOCALGROUP "Administrators" "vagrant" /add
