#!/usr/bin/env bash

sudo add-apt-repository universe
sudo apt-get update
sudo apt-get -y install default-jdk
sudo apt-get -y install git

DIR="/home/vagrant/webapp-vagrant/"
if ! [ -d "$DIR" ]; then
  git clone -b vagrant-test https://github.com/bartoszgralek/webapp-vagrant.git
fi

cd webapp-vagrant
git pull
chown vagrant:vagrant /home/vagrant/.m2
