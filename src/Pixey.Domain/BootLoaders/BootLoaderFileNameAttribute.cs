using System;

namespace Pixey.Domain.BootLoaders
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BootLoaderFileNameAttribute : Attribute
    {
        public string FileName { get; }

        public BootLoaderFileNameAttribute(string fileName)
        {
            FileName = fileName;
        }
    }
}