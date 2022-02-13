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
sudo apt-get install jenkins docker.io -y

# java -jar jenkins-cli.jar -s http://localhost:8080/ install-plugin SOURCE ... [-deploy] [-name VAL] [-restart]

```

## Plugin setup

Install the docker and git branch source plugins

* https://plugins.jenkins.io/docker-plugin/
* https://plugins.jenkins.io/github-branch-source/
    * Assuming github is being used


# Jenkinfile Pipeline Examples

Each eample should be saved as __Jenkinfile__ and saved in the base folder of your code repo.  

## Dotnet

Example of bulding and testing a dotnet project that as nunit testing enabled.

```groovy
pipeline {
    agent none
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
        }
        post{
            always {
                nunit testResultsPattern: 'build/nunit-results.xml'
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


## Go


## Python


## Ruby


## Java


# Swift


## Kotlin


## C


## C++


## Zig

