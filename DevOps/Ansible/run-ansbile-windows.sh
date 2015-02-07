#!/usr/bin/env bash

ansible-playbook ./files/windows-playbook-test.yml --user "vagrant" --ask-pass -i ./files/hosts -vvvv
