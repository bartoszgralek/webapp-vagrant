#!/usr/bin/env bash

sudo apt-get -qq update
curl -sL https://deb.nodesource.com/setup_12.x | sudo -E bash -
sudo apt-get -y install nodejs
sudo apt-get -y install npm
sudo apt-get -y install git

DIR="/home/vagrant/webapp-vagrant/"
if ! [ -d "$DIR" ]; then
  git clone -b vagrant-test https://github.com/bartoszgralek/webapp-vagrant.git
fi

cd webapp-vagrant
git pull
cd frontend

npm install -g --silent @angular/cli
npm install --silent --no-bin-links
