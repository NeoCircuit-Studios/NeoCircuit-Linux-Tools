# 🍷 Wine Install Script for Ubuntu Only Farming Simulator 25

   In WSL, this script **does not** function. Please utilize an Ubuntu/Linux native installation.


   This straightforward and easy-to-use Bash script was made specifically for the **Farming Simulator 25 Dedicated Server** and installs Wine on Ubuntu.  
   Additionally, it can be used to install Wine without FS25.

   ---

   ## Features

   Installs the usual wine prerequisites
   It is compatible with Ubuntu 20.04, 22.04, and other comparable distributions and is made for the *Farming Simulator 25 Dedicated Server*.
   Simple to operate, perfect for novices, and safe for frequent use (idempotent).
   Self-cleanup logic is included.

   ---


   ## How to Apply It


   ###1. Click this link to download the script.

   Download `NS-Build.sh` in "Script-Download" from the [Releases page](https://github.com/NeoCircuit-Studios/fs-winehelper/releases).

   ### 2. 📂   Place it in the game's *(Optional)* folder.

  If **Farming Simulator 25** is being installed with Wine, put the root directory.

## How to Apply

 ###1. Click here for the script.


 Download `NS-Build.sh` from the [Releases page](https://github.com/YourUsername/YourRepoName/releases).

 ### 2. 📂  Place in the game folder marked *(Optional)*.

 If you are installing Wine for **Farming Simulator 25**, place the script in the root folder of your FS25 Dedicated Server.  
 You can omit this step if you're only installing Wine.

 ### 3. 💻 Run the program.

 Open your terminal and enter:

```bash
sudo apt update -y
sudo apt install dos2unix -y
dos2unix NS-Build.sh
sudo chmod +x NS-Build.sh
sudo ./NS-Build.sh
