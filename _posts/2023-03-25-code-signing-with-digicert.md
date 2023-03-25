---
layout: post
title: 
date: 2023-03-25
last_modified: 2023-03-25
---

As of June 2023 code signing requires that hardware tokens must be used.   The following documentation is an opinionated way to to make this work using digicert.   This document does not cover initial setup and purchase of ev code signing cert.  This document will only cover using an ev hardware token with SafeNet.

[DigiCert's SafeNet instructions](https://www.digicert.com/kb/code-signing/safenet-client-installation.htm).

# Sign a dotnet assembly

The hardware token must be attached to the computer.   The SafeNet Authentication client tool must be running in the user session and logged in.   

**WILL NOT WORK IN RDP/SSH SESSION**.

Example command syntax as of March 25, 2023.

```powershell
.\signtool.exe sign /tr http://timestamp.digicert.com /td sha256 /fd sha256 /n "Certs Subject Name Goes Here" "C:\path\to\fileToSign.exe"
```

The above example will prompt you with for the hardwares signing token and it must be manually entered for each file signed.

# Enable batch signing files

How to Enable Single Logon for a SafeNet Token

1. Open SafeNet Authentication Client Tools.

Navigate to Start > Program Files > Safenet > Safenet Authentication Client Tools.

2. Click the Advanced View icon (gold gear).
3. In the menu tree in the left pane, select Client Settings.
4. In the right pane, select the Advanced tab.
5. On the Advanced tab, select the Enable single logon option.
6. Click Save.
7. To activate the single logon feature, log off from the computer and log on again.

With the above done SafeNet will only prompt once per session for the hardware signing token password.

# Automated EV signing using signtool /kc

Export the certificate.   See [Automate Extended Validation (EV) code signing](https://stackoverflow.com/questions/17927895/automate-extended-validation-ev-code-signing).  The examples below is taken from that stackoverflow post.   It has screenshots.  Read it.

Ensure that the **{{}}** characters remain just replace the characters **THE_PASSWORD**.

```powershell
& "C:\Program Files (x86)\Windows Kits\10\bin\10.0.22621.0\x64\signtool.exe" sign /tr http://timestamp.digicert.com /td sha256 /fd sha256 /n "Certs Subject Name Goes Here" /f "C:\the\path\to\exported\cert.cer" /csp "eToken Base Cryptographic Provider" /kc "[THE_READER{{THE_TOKEN_PASSWORD}}]=THE_CONTAINER_NAME" "C:\path\to\fileToSign.exe"
```

For **/kc** the value should be in the format below:

```
[reader{{password}}]=name
```

Where:

* reader (THE_READER) is the "Reader name" from the SafeNet Client UI
* password (THE_TOKEN_PASSWORD) is your token password
* name (THE_CONTAINER_NAME) is the "Container name" from the SafeNet Client UI


# References

- [EV Authenticode® Program Signing & Timestamping Using SignTool](https://www.digicert.com/kb/code-signing/ev-authenticode-certificates.htm)
- [Signserver](https://www.signserver.org/)
- [Simple signing server](https://github.com/Danielku15/SigningServer)
- [Automate Extended Validation (EV) code signing](https://stackoverflow.com/questions/17927895/automate-extended-validation-ev-code-signing)
- [TownSuite CodeSigning Service](https://github.com/TownSuite/TownSuite.CodeSigning.Service)
