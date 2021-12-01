using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOC_Tests
{
    public class TestBase
    {
        private static readonly Assembly TestAssembly = Assembly.GetExecutingAssembly();

        protected static async IAsyncEnumerable<T> ReadExampleFile<T>(string resourceKey)
        {
            using (Stream stream = TestAssembly.GetManifestResourceStream(string.Join(".", "AOC_Tests.Resources", resourceKey)))
            using (StreamReader reader = new(stream))
            {
                string line = string.Empty;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    yield return (T)Convert.ChangeType(line.Trim(), typeof(T));
                }
            }
        }
    }
}
