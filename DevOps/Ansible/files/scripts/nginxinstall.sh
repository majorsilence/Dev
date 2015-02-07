#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable



configurenginxbasic()
{

	echo "Installing nginx software start" 
	# See http://www.mono-project.com/FastCGI_Nginx
	# and http://wiki.nginx.org/Mono
	# and http://sourcecodebean.com/archives/serving-your-asp-net-mvc-site-on-nginx-fastcgi-mono-server4/1617
	# and https://github.com/ServiceStack/ServiceStack/wiki/Run-ServiceStack-in-Fastcgi-hosted-on-nginx

	apt-get install -y nginx acl php5-fpm php5-mysql



	# increase bucket size so more server options can go in sites-enabled/defaults
	# TODO: maybe we want to override the full nginx.conf file
	sed -i 's/# server_names_hash_bucket_size 64;/server_names_hash_bucket_size 64;/g' /etc/nginx/nginx.conf

	# Redirect www to non www
	# https://rtcamp.com/tutorials/nginx/www-non-www-redirection/

	service nginx reload

	echo "Installing nginx software finished" 
	sed -i 's/cgi.fix_pathinfo=1/cgi.fix_pathinfo=0/g' /etc/php5/fpm/php.ini
	sed -i 's/listen = 127.0.0.1:9000/listen = \/var\/run\/php5-fpm.sock/g' /etc/php5/fpm/pool.d/www.conf
	service php5-fpm restart
	service nginx reload
}


configurenginxbasic
