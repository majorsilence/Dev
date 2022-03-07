---
layout: post
date: 2022-02-05
last_modified: 2022-03-07
title: Install and setup xrdp rdc server on ubuntu and fedora
redirect_from:
  - /news/2022/02/05/linux-and-rdp-servers.html
---

Only one gui session can be logged in at a time.   If you are already logged into your desktop locally then remoting in will cause major issues.

Create a second local account for use with remoting in that you can use to logout of your real account.   

Note to self: research if there is a better way.


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
