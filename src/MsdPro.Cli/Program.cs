using MsdPro.Core;
using MsdPro.Usb;

var device = new MsdProDevice();

Console.WriteLine("MSD-Control-Center");
Console.WriteLine("==================");
Console.WriteLine();

Console.WriteLine(device.GetDescription());

Console.WriteLine();
Console.WriteLine("Recherche des périphériques USB...");
Console.WriteLine();

var detector = new MsdProUsbDetector();
var devices = detector.FindDevices();

if (devices.Count == 0)
{
    Console.WriteLine("Aucun MSD-PRO détecté.");
}
else
{
    foreach (var usbDevice in devices)
    {
        Console.WriteLine("MSD-PRO détecté !");
        Console.WriteLine($"Fabricant : {usbDevice.Manufacturer}");
        Console.WriteLine($"Produit   : {usbDevice.ProductName}");
        Console.WriteLine($"VID       : 0x{usbDevice.VendorId:X4}");
        Console.WriteLine($"PID       : 0x{usbDevice.ProductId:X4}");
        Console.WriteLine($"Input     : {usbDevice.InputReportLength} octets");
        Console.WriteLine($"Output    : {usbDevice.OutputReportLength} octets");
        Console.WriteLine($"Chemin    : {usbDevice.DevicePath}");
        Console.WriteLine();
    }
}
