#!/usr/bin/env bash

wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo add-apt-repository universe
sudo apt-get update
sudo apt-get -qq -y install apt-transport-https
sudo apt-get -qq update
sudo apt-get -qq -y install dotnet-sdk-2.2=2.2.203-1

DIRECTORY=/home/vagrant/shopping-list-2/backend

if [ -d "$DIRECTORY" ]; then
  rm -rf /home/vagrant/shopping-list-2/backend
fi

mkdir /home/vagrant/shopping-list-2/backend -p
cp -rf /vagrant/shopping-list-2/src/backend/* /home/vagrant/shopping-list-2/backend/
cd /home/vagrant/shopping-list-2/backend/ShoppingList.Api