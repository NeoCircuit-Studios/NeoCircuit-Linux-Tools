#!/bin/bash

echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo "      NeoCircuit-Studios (NS)"
echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo ""

echo "V0.1.3"
echo ""
echo "loading.."

# set -e # fuck errors

sudo rm Build.sh # just in case

echo ""

# -----------------------------------------
# dos2unix Build.sh

# sudo chmod +x Build.sh

# sudo ./Build.sh
# -----------------------------------------

# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------

# ---------- Functions ----------

#function_name() {
#    
#}

Update_Linux() {

#update linux

echo "Updating System.."
echo ""
sleep 1
# echo 0%

sudo apt update -y

sleep 1

echo 50%

sudo apt upgrade -y

echo 99%
sleep 1

echo 100%
sleep 2
echo ""
pwd
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
}


# -----------------------------------------

install_dependencies() {

# Installing required dependencies
echo ""
echo "Installing dependencies..."
echo ""
sleep 1

echo ""
echo "0% - Installing dos2unix"
sudo apt install dos2unix -y

echo ""
sleep 1
echo "10% - Enabling 32-bit architecture"
sudo dpkg --add-architecture i386


echo ""
sleep 1
echo "20% - Updating package lists"
sudo apt update -y

echo ""
sleep 1
echo "40% - Installing compiler & core 32-bit libraries"
sudo apt install gcc-multilib g++-multilib libc6:i386 libc6-dev-i386 -y

echo ""
sleep 1
echo "55% - Installing Wine and dependencies"
sudo apt install wine64 wine32 libwine libwine:i386 fonts-wine -y

echo ""
sleep 1
echo "70% - Installing development libs for building Wine"
sudo apt install libx11-dev:i386 libfreetype6-dev:i386 flex -y

echo ""
sleep 1
echo "75% - Installing bison"
sudo apt install bison -y

echo ""
sleep 1
echo "80% - Installing wget"
sudo apt install wget -y

echo ""
sleep 1
echo "90% - Installing git"
sudo apt install git -y

echo ""
sleep 1
echo "95% - build essentials"
sudo apt install build-essential flex bison gcc-multilib g++-multilib libncurses5-dev libssl-dev libfreetype6-dev libx11-dev libxext-dev libxcb1-dev libxrandr-dev libxinerama-dev libxcomposite-dev libxfixes-dev libxml2-dev libxslt1-dev libfontconfig1-dev
sudo apt install -y p7zip-full


echo ""
sleep 1
echo "95% - Cleaning up unused packages"
sudo apt autoremove -y

echo ""
echo "100% - All dependencies installed!"
sleep 3
echo ""
pwd
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
}

Update_Scripts() {
    sudo rm Update.sh
    sudo rm NS-Update.sh


    sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Update.sh

    dos2unix NS-Update.sh
    sudo chmod +x NS-Update.sh
    sudo ./NS-Update.sh
    pwd
}




Make_dir() {
#make dir

echo "making required directories.."
echo ""

echo 0%
rm -r "NeoCircuit-Studios" # we don't care if it doesn't exist.. lol

echo 80%
mkdir "NeoCircuit-Studios"

echo 100%
cd "NeoCircuit-Studios"
echo ""
pwd
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------

}

download_scripts() {

#download scripts

echo "downloading NS Stuff.."
echo ""

# new 

sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NeoCircuit-Studios/install-configure-FS-from-source.sh
sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NeoCircuit-Studios/install-configure-FS.sh
sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NeoCircuit-Studios/Just-Install-Wine.sh
sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NeoCircuit-Studios/Install-FS-Cdrom.sh

echo 100%
echo ""
pwd
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
}


config_scripts() {
#config script
echo ""
echo "preparing files.."
echo ""

echo 0%
sleep 1

dos2unix install-configure-FS-from-source.sh
dos2unix install-configure-FS.sh
dos2unix Just-Install-Wine.sh
dos2unix Install-FS-Cdrom.sh
sleep 1

echo 99%
sleep 1

sudo chmod +x install-configure-FS-from-source.sh
sudo chmod +x install-configure-FS.sh
sudo chmod +x Just-Install-Wine.sh
sudo chmod +x Install-FS-Cdrom.sh


echo 100%

echo ""

sleep 1

#debug

echo ""
echo "debug:"
echo "-----------------------------------------"
pwd
echo "-----------------------------------------"
echo ""

echo ""

# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------

}



run_and_make_server_Short() {
  pwd
  echo "downloading..."

  sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Run-Dedicated-Server.sh
  
  echo "Making.."
  sleep 1

  dos2unix NS-Run-Dedicated-Server.sh
  sudo chmod +x NS-Run-Dedicated-Server.sh
  sudo ./NS-Run-Dedicated-Server.sh
  pwd

}

Delete_Everything() {
 sleep 1
 echo ""
 echo "0%..."
 sleep 3
 sudo rm -r "NeoCircuit-Studios"
 sudo rm Update.sh
 sudo rm NS-Update.sh
 echo "50%..."
 sudo rm Run-Dedicated-Server.sh
 sudo rm NS-Run-Dedicated-Server.sh
 sudo rm ini.guust
 echo "100%..."
 sleep 1
 echo "Everything is Deleted, Except Build.sh/NS-Build.sh, you can Delete it yourself ;).."
 sleep 3
}


# ---------- Functions ----------


echo "What do you want to do?"
echo ""

echo "Choose an option:"
echo "1: Install Wine for Farming Simulator (including Step 3)."
echo "2: Update Scripts."
echo "3: Start FS25 DedicatedServer and Make Shortcut."
echo "4: Update Ubuntu System."
echo "5: Delete Everything The Scripts Made."
echo "6: install Wine and Run Hello-Wine test."
echo "7: install Farming Simulator from mounted Cd-Rom (Step 1 Required!!!)" 

echo ""

sleep 2

read -p "Enter your choice [1-7]: " choice
echo ""

case "$choice" in
  1)
    clear
    echo "Installing Wine for FS25..."
    Update_Linux
    Update_Scripts
    install_dependencies
    Make_dir
    download_scripts
    config_scripts
    sudo ./install-configure-FS.sh
    ;;
  2)
    clear
    echo "Updating scripts..."
    Update_Scripts
    ;;
  3)
    clear
    echo "Starting FS25 DedicatedServer and Making Shortcut..."
    Update_Scripts
    run_and_make_server_Short
    ;;
  4)
    clear
    echo "Updating Ubuntu system..."
    Update_Linux
    Update_Scripts
    clear
    echo done!
    ;;
  5)
    clear
    echo "Deleting Everything the scripts Made..."
    Delete_Everything
    ;;
  6)
    clear
    echo "Installing Wine And Running Hello-Wine Test..."
    Update_Linux
    Update_Scripts
    install_dependencies
    Make_dir
    download_scripts
    config_scripts
    pwd
    sudo ./Just-Install-Wine.sh
    ;;
  7)
   clear
   echo "Installing Farming Simulator from mounted Cd-Rom..."
   Update_Linux
   Update_Scripts
   Make_dir
   download_scripts
   config_scripts
   pwd
   sudo ./Install-FS-Cdrom.sh
   ;;
  *)
    # clear
    echo "Invalid option."
    Update_Scripts
    ;;
esac