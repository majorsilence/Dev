---
layout: post
title: Jenkins and pipelines, Jenkinfile
date: 2022-02-12
last_modified: 2022-02-12
---


# Install

Find instructions at [https://www.jenkins.io/download/](https://www.jenkins.io/download/).

## Ubuntu

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

## Plugin setup

Install the docker pipelines and git branch source plugins

* https://plugins.jenkins.io/docker-workflow/
* https://plugins.jenkins.io/github-branch-source/
    * Assuming github is being used


To display test results various jenkin plugins are used.

* dotnet - [nunit](https://plugins.jenkins.io/nunit/)


# Jenkinfile Pipeline Examples

Each eample should be saved as __Jenkinfile__ and saved in the base folder of your code repo.  

## Dotnet

Example of bulding and testing a dotnet project that has nunit testing enabled.

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

### Nunit Setup

See [https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit) and [https://github.com/spekt/nunit.testlogger](https://github.com/spekt/nunit.testlogger).

```xml
<ItemGroup>
  <PackageReference Include="nunit" Version="3.13.2" />
  <PackageReference Include="NUnit3TestAdapter" Version="4.2.1" />
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.0.0" />
  <PackageReference Include="NunitXml.TestLogger" Version="3.0.117" />
</ItemGroup>
```


## Rust

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


## Go


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


## Python


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

## Ruby

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


## Java
openjdk:19-jdk-buster

# Swift


## Kotlin


## C


## C++


## Zig

