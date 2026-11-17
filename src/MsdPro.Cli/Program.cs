using MsdPro.Core;

var device = new MsdProDevice();

Console.WriteLine("MSD-Control-Center");
Console.WriteLine("==================");
Console.WriteLine();

Console.WriteLine(device.GetDescription());