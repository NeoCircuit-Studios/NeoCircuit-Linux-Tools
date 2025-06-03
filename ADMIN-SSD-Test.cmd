@echo off

echo @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
echo       NeoCircuit-Studios
echo Scripts\GetHardware\ADMIN-SSD-Test.script
echo @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
echo.

:: Check if the script is running as Administrator
net session >nul 2>&1
if %errorlevel% neq 0 (
    echo Script "Scripts\GetHardware\ADMIN-SSD-Test.bat" requires Administrator privileges. Please run it as Administrator.
    pause
    exit /b
)

:: Set the title of the Command Prompt window for clarity
title Running Disk Benchmark - Write Test on C Drive

:: Run the disk performance benchmark with random writes on drive C
echo Starting disk write performance test on drive C...
winsat disk -ran -write -drive C > "%appdata%\NeoCircuit-Studios\user\Hardware\Ssd.txt"

:: Notify user and pause so they can review the results
echo Disk performance test completed. Results saved to "user\Hardware\Ssd.txt".
pause
