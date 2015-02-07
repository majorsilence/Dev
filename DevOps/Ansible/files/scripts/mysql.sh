#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

export DEBIAN_FRONTEND=noninteractive
debconf-set-selections <<< 'mysql-server mysql-server/root_password ThePassword ThePassword'
debconf-set-selections <<< 'mysql-server mysql-server/root_password_again ThePassword ThePassword'
apt-get install -y mysql-server
	