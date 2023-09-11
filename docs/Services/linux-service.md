---
layout: base
title: linux service, using snap, systemd
---

Both examples create a service from a c# mono application.


# Systemd service

Create a service using systemd.

```service
[Unit]
Description=The description of your service
# How to install:
# Copy YourProgramName binary to /opt/your-program-service-name/YourProgramName.exe
# Copy /etc/systemd/system/your-program-service-name.service
# systemctl enable your-program-service-name.service
# systemctl start your-program-service-name.service

[Service]
ExecStart=mono /opt/your-program-service-name/YourProgramName.exe
Restart=always
RestartSec=10                       # Restart service after 10 seconds if node service crashes
StandardOutput=syslog               # Output to syslog" >> /etc/systemd/system/your-program-service-name.service
StandardError=syslog                # Output to syslog" >> /etc/systemd/system/your-program-service-name.service
SyslogIdentifier=your-program-service-name
WorkingDirectory=/opt/your-program-service-name/

# https://www.freedesktop.org/software/systemd/man/systemd.exec.html
NoNewPrivileges=yes
PrivateTmp=yes
ProtectSystem=strict
ProtectHome=yes

[Install]
WantedBy=multi-user.target
```



# Snap Service

The below yaml file copies all files from the local ./build/Release folder into the root of the snap.  It installs all packages fro __state-packages__ as
dependencies that the service will require.

__your-program-service-name.yaml__

```yaml
name: your-program-service-name
version: 0.1
summary: Your programs summary
description: 
  A description of what this service does
confinement: strict

apps:
  your-program-service-name-searcher:
    command: mono $SNAP/YourProgramName.exe
    plugs: [network-bind]
    daemon: simple

parts:
  your-program-service-name-searcher-bin:
    plugin: copy
    files:
       "./build/Release/*": "."
    stage-packages:
      - mono-runtime
      - libmono-corlib4.5-cil
      - libmono-system-core4.0-cil
      - libmono-system-net-http4.0-cil
      - libmono-system-runtime4.0-cil
      - libmono-system-web-extensions4.0-cil
      - libmono-system-xml4.0-cil
      - libmono-system-web4.0-cil
      - libmono-system-web-http4.0-cil
      - libmono-system-xml-linq4.0-cil
      - libmono-microsoft-csharp4.0-cil
      - libmono-http4.0-cil
      - curl
```

To build the snap package run 

```bash
snapcraft clean
mkdir -p build
snapcraft snap -o "$(pwd)/build/your-program-service-name.snap"
```

To install the snap without uploading to the Ubuntu snap store run

```bash
snap install "${pwd}/build/your-program-service-name.snap" --force-dangerous'
```

At this point, your c# console app should be running as a systemd service.

