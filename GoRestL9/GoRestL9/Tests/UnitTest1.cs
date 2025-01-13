using Bogus;
using GoRestL9.Helpers;
using GoRestL9.Models;
using Newtonsoft.Json;

namespace GoRestL9.Tests
{
    public class UnitTest1
    {
        readonly HttpClient client = new HttpClient();
        readonly string goRestUsersUrl = "https://gorest.co.in/public/v2/users/";
        readonly string token = "Bearer c7fa16d5373e821a30ba94fa9af4c1abc0839e9b4a644f6a8e1748e80ddd570a";
        readonly Faker faker = new Faker();


        [Fact]
        public async void CreateAndAssertUser()
        {
            User newUser = UserGenerator.InstantiateUser();

            string content = await Requests.CreateUser(client, goRestUsersUrl, token, newUser);
            User? user = JsonConvert.DeserializeObject<User>(content);

            string getUri = goRestUsersUrl + user.id;

            string contentGet = await Requests.GetUser(client, getUri, token);
            User? createdUser = JsonConvert.DeserializeObject<User>(contentGet);

            Assert.Multiple(
                () => Assert.Equal(newUser.name, createdUser?.name),
                () => Assert.Equal(newUser.email, createdUser?.email)
                );
        }


        [Fact]
        public async void CreateAndUpdateUser()
        {
            string newEmail = faker.Internet.ExampleEmail();
            string patchField = "{\"email\": \"" + newEmail + "\"}";

            User newUser = UserGenerator.InstantiateUser();

            string content = await Requests.CreateUser(client, goRestUsersUrl, token, newUser);
            User? user = JsonConvert.DeserializeObject<User>(content);

            string userUri = goRestUsersUrl + user.id;

            string contentPatch = await Requests.PatchUser(client, userUri, token, patchField);
            User? updateUser = JsonConvert.DeserializeObject<User>(contentPatch);

            Assert.Equal(newEmail, updateUser?.email);
        }

        [Fact]
        public async void DeleteCreatedUser()
        {
            User newUser = UserGenerator.InstantiateUser();

            string content = await Requests.CreateUser(client, goRestUsersUrl, token, newUser);
            User? user = JsonConvert.DeserializeObject<User>(content);

            string userUri = goRestUsersUrl + user.id;

            Requests.DeleteUser(client, userUri, token);

            string contentGet = await Requests.GetUser(client, userUri, token);

            Assert.Contains("not found", contentGet);
        }
    }
}