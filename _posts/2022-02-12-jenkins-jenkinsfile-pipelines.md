---
layout: post
title: Jenkins and pipelines, Jenkinfile
date: 2022-02-12
last_modified: 2025-07-11
comments: true
enable_syntax_highlighting: true
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
sudo apt-get install jenkins openjdk-21-jdk-headless docker.io -y
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
* code coverage - [coverage](https://plugins.jenkins.io/coverage/)


## Jenkinfile Pipeline Examples

Each example should be named __Jenkinfile__ and saved in the base folder of your code repo or entered as an inline Jenkins pipeline.

The examples below are the minimum syntax required per programming language.

### Root Access in Docker

If root access is needed, such as to install packages as part of a build, modify the agent section to set the user to root.

```groovy
agent {                     
    docker { 
        image 'ubuntu:22.04'
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
                    image 'mcr.microsoft.com/dotnet/sdk:8.0'
                }
            }
            steps {
                echo "building"
                sh """
                dotnet restore [YourSolution].sln
                dotnet build [YourSolution].sln --no-restore
                dotnet test -c Release [YourSolution].sln --collect:"XPlat Code Coverage" --logger:"nunit"
                """
            }
            post{
                always {
                    nunit testResultsPattern: '**/TestResults/*.xml'
                    recordCoverage(tools: [[parser: 'COBERTURA', pattern: '**/TestResults/**/*cobertura.xml']])
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
  <PackageReference Include="nunit" />
  <PackageReference Include="NUnit3TestAdapter" />
  <PackageReference Include="Microsoft.NET.Test.Sdk" />
  <PackageReference Include="NunitXml.TestLogger" />
  <PackageReference Include="coverlet.collector" />
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
                    image 'rust:1.88'
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
                    image 'golang:1.24-bookworm'
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
                    image 'python:3.13-bookworm'
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
                    image 'ruby:3.4-bookworm'
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
                    image 'openjdk:21-jdk-bookworm'
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
                    image 'swift:6.1-bookworm'
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
                    image 'gcc:15.1-bookworm'
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
                    image 'gcc:15.1-bookworm'
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
                    image 'ubuntu:22.04'
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
                wget https://ziglang.org/download/0.14.1/zig-x86_64-linux-0.14.1.tar.xz
                tar -xvf ./zig-x86_64-linux-0.14.1.tar.xz
                cd ..
                zig/zig-x86_64-linux-0.14.1/zig version
                zig/zig-x86_64-linux-0.14.1/zig
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
                    image 'node:22-bookworm'
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



 



