#!/usr/bin/env bash

ansible-playbook ./files/website-playbook-live.yml --user "root" -i ./files/hosts -vvvv
