base:
  'roles:IISStaging':
    - match: grain
    - IISStaging/IISStaging # IISStaging/IISStaging.sls
  'roles:NginxStaging':
    - match: grain
    - NginxStaging/NginxStaging # NginxStaging/NginxStaging.sls
  'roles:PowerShellExample':
    - match: grain
    - PowerShellExample/PowerShellExample # PowerShellExample/PowerShellExample.sls

