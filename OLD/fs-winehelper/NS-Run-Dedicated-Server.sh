#!/bin/bash

echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo "      NeoCircuit-Studios (NS)"
echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo ""

echo "V0.1.3"

echo ""
echo "Loading.."

echo ""

echo "Updating..."

Update_Scripts() {
    sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Update.sh
    sudo rm Update.sh

    dos2unix NS-Update.sh
    sudo chmod +x NS-Update.sh
    sudo ./NS-Update.sh
}

Update_Scripts

sleep 2

echo "Update done!"

sleep 1

echo "Starting FS25 Dedicated-Server.." 

echo "done! that will be 20 Euros, cash or card?"

pwd 

sleep 1

#wine dedicatedServer.exe

WINEPREFIX=~/wine-fs22 wineboot
WINEPREFIX=~/wine-fs22 winetricks dxvk vcrun2019
WINEPREFIX=~/wine-fs22 wine dedicatedServer.exe
