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
echo ""
echo "loading.."

echo ""

# set -e # fuck errors


# ---------- Functions ----------

Update_Scripts() {
    sudo rm Update.sh
    sudo rm NS-Update.sh

    sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Update.sh
    
    dos2unix NS-Update.sh
    sudo chmod +x NS-Update.sh
    sudo ./NS-Update.sh
    pwd
}



# ---------- Functions ----------

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""

echo "Initializing Install Script.."

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

sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Update.sh

sudo rm Update.sh

echo ""

cd "NeoCircuit-Studios"

echo done.
echo ""


echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""



echo "Uninstalling Any Wine Installs"
echo ""
sleep 2

dpkg -r wine

echo "Done!"
echo ""
sleep 2

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""


echo "Downloading Wine-stuff"
echo ""
sleep 2

sudo apt install software-properties-common wget -y
cd ..
sudo wget -nc https://dl.winehq.org/wine-builds/winehq.key
sudo apt-key add winehq.key
cd "NeoCircuit-Studios" 
sudo add-apt-repository 'deb https://dl.winehq.org/wine-builds/ubuntu/ noble main' -y
sudo apt update -y 


echo ""

echo "Done!"
sleep 2


echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""

#install wine

echo "Installing Wine.."
echo ""
sleep 2

sudo apt install --install-recommends winehq-stable -y
sudo apt install wine32
sudo apt install --install-recommends winehq-stable winetricks -y
winetricks corefonts vcrun2015 vcrun2019 dotnet48 dxvk -y

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""

#install wine

echo "Verify Installation"
echo ""
sleep 2
wine --version
echo ""
sleep 2

echo ""
echo "Looks like Wine Is Installed!"

echo ""
# -----------------------------------------
echo "-----------------------------------------"
# -----------------------------------------
echo ""


echo "First-Time Wine Configuration.."
echo ""
sleep 2

winecfg



#lets test wine

echo "Testing Wine.."
echo ""
sleep 1
echo 0%
echo "Downloading And Installing.."

sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NeoCircuit-Studios/Hello_Wine.7z
echo ""
sleep 1

7z x Hello_Wine.7z

sudo rm Hello_Wine.7z

echo ""

echo "Starting Test.."
#echo "follow the instructions on the screen..."
echo ""
sleep 5

clear

cd Hello_Wine
wine Hello_Wine.exe

echo ""

sleep 2
cd ..

clear 
echo "Wine is Installed!!..."
echo "loading..."
sleep 3

Update_Scripts