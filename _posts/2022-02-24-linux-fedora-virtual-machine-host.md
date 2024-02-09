---
layout: post
title: Host virtual machines on a linux desktop
date: 2022-02-27
last_modified: 2024-02-09
comments: true
---


## Host

Install virt-manager and cockpit machines.  Either can be used to manage and create virtual machines.

### Fedora
```bash
sudo dnf install @virtualization cockpit cockpit-machines cockpit-pcp
sudo systemctl enable --now cockpit.socket
```

### Ubuntu
```bash
sudo apt-get install virt-manager cockpit cockpit-machines cockpit-pcp

Add your user to the libvirt and kvm groups to avoid being asked to enter your password every time you open the management app.

```bash
sudo usermod -a -G libvirt $(whoami)
sudo usermod -a -G kvm $(whoami)
```

## Guest


Note: the spice-vdagent is only for virtual machines with GUIs.   For text only servers ssh into them directly from your host terminal.

Retrieve the IP address to remote into from the __show virtual hardware details__ or by running __ip addr show__ from within the virt manager terminal window.


### Fedora

```bash
sudo dnf install spice-vdagent
sudo systemctl start spice-vdagent
```


### Ubuntu

```bash
sudo apt install spice-agent
sudo systemctl start spice-vdagent
```


### Windows

Download windows guest binaries from [https://www.spice-space.org/download.html](https://www.spice-space.org/download.html).



## Reference

* [https://fedoramagazine.org/full-virtualization-system-on-fedora-workstation-30/](https://fedoramagazine.org/full-virtualization-system-on-fedora-workstation-30/)
* [https://superuser.com/questions/548433/how-do-i-prevent-virt-manager-from-asking-for-the-root-password](https://superuser.com/questions/548433/how-do-i-prevent-virt-manager-from-asking-for-the-root-password)
* [https://help.ubuntu.com/community/KVM/VirtManager](https://help.ubuntu.com/community/KVM/VirtManager)
