Powershell1:
  cmd.run:
    - shell: powershell
    - name: 'Write-Host "Running this powershell example 1 command"'
Powershell2:
  cmd.run:
    - shell: powershell
    - name: 'Write-Host "Running this powershell example 2 command"'
chocolatey:
  module.run:
    - name: chocolatey.bootstrap
firefox:
  module.run:
    - name: chocolatey.install 
    - m_name: firefox
    - require:
      - module: chocolatey
