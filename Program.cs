using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.IO;


namespace WNT
{
    class Programm
    {
        public static void Main(string[] args)
        {

            string pictur = @"  

            __      ___         _                  _             _                _            _ 
            \ \    / (_)_ _  __| |_____ __ _____  | |__  __ _ __| |___  _ _ __   | |_ ___  ___| |
             \ \/\/ /| | ' \/ _` / _ \ V  V (_-<  | '_ \/ _` / _| / / || | '_ \  |  _/ _ \/ _ \ |
              \_/\_/ |_|_||_\__,_\___/\_/\_//__/  |_.__/\__,_\__|_\_\\_,_| .__/   \__\___/\___/_|
                                                                         |_|                    
                                                                                                   

                                    Windows backup tool

                   ";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(pictur);
            Console.WriteLine("<---------------------------------------------- Setup ---------------------------------------------->");
            Console.WriteLine("Please enter the path from the directory");
           //-----------------------------------------------input-------------------------------------
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("enter your sourceDirectory");
            Console.Write("WBT>>> ");
            string sourceDirectory = Console.ReadLine();
            Console.WriteLine("enter your targetDirectory");
            Console.Write("WBT>>> ");
            string targetDirectory = Console.ReadLine();
            //----------------------------------------------copy--------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Copy(sourceDirectory, targetDirectory);

            Console.WriteLine("\r\nEnd of program");
            Console.ReadKey();
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<---------------------------------------------- end ---------------------------------------------->");
        
        } 
    }
}
