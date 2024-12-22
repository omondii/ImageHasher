# Image Hasher: Image hash Modification Program
# Overview
The Program allows you to generate a new image with a hash that begins with a specified hexadecimal prefix,  
making minimal visual alterations to the original image.  

## Tools
.NET8  
C#  
ImageSharp  
Xunit

# Installation & Set up
## Pre-Requisites
1. .NET 8 SDK -> "https://dotnet.microsoft.com/en-us/download/dotnet/8.0"
2. Linux OS

## Installation
1. On your terminal
```Clone this repository
git clone https://github.com/omondii/ImageHasher
```
2. Navigate to the main project directory
```
cd ImageHash
```
3. Build the Project
```Build the Project
dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained true
```
4. Create an executable file 
```Create an Executable
dotnet build -c Release
```
5. Make the file executable on Linux
````
chmod +x bin/Release/net8.0/linux-x64/publish/ImageHasher
````
6. Create a symbolic link on a linux OS, program name
```` Create symbolic link
ln -s bin/Release/net8.0/linux-x64/publish/ImageHasher spoof
````

## Usage
```
./spoof hexString image.png newImage.png
```

## Check the Images hash value
``` sha512sum newImage.png ```

# To Run Tests
```
dotnet test
```

## DISCLAIMER
This is created for educational and informational purposes only.

