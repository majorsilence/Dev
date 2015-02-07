#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable


sudo apt-get install -y software-properties-common
sudo apt-add-repository -y ppa:ansible/ansible
sudo apt-get update
sudo apt-get install -y ansible

# Allow connecting and configuring windows

sudo apt-get install -y python-pip
pip install http://github.com/diyan/pywinrm/archive/master.zip#egg=pywinrm
