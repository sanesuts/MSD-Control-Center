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

    [Fact]
    public void DeviceProperties_ShouldNotBePubliclyWritable()
    {
        var vendorIdSetter = typeof(MsdProDevice)
            .GetProperty(nameof(MsdProDevice.VendorId))!
            .SetMethod;

        var productIdSetter = typeof(MsdProDevice)
            .GetProperty(nameof(MsdProDevice.ProductId))!
            .SetMethod;

        Assert.NotNull(vendorIdSetter);
        Assert.NotNull(productIdSetter);

        Assert.False(vendorIdSetter!.IsPublic);
        Assert.False(productIdSetter!.IsPublic);
    }

    [Fact]
    public void UpdateFirmwareVersion_ShouldUpdateVersion()
    {
        // Arrange
        var device = new MsdProDevice();
        const string firmware = "V2.MSD-PRO.01.008";

        // Act
        device.UpdateFirmwareVersion(firmware);

        // Assert
        Assert.Equal(firmware, device.FirmwareVersion);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void UpdateFirmwareVersion_ShouldRejectEmptyVersion(string firmware)
    {
        // Arrange
        var device = new MsdProDevice();

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => device.UpdateFirmwareVersion(firmware)
        );
    }

    [Fact]
    public void UpdateFirmwareVersion_ShouldRejectNullVersion()
    {
        // Arrange
        var device = new MsdProDevice();

        // Act & Assert
        Assert.Throws<ArgumentException>(
            () => device.UpdateFirmwareVersion(null!)
        );
    }
}
