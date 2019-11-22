
Vagrant.configure("2") do |config|
  config.vm.box = "hashicorp/bionic64"
  config.ssh.forward_agent = true
  config.vm.provider "virtualbox" do |v|
    v.gui = true
  end

  config.vm.define "backend" do |backend|
    # backend.vm.provision "shell", path: "backend.sh"
    backend.vm.network "private_network", ip: "192.168.0.17"

    backend.vm.provision :ansible do |ansible|
      ansible.playbook = "ansible/backend.yml"    
    end
  end

  config.vm.define "frontend" do |frontend|
    # frontend.vm.provision "shell", path: "frontend.sh", run: "always", privileged: true
    frontend.vm.network "private_network", ip: "192.168.0.18"
    frontend.vm.network "forwarded_port", guest: 4200, host: 4200

    frontend.vm.provision :ansible do |ansible|
      ansible.playbook = "ansible/frontend.yml"    
    end
  end



end
