#!/bin/bash

echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo "      NeoCircuit-Studios (NS)"
echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo ""
sleep 3

echo "Wine is NOT owned by NeoCircuit-Studios (NS)"
sleep 1
echo ""
echo "Wine Copyright: "
echo ""


echo Copyright (c) 1993-2025 the Wine project authors (see the file AUTHORS
echo for a complete list)
echo ""
sleep 1

echo "Wine is free software; you can redistribute it and/or modify it under"
echo "the terms of the GNU Lesser General Public License as published by the"
echo "Free Software Foundation; either version 2.1 of the License, or (at"
echo "your option) any later version."
echo ""
sleep 1

echo "This program is distributed in the hope that it will be useful, but"
echo "WITHOUT ANY WARRANTY; without even the implied warranty of"
echo "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU"
echo "Lesser General Public License for more details."
echo ""
sleep 1


echo "A copy of the GNU Lesser General Public License is included in the"
echo "Wine distribution in the file COPYING.LIB. If you did not receive this"
echo "copy, write to the Free Software Foundation, Inc., 51 Franklin St,"
echo "Fifth Floor, Boston, MA 02110-1301, USA."
sleep 1

echo ""

sleep 5

echo ""

echo "V0.1.3"

set -e

# ---------- Functions ----------
yes1() {
    echo ""
    echo "making server-start shortcut.."
    cd .. || exit
    sudo wget https://github.com/NeoCircuit-Studios/wine/releases/download/sys/NS-Run-Dedicated-Server.sh
    sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/releases/download/sys/NS-Run-Dedicated-Server.sh

    read -p "Do you want to start the server? (yes/no): " response
    if [[ "$response" == "yes" ]]; then
        start_server5
    else
        clear
        echo "done! that will be 10 Euros, cash or card?"
        sleep 5
        echo "Updating....."
        sudo ./Update.sh
    fi
}

no1() {
    echo "ERROR: wine not correctly installed, try again later"
    read -p "Do you want to restart your PC/Server? (yes/no): " response
    if [[ "$response" == "yes" ]]; then
        sudo reboot
    else
        cd ..
        clear
        echo "Okay, script will exit."
        echo "Updating....."
        sudo ./Update.sh
    fi
}

configure_FS_4() {
    echo "Configuring Farming Simulator 25 server..."
    sleep 2
    cd .. || exit

    sudo rm -f dedicatedServer.xml
    sudo wget https://github.com/NeoCircuit-Studios/wine/releases/download/sys/dedicatedServer.xml
    sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/releases/download/sys/dedicatedServer.xml
    sleep 2
    echo "Done."
    yes1
}

start_server5() {
    cd .. || exit
    dos2unix Run-Dedicated-Server.sh
    sudo chmod +x Run-Dedicated-Server.sh
    sudo ./Run-Dedicated-Server.sh
}
# ---------- Functions ----------

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""

echo "initializing install script.."

sleep 1
echo ""
echo ""

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""


echo "Downloading Updater"
echo ""

cd ..

sudo wget https://github.com/NeoCircuit-Studios/wine/releases/download/sys/Update.sh
sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/releases/download/sys/Update.sh
echo ""

cd "NeoCircuit-Studios"

echo done.
echo ""


echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""



echo "Uninstalling any wine installs"
echo ""
sleep 2

dpkg -r wine

echo "done!"
echo ""
sleep 2

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""


echo "Downloading wine from source.."
echo ""
sleep 2

sudo git clone https://gitlab.winehq.org/wine/wine.git

echo ""

echo "done!"
sleep 2


echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""

#install wine

echo "Making and installing wine from source.."
echo ""
sleep 2

cd wine

# https://gitlab.winehq.org/wine/wine

echo "Running third party script.."
echo ""
sleep 2

./configure
make -j$(nproc)

echo ""
sleep 2

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""

#install wine

echo "installing wine"
echo ""
sleep 2
echo "Running third party script.."
echo ""
sleep 2


sudo make install
echo ""
echo "wine is installed!"
cd ..

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""


#lets test wine

echo "Testing Wine.."
echo ""
sleep 1
echo 0%
echo "Downloading And Installing.."

sudo wget https://github.com/NeoCircuit-Studios/wine/releases/download/sys/Hello_Wine.7z
echo ""
sleep 1

7z x Hello_Wine.7z

sudo rm Hello_Wine.7z

echo ""

echo "starting test.."
echo "follow the instructions on the screen..."
echo ""
sleep 5

clear

cd Hello_Wine
wine Hello_Wine.exe

echo ""

sleep 2

read -p "Did you see hello world? (yes/no): " response
if [[ "$response" == "yes" ]]; then
    cd .. 
    clear
    echo "Nice!"
    configure_FS_4
else
    cd ..
    no1
fi