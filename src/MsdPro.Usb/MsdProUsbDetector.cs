using HidSharp;

namespace MsdPro.Usb;

public class MsdProUsbDetector
{
    private const ushort VendorId = 0x0B00;
    private const ushort ProductId = 0x1003;

    public IReadOnlyList<MsdProUsbDeviceInfo> FindDevices()
    {
        var devices = DeviceList.Local.GetHidDevices(
            VendorId,
            ProductId
        );

        var detectedDevices = new List<MsdProUsbDeviceInfo>();

        foreach (var device in devices)
        {
            byte[] descriptor = device.GetRawReportDescriptor();

            if (!HidReportDescriptorMatcher.IsMsdProInterface(descriptor))
            {
                continue;
            }

            var deviceInfo = new MsdProUsbDeviceInfo(
                device.DevicePath,
                device.GetProductName(),
                device.GetManufacturer(),
                checked((ushort)device.VendorID),
                checked((ushort)device.ProductID),
                device.GetMaxInputReportLength(),
                device.GetMaxOutputReportLength()
            );

            detectedDevices.Add(deviceInfo);
        }

        return detectedDevices;
    }
}
