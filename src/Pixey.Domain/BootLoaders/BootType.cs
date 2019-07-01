namespace Pixey.Domain.BootLoaders
{
    public enum BootType
    {
        [BootLoaderFileName("bios")]
        LegacyBios = 1,

        [BootLoaderFileName("efi")]
        UEFI = 2
    }
}