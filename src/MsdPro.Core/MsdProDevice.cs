namespace MsdPro.Core;

public class MsdProDevice
{
    public string Name { get; private set;}
    public ushort VendorId { get; private set; }
    public ushort ProductId { get; private set; }
    public string? FirmwareVersion { get; private set; }

    public MsdProDevice()
    {
        Name = "Mars Gaming MSD-PRO";
        VendorId = 0x0B00;
        ProductId = 0x1003;
        FirmwareVersion = null;
    }

    public string GetDescription()
    {
        return $"{Name} (VID: 0x{VendorId:X4}, PID: 0x{ProductId:X4})";
    }

    public void UpdateFirmwareVersion(string firmwareVersion)
    {
        if (string.IsNullOrWhiteSpace(firmwareVersion))
        {
            throw new ArgumentException(
                "Firmware version cannot be empty.",
                nameof(firmwareVersion)
            );
        }

        FirmwareVersion = firmwareVersion;
    }
}
