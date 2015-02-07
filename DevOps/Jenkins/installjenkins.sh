#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

echo "configure jenkins backups folder"
mkdir -p /opt/jenkinsbackups
chmod 777 /opt/jenkinsbackups

echo "install jenkins"
wget -q -O - http://pkg.jenkins-ci.org/debian/jenkins-ci.org.key | apt-key add -
rm -rf /etc/apt/sources.list.d/jenkins.list
echo "deb http://pkg.jenkins-ci.org/debian binary/" > /etc/apt/sources.list.d/jenkins.list
apt-get update
apt-get install -y --force-yes jenkins
