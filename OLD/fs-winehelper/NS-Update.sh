#!/bin/bash

echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo "      NeoCircuit-Studios (NS)"
echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo ""

echo "V0.1.3"

echo ""
echo "Updating Files...."

sudo apt install dos2unix -y

sudo rm Build.sh
sudo rm NS-Build.sh

sudo wget https://github.com/NeoCircuit-Studios/fs-winehelper/blob/main/NS-Build.sh

dos2unix NS-Build.sh

sudo chmod +x NS-Build.sh