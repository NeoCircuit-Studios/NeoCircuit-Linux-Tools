#!/bin/bash

echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo "      NeoCircuit-Studios (NS)"
echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo ""

echo "V0.1.3"
echo ""
echo "Upgrading.." # remove this old shit lol

sudo wget https://github.com/NeoCircuit-Studios/wine/releases/download/sys/NS-Build.sh
sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/releases/download/sys/NS-Build.sh


dos2unix NS-Build.sh

sudo chmod +x NS-Build.sh

sudo ./NS-Build.sh