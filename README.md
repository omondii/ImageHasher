# Image Hasher
A C# program that manipulates a given pictures' Hash value forcibly modifying it while
maintaining close to initial picture visibility.

# DISCLAIMER
This is created for educational and informational purposes only.

# Installation, Set up & Usage
## Pre-Requisites
1. .NET 8 SDK -> "https://dotnet.microsoft.com/en-us/download/dotnet/8.0"
2. Linux OS

## Installation
1. On your terminal
```Clone this repository
git clone https://github.com/omondii/ImageHasher
```
2. Navigate to the main project directory\
```
cd ImageHash
```
3. Build the Project and Create an executable
```Build the Project
dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained true
```
```Create an Executable
dotnet build -c Release
```
4. Make the file executable on Linux
````
chmod +x bin/Release/net8.0/linux-x64/publish/ImageHash
````
```` Create symbolic link
ln -s bin/Release/net8.0/linux-x64/publish/ImageHash spoof
````
## Run
```./spoof hexString image.png```
