namespace MsdPro.Usb;

internal static class HidReportDescriptorMatcher
{
    public static bool IsMsdProInterface(byte[] descriptor)
    {
        bool hasPageA0 = false;
        bool hasPageA1 = false;

        int index = 0;

        while (index < descriptor.Length)
        {
            byte prefix = descriptor[index++];

            // Long item
            if (prefix == 0xFE)
            {
                if (index + 2 > descriptor.Length)
                {
                    return false;
                }

                int dataLength = descriptor[index++];
                index++; // Long item tag

                if (index + dataLength > descriptor.Length)
                {
                    return false;
                }

                index += dataLength;
                continue;
            }

            int sizeCode = prefix & 0x03;
            int size = sizeCode == 3 ? 4 : sizeCode;

            int itemType = (prefix >> 2) & 0x03;
            int itemTag = (prefix >> 4) & 0x0F;

            if (index + size > descriptor.Length)
            {
                return false;
            }

            // Global item: Usage Page
            if (itemType == 1 && itemTag == 0 && size > 0)
            {
                uint usagePage = 0;

                for (int i = 0; i < size; i++)
                {
                    usagePage |= (uint)descriptor[index + i] << (8 * i);
                }

                if (usagePage == 0xFFA0)
                {
                    hasPageA0 = true;
                }

                if (usagePage == 0xFFA1)
                {
                    hasPageA1 = true;
                }
            }

            index += size;
        }

        return hasPageA0 && hasPageA1;
    }
}
