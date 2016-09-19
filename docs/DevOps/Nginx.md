---
layout: base
title: nginx
---


Easy to use web server.

Install 
```bash
apt-get install -y nginx
```

Setup default site.  This is in addtion to any other site you setup.
```bash
	> /etc/nginx/sites-enabled/default
```

```nginx
server {
    listen 80 default_server;
    listen [::]:80 default_server ipv6only=on;
    server_name _;
    # Uncomment the line below will auto redirect to https
    #return 301 https://$host$request_uri;
        #	rewrite        ^ https://$server_name$request_uri? permanent;
    #	}
}
```

Configure a site for a domain.

```bash

configure_nginx()
{
	echo "configure_nginx start"

	# clear default site contents
	# cp /etc/nginx/sites-enabled/default /etc/nginx/sites-enabled/default-backup
	sitepath=$1
	SITEURL=$2
	echo "nginx setup $SITEURL"

	if [ ! -f "/var/www/$SITEURL/index.html" ];then
		> "/var/www/$SITEURL/index.html"
	fi

	 > $sitepath

	echo "configure_nginx start"

	echo "server {" >> $sitepath
	echo "	root /var/www/$SITEURL;" >> $sitepath
	echo "	listen 80;" >> $sitepath
	#echo "	listen [::]:80;" >> $sitepath

	if [ -f "/etc/letsencrypt/live/$SITEURL/fullchain.pem" ];then
		echo "  ssl_certificate /etc/letsencrypt/live/$SITEURL/fullchain.pem;" >> $sitepath
		echo "  ssl_certificate_key /etc/letsencrypt/live/$SITEURL/privkey.pem;" >> $sitepath
		echo "	listen 443;" >> $sitepath
		echo "	ssl on;" >> $sitepath
  fi

	echo "	index index.html index.htm;" >> $sitepath
	echo "	server_name $SITEURL www.$SITEURL;" >> $sitepath

	echo "	location / {" >> $sitepath
	echo "		auth_request /sso;" >> $sitepath
	echo "		try_files \$uri \$uri/ \$uri.html /index.html;" >> $sitepath
	echo "		root /var/www/$SITEURL/;" >> $sitepath
	echo "		index index.html index.htm;" >> $sitepath
	echo "	}" >> $sitepath
	echo "    location /.well-known {" >> $sitepath
	echo "		  auth_request off;" >> $sitepath
	echo "        auth_basic          off;" >> $sitepath
	echo "    }" >> $sitepath
	echo "}" >> $sitepath

	systemctl restart nginx 

	echo "configure_nginx finished"
}

```

Call the above bash function like so.

```bash
rm -rf "/etc/nginx/sites-enabled/example.majorsilence.com"
configure_nginx "/etc/nginx/sites-enabled/example.majorsilence.com" "example.majorsilence.com"
```
