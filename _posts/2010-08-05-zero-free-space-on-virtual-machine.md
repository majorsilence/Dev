---
layout: post
title: Zero free space on virtual machine
created: 1281043040
redirect_from:
  - /virtualbox_shrink_compact/
---
When you need to free up space on a virtual machine (Windows XP/2003/Vista/7) use sdelete (Zero free space) http://technet.microsoft.com/en-us/sysinternals/bb897443.aspx.

Boot the vm.  Defrag the drive.
Run:
sdelete -z c:

Shut down the vm

Using VirtualBox do the following:
VBoxManage modifyvdi "/path/to/vmDisk.vdi" --compact

Newer versions:
VBoxManage modifyhd "/path/to/vmDisk.vdi" --compact

The path must be the full path.
