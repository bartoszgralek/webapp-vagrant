#!/usr/bin/env bash

sudo add-apt-repository universe
sudo apt-get update
sudo apt-get -y install default-jdk
sudo apt-get -y install git

DIRECTORY=/home/vagrant/webapp-vagrant

if [ ! -d "$DIRECTORY" ]; then
  git clone https://github.com/bartoszgralek/webapp-vagrant.git
fi

cd webapp-vagrant
git pull
cd backend
./mvnw clean install
./mvnw spring-boot:run
