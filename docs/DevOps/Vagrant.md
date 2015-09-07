Vagrant is used to create and configure lightweight, reproducible, and portable development environments.  Download from http://www.vagrantup.com/downloads.  Pick the package that matches your system.

Once installed you can open your favorite console window and type
```bash
vagrant --version
```
and you should see some output similar to 
```
Vagrant 1.7.3
```

# Connect to Host
In the default setup, you should be able to reach your host through your vm default gateway, generally 10.0.2.2

# Setup Vagrantfile

```ruby
# -*- mode: ruby -*-
# vi: set ft=ruby :
VAGRANTFILE_API_VERSION = "2"
Vagrant.configure(VAGRANTFILE_API_VERSION) do |config|
  # please see the online documentation at vagrantup.com.
  config.vm.define "website" do |website|
    website.vm.box = "trusty64"
    website.vm.provision :shell, :path => "bootstrap.sh"
    website.vm.synced_folder "./", "/sites"
    website.vm.box_url = "https://cloud-images.ubuntu.com/vagrant/trusty/current/trusty-server-cloudimg-amd64-vagrant-disk1.box"
    website.vm.network :forwarded_port, guest: 80, host: 7081
    website.vm.network :forwarded_port, guest: 22, host: 7024
    website.vm.network "private_network", ip: "192.167.50.5"
  end
  
end

```

To bring up this new virtual machine, in the same folder as your Vagrantfile, open a command line and run
```bash
vagrant up
```

To delete the virtual machine run
```bash
vagrant destroy -f
```

To rerun the bootstrap script on a running vm run
```bash
vagrant provision
```

To reload the vm config options from the Vagrant file on a runnint vm
```bash
vagrant reload
```

To shutdown a vm run
```bash
vagrant halt
```


This will bring up the virtual machine and run your bootstrap file.