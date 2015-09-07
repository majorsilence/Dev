# SSH Client Setup
* On linux follow instructions at https://www.digitalocean.com/community/tutorials/how-to-set-up-ssh-keys--2.
* On windows follows instructions at https://www.digitalocean.com/community/tutorials/how-to-use-ssh-keys-with-putty-on-digitalocean-droplets-windows-users.

Quick tutorial for creating key on client and copying to the server.

Create key
```bash
ssh-keygen -t rsa -b 4096 -C "your_email@example.com"
```
Copy the key to the server.  Obviously replace the IP with address of you servers.
```bash
ssh-copy-id user@123.45.56.78
```
Alternative copy the key to the server.
```bash
cat ~/.ssh/id_rsa.pub | ssh user@123.45.56.78 "mkdir -p ~/.ssh && cat >>  ~/.ssh/authorized_keys"
```

You can now connect using ssh without a username and password.

# SSH Server
Write me.  I generally have this completely scripted anyway.

Connect to server.  Run commands.  Tunnel.

Configure ssh server to only allow root user and only with ssh public key.
```bash
#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

configuressh()
{
	# Setup ssh server
	# probably already installed but lets make sure
	apt-get install -y openssh-server


	if [ ! -f /etc/ssh/sshd_config.factory-defaults ]; then
    	echo "create a read only copy of default settings"
    	cp /etc/ssh/sshd_config /etc/ssh/sshd_config.factory-defaults
		chmod a-w /etc/ssh/sshd_config.factory-defaults
	fi

	rm -rf /etc/ssh/sshd_config
	touch /etc/ssh/sshd_config

	echo "AllowUsers root" >> /etc/ssh/sshd_config
	echo "Port 22" >> /etc/ssh/sshd_config
	echo "Protocol 2" >> /etc/ssh/sshd_config
	echo "HostKey /etc/ssh/ssh_host_rsa_key" >> /etc/ssh/sshd_config
	echo "HostKey /etc/ssh/ssh_host_dsa_key" >> /etc/ssh/sshd_config
	echo "HostKey /etc/ssh/ssh_host_ecdsa_key" >> /etc/ssh/sshd_config
	echo "HostKey /etc/ssh/ssh_host_ed25519_key" >> /etc/ssh/sshd_config
	echo "UsePrivilegeSeparation yes" >> /etc/ssh/sshd_config
	echo "KeyRegenerationInterval 3600" >> /etc/ssh/sshd_config
	echo "ServerKeyBits 1024" >> /etc/ssh/sshd_config
	echo "SyslogFacility AUTH" >> /etc/ssh/sshd_config
	echo "LogLevel INFO" >> /etc/ssh/sshd_config
	echo "LoginGraceTime 120" >> /etc/ssh/sshd_config
	echo "PermitRootLogin without-password" >> /etc/ssh/sshd_config
	echo "StrictModes yes" >> /etc/ssh/sshd_config
	echo "RSAAuthentication yes" >> /etc/ssh/sshd_config
	echo "PubkeyAuthentication yes" >> /etc/ssh/sshd_config
	echo "IgnoreRhosts yes" >> /etc/ssh/sshd_config
	echo "RhostsRSAAuthentication no" >> /etc/ssh/sshd_config
	echo "HostbasedAuthentication no" >> /etc/ssh/sshd_config
	echo "PermitEmptyPasswords no" >> /etc/ssh/sshd_config
	echo "ChallengeResponseAuthentication no" >> /etc/ssh/sshd_config
	echo "PasswordAuthentication no" >> /etc/ssh/sshd_config
	echo "X11Forwarding no" >> /etc/ssh/sshd_config
	echo "X11DisplayOffset 10" >> /etc/ssh/sshd_config
	echo "PrintMotd no" >> /etc/ssh/sshd_config
	echo "PrintLastLog yes" >> /etc/ssh/sshd_config
	echo "TCPKeepAlive yes" >> /etc/ssh/sshd_config
	echo "AcceptEnv LANG LC_*" >> /etc/ssh/sshd_config
	echo "Subsystem sftp /usr/lib/openssh/sftp-server" >> /etc/ssh/sshd_config
	reload ssh
}

configuressh
echo "ok=true  changed=true name='configuressh'" 
```