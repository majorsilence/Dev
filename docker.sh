#!/usr/bin/env bash
set -e # exit on first error
set -u # exit on using unset variable

sudo docker run -v "$(pwd)":/src -p 4000:4000 -it jekyll/jekyll:4.2.0 bash -c "mkdir -p /src && cd /src && jekyll serve --incremental"

