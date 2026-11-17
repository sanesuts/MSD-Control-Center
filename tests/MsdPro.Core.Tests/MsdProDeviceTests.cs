using MsdPro.Core;
using Xunit;

namespace MsdPro.Core.Tests;

public class MsdProDeviceTests
{
    [Fact]
    public void Constructor_ShouldInitializeDeviceProperties()
    {
        // Arrange
        var device = new MsdProDevice();

        // Assert
        Assert.Equal("Mars Gaming MSD-PRO", device.Name);
        Assert.Equal((ushort)0x0B00, device.VendorId);
        Assert.Equal((ushort)0x1003, device.ProductId);
        Assert.Null(device.FirmwareVersion);
    }

    [Fact]
    public void GetDescription_ShouldReturnFormattedDeviceInformation()
    {
        // Arrange
        var device = new MsdProDevice();

        // Act
        var description = device.GetDescription();

        // Assert
        Assert.Equal(
            "Mars Gaming MSD-PRO (VID: 0x0B00, PID: 0x1003)", 
            description
        );
    }
}