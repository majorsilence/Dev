---
layout: post
created: 1644101757
title: Install and setup xrdp rdc server on ubuntu and fedora
---


# Fedora

```bash
# install
sudo dnf install xrdp
sudo systemctl enable xrdp 
sudo systemctl start xrdp 

# check the status if you so desire
sudo systemctl status xrdp 

# firewall rules
sudo firewall-cmd --permanent --add-port=3389/tcp 
sudo firewall-cmd --reload 

# SELinux.  Is this actually required?
sudo chcon --type=bin_t /usr/sbin/xrdp 
sudo chcon --type=bin_t /usr/sbin/xrdp-sesman 

# find the machines ip address
ip addr show
```


# Ubuntu

```bash
sudo apt update
sudo apt install xrdp 

# Confirm xrdp is running if you so desire
sudo systemctl status xrdp

# Add certs permissions for your user.  Is this actually required?
sudo adduser xrdp ssl-cert
sudo systemctl restart xrdp

# firewall rules
sudo ufw allow 3389

# find the machines ip address
ip addr show
```



# External References
* https://tecadmin.net/how-to-install-xrdp-on-fedora/
* https://linuxize.com/post/how-to-install-xrdp-on-ubuntu-20-04/
