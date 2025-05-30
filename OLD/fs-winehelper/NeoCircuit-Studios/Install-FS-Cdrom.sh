#!/bin/bash

echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo "      NeoCircuit-Studios (NS)"
echo "@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@"
echo ""

echo "V0.1.3"
echo ""
echo "loading.."
echo ""
sleep 

set -e # dont fuck errors


echo "Warning!: The Location of the Cd-ROM might be different than made and in this script so it might not work"
sleep 3
pwd

sudo mount /dev/sr0 /mnt

cd /mnt

pwd
echo "trying to run 'setup.exe' with Wine.."

sleep 1
pwd
wine setup.exe