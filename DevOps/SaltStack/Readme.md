All the following commands if run are run from the salt master.


# Master accept minions

Accept All
```bash
salt-key –A
```

Delete All
```bash
salt-key –D
```

Once a minion is accepted you should refresh its package list
```bash
salt '*' pkg.refresh_db
```

# Add a minion to a Grain/Role
Review http://docs.saltstack.com/en/latest/topics/targeting/grains.html

Minion config file: C:\salt\conf\minion

Find the section that looks like the following and add your new role.
```txt
grains:
  roles:
    - IISStaging
```

That could become the following if we added a new role called PowerShellExample.
```txt
grains:
  roles:
    - IISStaging
    - PowerShellExample
```

After saving restart the salt minion with

### On Windows
* Open services.msc
* find salt-minion service
* restart

### On linux
```ps
sudo salt-minion -d
```


# Execute execution modules in state sls files
See http://docs.saltstack.com/en/latest/ref/states/all/salt.states.module.html#module-salt.states.module


# Target Machines based on Roles 
See http://www.saltstat.es/posts/role-infrastructure.html

Run command on all minions
```bash
salt '*' test.ping
```

Run command on only ubuntu servers
```bash
salt -C 'G@os:Ubuntu' test.ping
```

Run command on only IIS servers
```bash
salt -C 'G@roles:IISStaging' test.ping
```


# Apply State to all servers
```bash
salt '*' state.highstate
```

# Trigger run on all grains with the role NginxStaging Updates
```bash
salt -C 'G@roles:NginxStaging' state.highstate
```


# Refresh Git WinRepo


```bash
salt-run winrepo.update_git_repos
salt-run winrepo.genrepo
salt '*' pkg.refresh_db
```


# Debug High State Errors
Call the following from a minion

```bash
salt-call -l debug state.highstate
```

or 
```bash
salt-call state.show_highstate
```


# Live Site

Upload states to master server in the folder 

```bash
/srv/salt
```

When uploading the files use an scp client (filezille, or whatever).

Upload the full contents of the local folder /salt/*.
