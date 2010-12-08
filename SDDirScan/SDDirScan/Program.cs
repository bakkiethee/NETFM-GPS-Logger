using System;
using System.IO;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.IO;
using GHIElectronics.NETMF.IO;
namespace Test
{
class Program
{
public static void Main()
{
// ...
// SD Card is inserted
// Create a new storage device
PersistentStorage sdPS = new PersistentStorage("SD");
// Mount the file system
sdPS.MountFileSystem();
    // Assume one storage device is available, access it through
// Micro Framework and display available files and folders:
Debug.Print("Getting files and folders:");
if (VolumeInfo.GetVolumes()[0].IsFormatted)
{
string rootDirectory =
VolumeInfo.GetVolumes()[0].RootDirectory;
string[] files = Directory.GetFiles(rootDirectory);
string[] folders = Directory.GetDirectories(rootDirectory);
Debug.Print("Files available on " + rootDirectory + ":");
for (int i = 0; i < files.Length; i++)
Debug.Print(files[i]);
Debug.Print("Folders available on " + rootDirectory + ":");
for (int i = 0; i < folders.Length; i++)
Debug.Print(folders[i]);
}
else
{
Debug.Print("Storage is not formatted. Format on PC with FAT32/FAT16 first.");
}
// Unmount
sdPS.UnmountFileSystem();
}
}
}