---
layout: post
title: Ubuntu 14.04 MVC5 with razor and nginx
created: 1401287116
redirect_from:
  - /ubuntu_14.04_mvc5_with_razor_and_nginx/
---
Below is a bash script that will automatically configure nginx to work with mono to display mvc5 razor or web form sites.

Note that the script assumes you have a clean install.  If the default nginx config file as been modified this will not work.

You will need to replace "examplesite.com" with the name of your site.

Tools used:
<ul>
<li>Ubuntu 14.04</li>
<li>Mono 3.2.8</li>
<li>Nginx 1.4.6</li>
<li>Upstart</li>
</ul>


The scripts installs nginx, mono, modifies the nginx default config file to support mono fastcgi and creates an upstart service to start and monitor the site.

For more details see the following pages.

<ul>
<li>http://www.mono-project.com/FastCGI_Nginx</li>
<li>http://wiki.nginx.org/Mono</li>
<li>http://sourcecodebean.com/archives/serving-your-asp-net-mvc-site-on-nginx-fastcgi-mono-server4/1617</li>
<li>https://github.com/ServiceStack/ServiceStack/wiki/Run-ServiceStack-in-Fastcgi-hosted-on-nginx</li>
</ul>

```bash
configuremono()
{

	apt-get install -y mono-devel libmono-sqlite4.0-cil sqlite3 libmysql6.4-cil 

	echo "configure /etc/mono/registry for use with MVC5"
	rm -rf /etc/mono/registry
	mkdir /etc/mono/registry
	mkdir /etc/mono/registry/LocalMachine
	chmod g+rwx /etc/mono/registry/
	chmod g+rwx /etc/mono/registry/LocalMachine
}


configurenginxbasic()
{

	apt-get install -y nginx mono-fastcgi-server
	rm -rf /var/www
	mkdir /var/www
	ln -fs /vagrant/published-site /var/www/examplesite.com

	# clear default site contents
	# cp /etc/nginx/sites-enabled/default /etc/nginx/sites-enabled/default-backup
	> /etc/nginx/sites-enabled/default

	# config server port 80 with mono
	echo "server {" >> /etc/nginx/sites-enabled/default
	echo "listen 80 default_server;" >> /etc/nginx/sites-enabled/default
	echo "listen [::]:80 default_server ipv6only=on;" >> /etc/nginx/sites-enabled/default
	echo "root /var/www/examplesite.com/;" >> /etc/nginx/sites-enabled/default
	echo "index index.html index.htm default.aspx Default.aspx Index.aspx index.aspx;" >> /etc/nginx/sites-enabled/default
	echo "server_name www.examplesite.com;" >> /etc/nginx/sites-enabled/default
	echo "location / {" >> /etc/nginx/sites-enabled/default
	echo "root /var/www/examplesite.com/;" >> /etc/nginx/sites-enabled/default
	echo "fastcgi_pass 127.0.0.1:9000;" >> /etc/nginx/sites-enabled/default
	echo "include /etc/nginx/fastcgi_params;" >> /etc/nginx/sites-enabled/default
	echo "index index.html index.htm default.aspx Default.aspx Index.aspx index.aspx;" >> /etc/nginx/sites-enabled/default
	echo "}" >> /etc/nginx/sites-enabled/default
	echo "}" >> /etc/nginx/sites-enabled/default
	#\ntry_files $uri $uri/ =404;

	service nginx reload

	# upstart service script
	touch /etc/nginx/startexamplesite
	echo "#!/bin/bash" >> /etc/nginx/startexamplesite
	echo "fastcgi-mono-server4 /applications=/:/var/www/examplesite.com/ /socket=tcp:127.0.0.1:9000" >> /etc/nginx/startexamplesite
	
	# group www-data will need access and execute permissions for the upstart service to be able to bring up fast cgi
	# See https://github.com/ServiceStack/ServiceStack/wiki/Run-ServiceStack-in-Fastcgi-hosted-on-nginx
	chgrp www-data /etc/nginx/startexamplesite
	chmod g+rwx /etc/nginx/startexamplesite

	#fastcgi-mono-server4 /applications=/:/var/www/examplesite.com/ /socket=unix:/tmp/fastcgi.socket
	#fastcgi-mono-server4 /applications=/:/var/www/examplesite.com/ /socket=tcp:127.0.0.1:9000
	touch /etc/init/examplesite.conf
	echo "#!upstart" >> /etc/init/examplesite.conf
	echo "description \"example site services\"" >> /etc/init/examplesite.conf
	echo "author \"Peter\"" >> /etc/init/examplesite.conf
	echo "" >> /etc/init/examplesite.conf
	echo "start on startup" >> /etc/init/examplesite.conf
	echo "stop on shutdown" >> /etc/init/examplesite.conf
	echo "" >> /etc/init/examplesite.conf
	echo "respawn" >> /etc/init/examplesite.conf
	echo "" >> /etc/init/examplesite.conf
	echo "script" >> /etc/init/examplesite.conf
	echo "echo \$\$ > /var/run/examplesite.pid" >> /etc/init/examplesite.conf
	echo "exec /etc/nginx/startexamplesite 2>&1" >> /etc/init/examplesite.conf
	echo "end script" >> /etc/init/examplesite.conf
	echo "" >> /etc/init/examplesite.conf
	echo "pre-start script" >> /etc/init/examplesite.conf
	echo "echo \"[`date`] (sys) Starting\" >> /var/log/examplesite.sys.log" >> /etc/init/examplesite.conf
	echo "end script" >> /etc/init/examplesite.conf
	echo "" >> /etc/init/examplesite.conf
	echo "pre-stop script" >> /etc/init/examplesite.conf
	echo "rm /var/run/examplesite.pid" >> /etc/init/examplesite.conf
	echo "echo \"[`date -u +%Y-%m-%dT%T.%3NZ`] (sys) Stopping\" >> /var/log/examplesite.sys.log" >> /etc/init/examplesite.conf
	echo "end script" >> /etc/init/examplesite.conf

	service examplesite start	
	#bash /etc/nginx/startexamplesite &
	service nginx start
	
}

configuremono
configurenginxbasic
```

If you want to see how to create an initial mvc5 razor site see https://www.majorsilence.com/ubuntu_14.04_monodevelop_mvc5_project.
