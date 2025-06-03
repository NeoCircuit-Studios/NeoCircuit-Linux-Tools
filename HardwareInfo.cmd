@echo off

echo @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
echo       NeoCircuit-Studios
echo Scripts\GetHardware\Hardware.Script
echo @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
echo.


set OUTPUT_DIR=%APPDATA%\NeoCircuit-Studios\user\Hardware

:://///
::///make sure the batch script is inside the app folder
::///

:: Create the directory if it doesn't exist
if not exist "%OUTPUT_DIR%" mkdir "%OUTPUT_DIR%"

:: Save system info in the logs folder
echo Loading systeminfo...
systeminfo > "%OUTPUT_DIR%\System.txt"
echo Loading DxDiagOutput...
dxdiag /t "%OUTPUT_DIR%\DirectX.txt"

echo Batch Output: System and DirectX information have been saved to "%OUTPUT_DIR%"
echo ---------------------------------
pause