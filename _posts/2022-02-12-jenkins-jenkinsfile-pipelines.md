---
layout: post
title: Jenkins and pipelines, Jenkinfile
date: 2022-02-12
last_modified: 2022-02-27
redirect_from:
  - /news/2022/02/12/jenkins-jenkinsfile-pipelines.html
---


## Install

Find jenkins installation instructions at [https://www.jenkins.io/download/](https://www.jenkins.io/download/).

### Ubuntu

```bash
curl -fsSL https://pkg.jenkins.io/debian-stable/jenkins.io.key | sudo tee \
    /usr/share/keyrings/jenkins-keyring.asc > /dev/null

echo deb [signed-by=/usr/share/keyrings/jenkins-keyring.asc] \
    https://pkg.jenkins.io/debian-stable binary/ | sudo tee \
    /etc/apt/sources.list.d/jenkins.list > /dev/null

sudo apt-get update
sudo apt-get install jenkins openjdk-11-jdk-headless docker.io -y
sudo usermod -a -G docker jenkins 

# java -jar jenkins-cli.jar -s http://localhost:8080/ install-plugin SOURCE ... [-deploy] [-name VAL] [-restart]
```

### Plugin setup

Install the docker pipelines and git branch source plugins

* https://plugins.jenkins.io/docker-workflow/
* https://plugins.jenkins.io/github-branch-source/
    * Assuming github is being used


To display test results various Jenkin plugins are required.

* dotnet - [nunit](https://plugins.jenkins.io/nunit/)


## Jenkinfile Pipeline Examples

Each example should be named __Jenkinfile__ and saved in the base folder of your code repo or entered as an inline Jenkins pipeline.

The examples below are the minimum syntax required per programming language.

### Root Access in Docker

If root access is needed, such as to install packages as part of a build, modify the agent section to set the user to root.

```groovy
agent {                     
    docker { 
        image 'ubuntu:20.04'
        args '-u root:root'
    }
}
```

### Dotnet

Example of building and testing a dotnet project that has nunit testing enabled.  If there is only one solution in the directory then the solution name does not need to be specified.

```groovy
pipeline {
    agent none
    environment {
        DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
    }
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'mcr.microsoft.com/dotnet/sdk:6.0'
                }
            }
            steps {
                echo "building"
                sh """
                dotnet restore [YourSolution].sln
                dotnet build [YourSolution].sln --no-restore
                dotnet vstest [YourSolution].sln --logger:"nunit;LogFileName=build/nunit-results.xml"    
                """
            }
            post{
                always {
                    nunit testResultsPattern: 'build/nunit-results.xml'
                }
            }  
        }      
    }
}
```

#### Nunit Setup

See [https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit) and [https://github.com/spekt/nunit.testlogger](https://github.com/spekt/nunit.testlogger).

```xml
<ItemGroup>
  <PackageReference Include="nunit" Version="3.13.2" />
  <PackageReference Include="NUnit3TestAdapter" Version="4.2.1" />
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.0.0" />
  <PackageReference Include="NunitXml.TestLogger" Version="3.0.117" />
</ItemGroup>
```


### Rust

```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'rust:1.58.1'
                }
            }
            steps {
                echo "building"
                sh """
                cargo build --release
                cargo test   
                """
            }
        }      
    }
}
```


### Go


```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'golang:1.16'
                }
            }
            steps {
                echo "building"
                sh """
                go build
                go test   
                """
            }
        }      
    }
}
```


### Python


```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'python:3.9.10'
                }
            }
            steps {
                echo "whatever is done for python can go here"
                sh """
                python --version
                """
            }
        }      
    }
}
```

### Ruby

```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'ruby:3.1.0'
                }
            }
            steps {
                echo "whatever is done for ruby can go here"
                sh """
                ruby --version
                """
            }
        }      
    }
}
```


### Java


```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'openjdk:19-jdk-buster'
                }
            }
            steps {
                echo "building"
                sh """
                javac -classpath . Main.java
                """
            }
        }      
    }
}
```

### Swift

```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'swift:5.5.3'
                }
            }
            steps {
                echo "building"
                sh """
                swift build
                swift test
                """
            }
        }      
    }
}
```

### C

```groovy
pipeline {
    agent none
    stages {
        stage('build') {
            agent {                     
                docker { 
                    image 'gcc:9.4.0'
                }
            }
            steps {
                echo "building"
                sh """
                gcc --version
                """
            }
        }      
    }
}
```


### C++

```groovy
pipeline {
    agent none
    stages {
        stage('build') {
            agent {                     
                docker { 
                    image 'gcc:9.4.0'
                }
            }
            steps {
                echo "building"
                sh """
                g++ --version
                """
            }
        }      
    }
}
```


### Zig


```groovy
pipeline {
    agent none
    stages {
        stage('build and test') {
            agent {                     
                docker { 
                    image 'ubuntu:20.04'
                    args '-u root:root'
                }
            }
            steps {
                echo "building"
                sh """
                apt update
                apt install wget xz-utils -y

                rm -rf zig
                mkdir -p zig
                cd zig
                wget https://ziglang.org/download/0.9.0/zig-linux-x86_64-0.9.0.tar.xz
                tar -xvf ./zig-linux-x86_64-0.9.0.tar.xz
                cd ..
                zig/zig-linux-x86_64-0.9.0/zig version
                zig/zig-linux-x86_64-0.9.0/zig
                """
            }
        }      
    }
}
```



### Javascript/nodejs

```groovy
pipeline {
    agent none
    stages {
        stage('build') {
            agent {                     
                docker { 
                    image 'node:16'
                }
            }
            steps {
                echo "building"
                sh """
                npm version
                """
            }
        }      
    }
}
```

### Javascript/electron

See [https://www.electron.build/multi-platform-build#docker](https://www.electron.build/multi-platform-build#docker).

```groovy
pipeline {
    agent none
    environment {
        ELECTRON_CACHE="/root/.cache/electron"
        ELECTRON_BUILDER_CACHE="/root/.cache/electron-builder"
    }
    stages {
        stage('build') {
            agent {                     
                docker { 
                    image 'electronuserland/builder:wine'
                    args "--env-file <(env | grep -iE 'DEBUG|NODE_|ELECTRON_|YARN_|NPM_|CI|CIRCLE|TRAVIS_TAG|TRAVIS|TRAVIS_REPO_|TRAVIS_BUILD_|TRAVIS_BRANCH|TRAVIS_PULL_REQUEST_|APPVEYOR_|CSC_|GH_|GITHUB_|BT_|AWS_|STRIP|BUILD_') -v ${PWD}:/project -v ${PWD##*/}-node-modules:/project/node_modules -v ~/.cache/electron:/root/.cache/electron -v ~/.cache/electron-builder:/root/.cache/electron-builder"
                }
            }
            steps {
                echo "building"
                sh """
                yarn && yarn dist
                """
            }
        }      
    }
}
```



 



