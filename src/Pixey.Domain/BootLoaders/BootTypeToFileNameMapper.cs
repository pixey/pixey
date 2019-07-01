using System.Collections.Generic;
using System.Reflection;

namespace Pixey.Domain.BootLoaders
{
    internal class BootTypeToFileNameMapper
    {
        private readonly IReadOnlyDictionary<string, BootType> _mappings;

        public BootTypeToFileNameMapper()
        {
            _mappings = LoadMappings();
        }

        public bool TryGetBootType(string fileName, out BootType bootType)
        {
            _mappings.TryGetValue(fileName, out bootType);
        }

        private IReadOnlyDictionary<string, BootType> LoadMappings()
        {
            var mappings = new Dictionary<string, BootType>();

            var enumType = typeof(BootType);
            var fields = enumType.GetFields(BindingFlags.Public);

            foreach (var fieldInfo in fields)
            {
                var attribute = fieldInfo.GetCustomAttribute<BootLoaderFileNameAttribute>();

                mappings.Add(attribute.FileName, (BootType) fieldInfo.GetValue(null));
            }

            return mappings;
        }
    }
}