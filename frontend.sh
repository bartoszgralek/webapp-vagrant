#!/usr/bin/env bash

sudo apt-get -qq update
curl -sL https://deb.nodesource.com/setup_12.x | sudo -E bash -
sudo apt-get -y install nodejs
sudo apt-get -y install npm
sudo apt-get -y install git

mkdir -p ~/.ssh
chmod 700 ~/.ssh
ssh-keyscan -H github.com >> ~/.ssh/known_hosts
ssh -T git@github.com
git clone -b vagrant-test git@github.com:bartoszgralek/webapp-vagrant.git

cd webapp-vagrant
git pull
cd frontend

sudo npm install -g --silent @angular/cli
sudo npm install --silent --no-bin-links
sudo ng set defaults.poll 100 && ng serve --host 0.0.0.0 --port 4200 --watch --disableHostCheck"
