choc:
  module.run:
    - name: chocolatey.bootstrap
.NET:
  pkg.installed
npp:
  pkg.installed
ISWebserverRole:
  win_servermanager.installed:
    - force: True
    - recurse: True
    - name: Web-Server