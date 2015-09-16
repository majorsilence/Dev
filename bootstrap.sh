#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

# See http://michaelchelen.net/81fa/install-jekyll-2-ubuntu-14-04/

apt-get update
apt-get upgrade -y
SITEURL="dotnetdev.majorsilence.com"

function base_system()
{
	apt-get install ruby2.0 ruby2.0-dev make build-essential npm nodejs git nginx zlib1g-dev -y

	yes | gem2.0 install bundler --no-rdoc --no-ri --verbose

	if [ ! -d "/site" ]; then
		# local
		bundle install
	else
		# running in vagrant
		bundle install --gemfile="/site/Gemfile"
	fi
}

function jekyll_hook()
{
	# See https://github.com/developmentseed/jekyll-hook
	rm -rf /usr/bin/node
	ln -s /usr/bin/nodejs /usr/bin/node
	npm install -g forever
	npm install -g forever-service


	cd /root
	git clone https://github.com/developmentseed/jekyll-hook.git
	cd jekyll-hook
	npm install


	> /root/jekyll-hook/config.json
	echo "{" >> /root/jekyll-hook/config.json
	echo "    \"gh_server\": \"github.com\"," >> /root/jekyll-hook/config.json
	echo "    \"temp\": \"/root/jekyll-hook-temp\"," >> /root/jekyll-hook/config.json
	echo "    \"public_repo\": true," >> /root/jekyll-hook/config.json
	echo "    \"scripts\": {" >> /root/jekyll-hook/config.json
	echo "      \"#default\": {" >> /root/jekyll-hook/config.json
	echo "        \"build\": \"./scripts/build.sh\"," >> /root/jekyll-hook/config.json
	echo "        \"publish\": \"./scripts/publish.sh\"" >> /root/jekyll-hook/config.json
	echo "      }" >> /root/jekyll-hook/config.json
	echo "    }," >> /root/jekyll-hook/config.json
	echo "    \"secret\": \"\"," >> /root/jekyll-hook/config.json
	echo "    \"email\": {" >> /root/jekyll-hook/config.json
	echo "        \"isActivated\": false," >> /root/jekyll-hook/config.json
	echo "        \"user\": \"\"," >> /root/jekyll-hook/config.json
	echo "        \"password\": \"\"," >> /root/jekyll-hook/config.json
	echo "        \"host\": \"\"," >> /root/jekyll-hook/config.json
	echo "        \"ssl\": true" >> /root/jekyll-hook/config.json
	echo "    }," >> /root/jekyll-hook/config.json
	echo "    \"accounts\": [" >> /root/jekyll-hook/config.json
	echo "        \"developmentseed\"" >> /root/jekyll-hook/config.json
	echo "    ]" >> /root/jekyll-hook/config.json
	echo "}" >> /root/jekyll-hook/config.json


	sed -i "s/site=\"\/usr\/share\/nginx\/html\/\$repo\"/site=\"\/var\/www\/$SITEURL\"/g" /root/jekyll-hook/scripts/publish.sh
	forever-service install jekyll-hook.js -s jekyll-hook.js --start



    # cp -R /site /root/tmp/site
	# jekyll build --source /root/tmp/site --destination /var/www/site.majorsilence.com
}


configure_nginx_basic()
{

	if [ ! -d "/var/www" ]; then
		mkdir /var/www
	fi

	if [ ! -d "/var/www/$SITEURL" ]; then
		# create folder only if it does not exist
		mkdir "/var/www/$SITEURL"
	fi



}



configure_nginx()
{

	echo "configure_nginx start"

	# clear default site contents
	# cp /etc/nginx/sites-enabled/default /etc/nginx/sites-enabled/default-backup
	> /etc/nginx/sites-enabled/default

	# config server port 80 with mono
	echo "server {" >> /etc/nginx/sites-enabled/default
	echo "	listen 80 default_server;" >> /etc/nginx/sites-enabled/default
	echo "	listen [::]:80 default_server ipv6only=on;" >> /etc/nginx/sites-enabled/default
	echo "	root /var/www/$SITEURL/;" >> /etc/nginx/sites-enabled/default
	echo "	index index.html index.htm;" >> /etc/nginx/sites-enabled/default
	echo "	server_name $SITEURL www.$SITEURL;" >> /etc/nginx/sites-enabled/default

	# The line below will auto redirect to https
	#echo "	rewrite        ^ https://\$server_name\$request_uri? permanent;" >> /etc/nginx/sites-enabled/default
	echo "	location / {" >> /etc/nginx/sites-enabled/default
	echo "		try_files \$uri \$uri/ \$uri.html /index.html;" >> /etc/nginx/sites-enabled/default
	echo "		root /var/www/$SITEURL/;" >> /etc/nginx/sites-enabled/default
	echo "		index index.html index.htm;" >> /etc/nginx/sites-enabled/default
	echo "	}" >> /etc/nginx/sites-enabled/default
	echo "}" >> /etc/nginx/sites-enabled/default
	#\ntry_files $uri $uri/ =404;

	# increase bucket size so more server options can go in sites-enabled/defaults
	# TODO: maybe we want to override the full nginx.conf file
	sed -i 's/# server_names_hash_bucket_size 64;/server_names_hash_bucket_size 64;/g' /etc/nginx/nginx.conf

	# Redirect www to non www
	# https://rtcamp.com/tutorials/nginx/www-non-www-redirection/

	service nginx reload

	echo "configure_nginx finished"
}


configurefirewall()
{
	yes | ufw enable
	ufw allow 80/tcp
	ufw allow 8080/tcp
	yes | ufw allow ssh

	# requires iptables-persistent is installed
	# See http://www.thomas-krenn.com/en/wiki/Saving_Iptables_Firewall_Rules_Permanently
	echo iptables-persistent iptables-persistent/autosave_v4 boolean true | debconf-set-selections
	echo iptables-persistent iptables-persistent/autosave_v6 boolean true | debconf-set-selections
	apt-get install -y iptables-persistent
	iptables-save > /etc/iptables/rules.v4

	/var/lib/dpkg/info/iptables-persistent.postinst;
}

configurefail2ban()
{
	# fail2ban - protect ssh
	# See https://www.digitalocean.com/community/articles/how-to-protect-ssh-with-fail2ban-on-ubuntu-12-04 if you want to make any edits to the config
	apt-get install -y fail2ban
	rm -rf /etc/fail2ban/jail.local
	cp /etc/fail2ban/jail.conf /etc/fail2ban/jail.local
	
	service fail2ban restart
}

generate_site_when_running_in_vagrant()
{

	if [ -d "/site" ]; then
		# vagrant
		cp -R /site /root/tmp/site
		jekyll build --source /root/tmp/site --destination "/var/www/$SITEURL"


		# vagrant ssh into the vm and run the below script to debug
		# jekyll builds
		rm -f /root/debug-jekyll.sh
		touch /root/debug-jekyll.sh
		chmod +x /root/debug-jekyll.sh
		echo "#!/usr/bin/env bash" >> /root/debug-jekyll.sh
		echo "rm -rf /root/tmp/site" >> /root/debug-jekyll.sh
		echo "cp -R /site /root/tmp/site" >> /root/debug-jekyll.sh
		echo "jekyll build --source /root/tmp/site --destination \"/var/www/$SITEURL\" --trace" >> /root/debug-jekyll.sh

	fi

}

configurefirewall
configurefail2ban
base_system
configure_nginx_basic
configure_nginx
jekyll_hook
generate_site_when_running_in_vagrant
