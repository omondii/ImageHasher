# Image Hasher
A C# program that manipulates a given pictures' Hash value forcibly modifying it while maintaining close to initial picture visibility.  

## Usage
```./spoof hexString image.png newImage.png```  
The program takes in a hexstring value that should be a hexadecimal equivalent number, an original image of type **_.png_** and a save name for the new image **_.png_**.  
The original Image is the slightly altered using the ImageSharp library by changing the pixel values for a single point by -1 or 1. The altered Image  
is then used to generate a hash value using the SHA512 algorithm, the Image is the saved to memory using the name provided.

## Check the Images hash value
``` sha512sum newImage.png ```

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
2. Navigate to the main project directory\
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
chmod +x bin/Release/net8.0/linux-x64/publish/ImageHash
````
6. Create a symbolic link on a linux OS, program name
```` Create symbolic link
ln -s bin/Release/net8.0/linux-x64/publish/ImageHash spoof
````

## DISCLAIMER
This is created for educational and informational purposes only.

