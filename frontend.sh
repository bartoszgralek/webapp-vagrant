#!/usr/bin/env bash

sudo apt -qq update
sudo apt -qq install tmux
sudo apt -qq install curl
curl -sL https://deb.nodesource.com/setup_10.x | sudo -E bash -
echo "INSTALL NODEJS"
sudo apt -qq install nodejs -y
echo "INSTALL NPM"
sudo apt -qq install npm -y

echo "COPYING"
mkdir /home/vagrant/shopping-list-2/frontend -p
sudo cp -rf /vagrant/shopping-list-2/src/mobile/* /home/vagrant/shopping-list-2/frontend/
cd /home/vagrant/shopping-list-2/frontend

echo "NPM INSTALL ANGULAR GLOBALLY"
sudo npm install -g --silent @angular/cli
echo "NPM INSTALL"
npm install --silent --no-bin-links
echo "Done!"