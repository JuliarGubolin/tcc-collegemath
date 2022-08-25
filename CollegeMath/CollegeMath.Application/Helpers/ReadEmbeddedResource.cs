using System.Reflection;

namespace CollegeMath.Application.Helpers
{
    public static class ReadEmbeddedResource
    {
        public static string ReadEmbeddedResourceFile(string fileName, Assembly assembly)
        {
            List<string> files = assembly.GetManifestResourceNames().ToList();
            var resourceName = files.FirstOrDefault(a => a.Contains(fileName));
            if (resourceName != null)
            {
                string text = string.Empty;
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }
                return text;
            }
            return string.Empty;
        }
    }
}
