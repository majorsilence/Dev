To quote http://jenkins-ci.org/ jenkins is used to build/test software projects continuously and monitor executions of externally-run jobs.
# Install
For example scripts to install jenkins on windows and ubuntu see https://github.com/majorsilence/DotNetDev/tree/master/DevOps/Jenkins.

## Install on Ubuntu
Run the following with sudo.
```bash
echo "install jenkins"
wget -q -O - http://pkg.jenkins-ci.org/debian/jenkins-ci.org.key | apt-key add -
rm -rf /etc/apt/sources.list.d/jenkins.list
echo "deb http://pkg.jenkins-ci.org/debian binary/" > /etc/apt/sources.list.d/jenkins.list
apt-get update
apt-get install -y --force-yes jenkins
```

## Install on Windows
Download from http://mirrors.jenkins-ci.org/windows/latest and follow the instructions.

# Configure after Install
Jenkins will be accessible at http://localhost:8080.  Browse to it and configure however you want.

## Security
If you want you can add security.  An easy setup is:

* Go to "Manage Jenkins -> Configure Global Security"
* Check on "Enable Security"
* Access Control, Security Realm, "Jenkins’ own user database"
* Authorization "Logged-in users can do anything"
* Add a user (make sure the user is created first)

## Plugins
You will what to install a few plugins to use jenkins with most projects.

Browse to the plugin sections "Manage Jenkins -> Manage Plugins -> Available" and install
* Git Plugin
* Github Plugin
* Nunit Plugin
* MSBuild plugin

Those you will probably want with every install.  Other plugins that are very useful include
* Build Monitor Plugin
* Build Pipeline Plugin
* Copy Artifact Plugin
* Github Pull Request Builder
* Parameterized Trigger plugin
* Publish Over SSH
* ThinBackup

### Global Configure (eg. git, ssh, email, urls, credentials, etc.)

Browse to the Configure System section "Manage Jenkins -> Configure System".  Fill in your
* Email settings
* MsBuild settings
* Git credentials
* Ssh sites and credentials
* Anything else you want to work

# Build Pipeline
It is easy to create multiple jobs that all each other.  For example "Job 1 -> Job 2 -> Job 3".  You will want the "Parameterized trigger plugin", "Copy Artifact Plugin", and "Build Pipeline Plugin" installed.

On the dashboard create a new view.  If the build pipeline is installed there is a "Build Pipeline View", choose it and create your pipeline.  Once the pipeline view is created you can add jobs to it.

To have one job call another job, the first job in the post build action add "trigger parameterized build on other project".  I generally like the following settings.
* Enter the name of the next job to build (You have created one, yes?)
* Trigger when job is stable
* Add predefined parameters 
    * ARTIFACT_BUILD_NUMBER=$BUILD_NUMBER
    * The above (ARTIFACT_BUILD_NUMBER) will become an environment variable available in the called job