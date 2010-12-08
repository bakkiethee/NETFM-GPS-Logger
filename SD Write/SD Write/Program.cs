using System.Threading;
using System.Text;
using Microsoft.SPOT;
using System.IO;
using Microsoft.SPOT.IO;
using GHIElectronics.NETMF.IO;
using Microsoft.SPOT.Hardware;
using GHIElectronics.NETMF.FEZ;
using System;

// /*
namespace MFConsoleApplication1
{
public class Program
{
static void Main()
{
    
    // ... check if SD is inserted
    // SD Card is inserted
    // Create a new storage device
    PersistentStorage sdPS = new PersistentStorage("SD");
    // Mount the file system
    sdPS.MountFileSystem();
    // Assume one storage device is available,
    // access it through NETMF
    string rootDirectory = VolumeInfo.GetVolumes()[0].RootDirectory;
    FileStream FileHandle = new FileStream(rootDirectory + @"\hello1.txt", FileMode.Create);
    byte[] data = Encoding.UTF8.GetBytes("This string will go in the file!");
      // Toggle LED on SD Write
    OutputPort LED;
    LED = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, true);
    LED.Write(true); 
        // write the data and close the file
    FileHandle.Write(data, 0, data.Length);
          FileHandle.Close();
    // Turn off led
    LED.Write(false);
    // if we need to unmount
    sdPS.UnmountFileSystem();
    // ...
    Thread.Sleep(100);
}
}
}
// */

/*
namespace MFConsoleApplication1
{
public class Program
{
static void Main()
{
// ... check if SD is inserted
// SD Card is inserted
// Create a new storage device
PersistentStorage sdPS = new PersistentStorage("SD");
// Mount the file system
sdPS.MountFileSystem();
// Assume one storage device is available,
// access it through NETMF
string rootDirectory = VolumeInfo.GetVolumes()[0].RootDirectory;
FileStream FileHandle = new FileStream(rootDirectory +
@"\hello.txt", FileMode.Open, FileAccess.Read);
byte[] data = new byte[100];
// write the data and close the file
int read_count = FileHandle.Read(data, 0, data.Length);
FileHandle.Close();
Debug.Print("The size of data we read is: " +
read_count.ToString());
Debug.Print("Data from file:");
Debug.Print(new string(Encoding.UTF8.GetChars(data), 0,
read_count));
// if we need to unmount
sdPS.UnmountFileSystem();
// ...
Thread.Sleep(Timeout.Infinite);
}
}
}
*/