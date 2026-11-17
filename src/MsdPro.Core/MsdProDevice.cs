namespace MsdPro.Core;

public class MsdProDevice
{
    public string Name { get; set;} = "Mars Gaming MSD-PRO";
    public ushort VendorId { get; set; } = 0x0B00;
    public ushort ProductId { get; set; } = 0x1003;
    public string? FirmwareVersion { get; set; }

    public string GetDescription()
    {
        return $"{Name} (VID: 0x{VendorId:X4}, PID: 0x{ProductId:X4})";
    }
}