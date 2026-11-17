using HidSharp;

namespace MsdPro.Usb;

public sealed class MsdProUsbConnection : IDisposable
{
    private const ushort VendorId = 0x0B00;
    private const ushort ProductId = 0x1003;

    private HidStream? _stream;

    public bool IsOpen => _stream is not null;

    private MsdProUsbConnection(HidStream stream)
    {
        _stream = stream;
    }

    public static bool TryOpen(
        MsdProUsbDeviceInfo deviceInfo,
        out MsdProUsbConnection? connection)
    {
        ArgumentNullException.ThrowIfNull(deviceInfo);

        connection = null;

        var devices = DeviceList.Local.GetHidDevices(
            VendorId,
            ProductId
        );

        foreach (var device in devices)
        {
            if (device.DevicePath != deviceInfo.DevicePath)
            {
                continue;
            }

            byte[] descriptor = device.GetRawReportDescriptor();

            if (!HidReportDescriptorMatcher.IsMsdProInterface(descriptor))
            {
                continue;
            }

            if (!device.TryOpen(out HidStream stream))
            {
                return false;
            }

            connection = new MsdProUsbConnection(stream);

            return true;
        }

        return false;
    }

    public void Dispose()
    {
        HidStream? stream = _stream;
        _stream = null;

        stream?.Dispose();
    }
}
