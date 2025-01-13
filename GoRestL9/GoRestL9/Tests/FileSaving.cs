using GoRestL9.Models;
using Newtonsoft.Json;

namespace GoRestL9.Tests
{
    public class FileSaving
    {
        [Fact]
        public async void Test1()
        {
            var currentDir = System.IO.Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "JsonFile" + Path.DirectorySeparatorChar + "credentials.json";

            JsonFile jsonFile = new JsonFile();

            jsonFile.username = "Ivana";
            jsonFile.password = "123456";

            string serialisedFile = JsonConvert.SerializeObject(jsonFile);

            await File.WriteAllTextAsync(currentDir, serialisedFile);

            var readFile = await File.ReadAllTextAsync(currentDir);

            JsonFile deserialisedFile = JsonConvert.DeserializeObject<JsonFile>(readFile);

            Assert.Equal(jsonFile.username, deserialisedFile.username);
            Assert.Equal(jsonFile.password, deserialisedFile.password);

        }
    }
}
