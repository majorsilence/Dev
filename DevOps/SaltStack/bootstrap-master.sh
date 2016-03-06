#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

apt-get update
apt-get upgrade -y

configuresalt()
{
	echo "configuresalt started"

	apt-get install -y python-software-properties
	add-apt-repository ppa:saltstack/salt
	apt-get update
	apt-get install -y salt-master

	service salt-master restart

	echo "configure saltstack provided git winrepo"
	#sed -i 's/oldstuff/newstufff/g' /etc/salt/master
	echo "win_gitrepos:" >> /etc/salt/master
	echo "  - https://github.com/saltstack/salt-winrepo.git" >> /etc/salt/master

	# See http://docs.saltstack.com/en/latest/topics/windows/windows-package-manager.html for windows specific software install

	salt-run winrepo.update_git_repos
	salt-run winrepo.genrepo
	#salt '*' pkg.refresh_db

	# States tutorial
	# http://docs.saltstack.com/en/latest/topics/tutorials/states_pt1.html

	echo "file_roots:" >> /etc/salt/master
	echo "  base:" >> /etc/salt/master
	echo "    - /srv/salt" >> /etc/salt/master
	echo "" >> /etc/salt/master

	mkdir -p /srv/salt
	mkdir -p /srv/salt/IISStaging
	mkdir -p /srv/salt/NginxStaging
	mkdir -p /srv/salt/PowerShellExample


	# SYNCING CUSTOM TYPES ON MINION START
	# See http://docs.saltstack.com/en/latest/topics/reactor/index.html#minion-start-reactor

	mkdir -p /srv/reactor
	echo "sync_grains:" > /srv/reactor/sync_grains.sls
	echo "  local.saltutil.sync_grains:" >> /srv/reactor/sync_grains.sls
	echo "    - tgt: {{ data['id'] }}" >> /srv/reactor/sync_grains.sls

	echo "reactor:" >> /etc/salt/master
	echo "  - 'minion_start':" >> /etc/salt/master
	echo "    - /srv/reactor/sync_grains.sls" >> /etc/salt/master
	echo "" >> /etc/salt/master


	service salt-master restart

	echo "configuresalt finished"

}

configurefail2ban()
{
	echo "configurefail2ban started"

	# fail2ban - protect ssh
	# See https://www.digitalocean.com/community/articles/how-to-protect-ssh-with-fail2ban-on-ubuntu-12-04 if you want to make any edits to the config
	apt-get install -y fail2ban
	cp -rf /etc/fail2ban/jail.conf /etc/fail2ban/jail.local

	service fail2ban restart

	echo "configurefail2ban finished"
}

configurefirewall()
{
	echo "configurefirewall started"

	yes | sudo ufw enable
	ufw allow salt # 4505 and 4506
	yes | sudo ufw allow ssh


	echo iptables-persistent iptables-persistent/autosave_v4 boolean true | debconf-set-selections
	echo iptables-persistent iptables-persistent/autosave_v6 boolean true | debconf-set-selections

	apt-get install -y iptables-persistent	
	iptables-save > /etc/iptables/rules.v4
	/var/lib/dpkg/info/iptables-persistent.postinst;

	echo "configurefirewall finished"
}


configurecron()
{

	echo "configurecron started"

	> /etc/cron.hourly/saltkeys
	chmod +x /etc/cron.hourly/saltkeys
	echo "#!/usr/bin/env bash" >> /etc/cron.hourly/saltkeys
	echo "set -e" >> /etc/cron.hourly/saltkeys
	echo "set -u" >> /etc/cron.hourly/saltkeys
	echo "# Auto accept all minions" >> /etc/cron.hourly/saltkeys
	echo "yes | salt-key -A" >> /etc/cron.hourly/saltkeys
	echo "" >> /etc/cron.hourly/saltkeys
	echo "salt '*' state.highstate" >> /etc/cron.hourly/saltkeys

	echo "configurecron finished"
}


configuresalt
configurefail2ban
configurefirewall
configurecron
