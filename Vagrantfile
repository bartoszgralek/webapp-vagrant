
Vagrant.configure("2") do |config|
  config.vm.box = "hashicorp/bionic64"

  config.vm.define "backend" do |backend|
    backend.vm.provision "shell", path: "backend.sh"
    backend.vm.network "private_network", ip: "192.168.0.17"
  end

  config.vm.define "frontend" do |frontend|
    frontend.vm.network "private_network", ip: "192.168.0.18"
  end

end