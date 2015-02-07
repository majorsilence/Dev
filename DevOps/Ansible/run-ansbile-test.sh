#!/usr/bin/env bash

ansible-playbook ./files/website-playbook-test.yml --user "vagrant" --ask-pass -i ./files/hosts -vvvv
