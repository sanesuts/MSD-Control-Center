namespace MsdPro.Usb;

public class MsdProUsbDeviceInfo
{
    public string DevicePath { get; }
    public string ProductName { get; }
    public string Manufacturer { get; }
    public ushort VendorId { get; }
    public ushort ProductId { get; }
    public int InputReportLength { get; }
    public int OutputReportLength { get; }

    public MsdProUsbDeviceInfo(
        string devicePath,
        string productName,
        string manufacturer,
        ushort vendorId,
        ushort productId,
        int inputReportLength,
        int outputReportLength)
    {
        DevicePath = devicePath;
        ProductName = productName;
        Manufacturer = manufacturer;
        VendorId = vendorId;
        ProductId = productId;
        InputReportLength = inputReportLength;
        OutputReportLength = outputReportLength;
    }
}
