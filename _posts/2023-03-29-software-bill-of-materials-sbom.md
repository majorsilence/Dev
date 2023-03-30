---
layout: post
title: 
date: 2023-03-29
last_modified: 2023-03-29
---

As a reminder to myself.   SBOM (software bill of materials) tooling at this time is [CycloneDX](https://cyclonedx.org/).

At the time of writing all below instructoins assume a linux install with bash.

## Install CycloneDX

```bash
echo "dotnet cyclonedx install"
dotnet tool install --global CycloneDX 
ln -s /root/.dotnet/tools/dotnet-CycloneDX /usr/bin/CycloneDX 

echo "javascript cyclonedx install
npm install --global @cyclonedx/cyclonedx-npm 
```

## Run CycloneDX

Run the dotnet tool against a c# project with github credentials to avoid rate limiting.

```bash
PROJECT_PATH="PROJECT PLACEHOLDER.csproj"
REPORT_TITLE="TITLE PLACEHOLDER"
REPORT_OUTPUT_FOLDER=`pwd`
REPORT_FILENAME="the-sbom-report.xml"
REPORT_VERSION="1.2.3"
GITHUB_USERNAME="GH USERNAME PLACEHOLDER"
GITHUB_TOKEN="GH TOKEN PLACEHOLDER"

CycloneDX $PROJECT_PATH --set-name "$REPORT_TITLE" --set-version "$REPORT_VERSION" --set-type "Application" --github-username "$GITHUB_USERNAME" --github-token "$GITHUB_TOKEN" -o "$REPORT_OUTPUT_FOLDER" -f "$REPORT_FILENAME"
```
