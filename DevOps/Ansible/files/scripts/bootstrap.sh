#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

mkdir -p /var/www

configure_example()
{

	if [ -d "/sites" ]; then
  		# Control will enter here if $DIRECTORY exists.
  		# running on local vagrant
  		rm -rf /var/www/example.com
  		ln -fs /sites/example.com /var/www/example.com
  	else

		if [ ! -d "/var/www/example.com" ]; then
			rm -rf /var/www/example.com
			mkdir /var/www/example.com
		fi
	fi

	
	chown -R www-data:www-data /var/www/example.com
	chmod 755 /var/www

	> /etc/nginx/sites-enabled/example.com

	# config server port 80 with mono
	echo "server {" >> /etc/nginx/sites-enabled/example.com
	echo "    listen 80;" >> /etc/nginx/sites-enabled/example.com
	echo "    listen [::]:80;" >> /etc/nginx/sites-enabled/example.com
	echo "    root /var/www/example.com;" >> /etc/nginx/sites-enabled/example.com
	echo "    index index.html index.htm index.php;" >> /etc/nginx/sites-enabled/example.com
	echo "    server_name example.com www.example.com;" >> /etc/nginx/sites-enabled/example.com
	echo "    rewrite        ^ https://\$server_name\$request_uri? permanent;" >> /etc/nginx/sites-enabled/example.com
	echo "    location / {" >> /etc/nginx/sites-enabled/example.com
	echo "        try_files \$uri \$uri/ /index.html;" >> /etc/nginx/sites-enabled/example.com
	echo "    }" >> /etc/nginx/sites-enabled/example.com
	echo "    error_page 404 /404.html;" >> /etc/nginx/sites-enabled/example.com
	echo "    error_page 500 502 503 504 /50x.html;" >> /etc/nginx/sites-enabled/example.com
	echo "    location /50x.html {" >> /etc/nginx/sites-enabled/example.com
	echo "        root /usr/share/nginx/www;" >> /etc/nginx/sites-enabled/example.com
	echo "    }" >> /etc/nginx/sites-enabled/example.com
	echo "    location ~ \.php$ {" >> /etc/nginx/sites-enabled/example.com
	echo "        try_files \$uri =404;" >> /etc/nginx/sites-enabled/example.com
	echo "        fastcgi_pass unix:/var/run/php5-fpm.sock;" >> /etc/nginx/sites-enabled/example.com
	echo "        fastcgi_index index.php;" >> /etc/nginx/sites-enabled/example.com
	echo "        fastcgi_param SCRIPT_FILENAME \$document_root\$fastcgi_script_name;" >> /etc/nginx/sites-enabled/example.com
	echo "        include fastcgi_params;" >> /etc/nginx/sites-enabled/example.com
	echo "    }" >> /etc/nginx/sites-enabled/example.com
	echo "}" >> /etc/nginx/sites-enabled/example.com

}



configure_example


