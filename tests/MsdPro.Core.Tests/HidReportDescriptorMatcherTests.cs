using MsdPro.Usb;

namespace MsdPro.Core.Tests;

public class HidReportDescriptorMatcherTests
{
    [Fact]
    public void IsMsdProInterface_WithMsdProDescriptor_ReturnsTrue()
    {
        byte[] descriptor = Convert.FromHexString(
            "06A0FF0901A1010902A10006A1FF090309041580257F350045FF75089600028102090509061580257F350045FF75089600049102C0C0"
        );

        bool result = HidReportDescriptorMatcher.IsMsdProInterface(descriptor);

        Assert.True(result);
    }

    [Fact]
    public void IsMsdProInterface_WithKeyboardDescriptor_ReturnsFalse()
    {
        byte[] descriptor = Convert.FromHexString(
            "05010906A101050719E029E71500250175019508810295017508810395057501050819012905910295017503910395067508150025FF0507190029658100C0"
        );

        bool result = HidReportDescriptorMatcher.IsMsdProInterface(descriptor);

        Assert.False(result);
    }

    [Fact]
    public void IsMsdProInterface_WithEmptyDescriptor_ReturnsFalse()
    {
        bool result = HidReportDescriptorMatcher.IsMsdProInterface([]);

        Assert.False(result);
    }

    [Fact]
    public void IsMsdProInterface_WithIncompleteDescriptor_ReturnsFalse()
    {
        byte[] descriptor = [0x06, 0xA0];

        bool result = HidReportDescriptorMatcher.IsMsdProInterface(descriptor);

        Assert.False(result);
    }
}
