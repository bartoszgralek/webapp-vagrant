#!/usr/bin/env bash

sudo add-apt-repository universe
sudo apt-get update
sudo apt-get -y install default-jdk
sudo apt-get -y install git

mkdir -p ~/.ssh
chmod 700 ~/.ssh
ssh-keyscan -H github.com >> ~/.ssh/known_hosts
ssh -T git@github.com
git clone -b vagrant-test git@github.com:bartoszgralek/webapp-vagrant.git

cd webapp-vagrant
git pull
cd backend
sudo ./mvnw clean install
sudo ./mvnw spring-boot:run &
