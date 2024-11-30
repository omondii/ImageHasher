﻿using System.Text.RegularExpressions;

namespace ImageHash;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("USage:spoof haxValue image.png");
            return;
        }

        string hexString = args[0];
        string imagePath = args[1];

        hexString = HexValidator(hexString);
        Console.WriteLine(hexString);

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image File Not Found");
            return;
        }
    }

    private static string HexValidator(string hexString)
        /*
         * Hex string validator using Regex
         * @hexString: argument string taken, should be a valid hex number
         */
    {
        string pattern = @"^(0x)?[0-9a-fA-F]+$";

        while (!Regex.IsMatch(hexString, pattern))
        {
            Console.Write("Invalid hex string: ");
            hexString = Console.ReadLine();
        }

        return hexString;
    }
}