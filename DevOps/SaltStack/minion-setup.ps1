
$url = Read-Host 'What is the url of your SaltStack master?'
(New-Object System.Net.WebClient).DownloadFile('https://repo.saltstack.com/windows/Salt-Minion-2015.8.7-x86-Setup.exe', "$PSScriptRoot\Salt-Minion-2015.8.7-x86-Setup.exe")
$rand = Get-Random
start-process -FilePath "$PSScriptRoot\Salt-Minion-2015.8.7-x86-Setup.exe" -ArgumentList "/S /master=$($url) /minion-name=$($env:ComputerName)$($rand)" -Wait
Remove-Item "$PSScriptRoot\Salt-Minion-2015.8.7-x86-Setup.exe"
net stop salt-minion
"grains:" | Add-Content "c:\salt\conf\minion"
"  roles:" | Add-Content "c:\salt\conf\minion"
"    - IISStaging" | Add-Content "c:\salt\conf\minion"
"    - PowerShellExample" | Add-Content "c:\salt\conf\minion"
net start salt-minion
