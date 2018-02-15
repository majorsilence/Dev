---
layout: base
title: fail2ban
---

Configure [fail2ban](https://github.com/fail2ban/fail2ban), an intrusion prevention software framework which protects computer servers from brute-force attacks. 

This will help protect linux systems from brute force attacks against

* ssh
* apache
* php
* lighttpd
* mail servers
    * check jail.local for available options
* ftp servers
    * check jail.local for available options
* proxy servers
    * check jail.local for available options
* name servers
    * check jail.local for available options
* mysql
* nagios
* Others

See [fail2ban nginx](https://rtcamp.com/tutorials/nginx/fail2ban/) for a nginx filter.

Please configure by modifying the /etc/fail2ban/jail.local file.

You can also write custom filters if you so choose.


```bash
#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

configurefail2ban()
{

	# fail2ban - protect ssh
	# See https://www.digitalocean.com/community/articles/how-to-protect-ssh-with-fail2ban-on-ubuntu-12-04
	# if you want to make any edits to the config
	apt-get install -y fail2ban
	cp -rf /etc/fail2ban/jail.conf /etc/fail2ban/jail.local

	service fail2ban restart
}

configurefail2ban
echo "ok=true  changed=true name='configurefail2ban'" 
```
