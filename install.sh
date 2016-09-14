#  This script should do all the preparation for your project to run, such as downloading any dependencies and compiling if necessary\]
#!/bin/bash
cd ~/
# Install mono
sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
sudo apt-get install mono-complete
# Install Dotnet 
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
sudo apt-get update
sudo apt-get install dotnet-dev-1.0.0-preview2-003121
dotnet new
# Install and configure git
sudo apt-get install git-all
git config --global user.name "Dan Stauffer"
git config --global user.email daniel.v.stauffer@gmail.com
# Download Giphynator project
git clone https://github.com/dan-v-stauffer/Giphynator.git
cd Giphynator/Giphynator/src/Giphynator
dotnet restore
cd ~/