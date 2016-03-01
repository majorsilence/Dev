---
layout: base
title: Ansible
---

Ansible uses ssh for all linux connections and winrm for windows connections.  See [ssh](https://github.com/majorsilence/DotNetDev/wiki/SSH) for basic ssh setup.

# Ansible Install
See http://docs.ansible.com/intro_installation.html.

## Ubuntu install
```bash
sudo apt-get install -y software-properties-common
sudo apt-add-repository -y ppa:ansible/ansible
sudo apt-get update
sudo apt-get install -y ansible
```

## Target Windows
If you want to target windows you will also need to install the following:
```bash
sudo apt-get install -y python-pip
pip install http://github.com/diyan/pywinrm/archive/master.zip#egg=pywinrm
```
You will also need to make sure the windows machine is [properly prepped](http://docs.ansible.com/intro_windows.html#windows-system-prep).

# Create Playbook
See https://github.com/majorsilence/DotNetDev/tree/master/DevOps/Ansible for examples.

# Run Ansible
See https://github.com/majorsilence/DotNetDev/tree/master/DevOps/Ansible for examples.

# Various Configs

## Ansible with Username 
Not recommend.  Use ssh keys instead.

Use the --ask-pass option to use username and password instead of ssh key.

```bash
ansible-playbook playbook.yml --ask-pass --user=TheUserName -i /path/to/hosts/file
```

## Parallelism
-f 10 parallelism level of 10 servers at once.  Replace 10 with however many servers to want to run at the same time.

## Ansible SSH problems with Vagrant

For example you get the message.
"""
FATAL: no hosts matched or all hosts have already failed -- aborting
"""
If you have already created the vm and destroyed it and recreated this is probably caused by a host idenfication change. SSH does not like it.

Test this out by running something like
```bash
ssh vagrant@192.168.40.4
```
If you get the __remote host identifcation has changed warning__, remove the host with the following command.

```bash
ssh-keygen -R 192.168.40.4
```
Obviously replacing the IP with the IP of your virtual machine.
