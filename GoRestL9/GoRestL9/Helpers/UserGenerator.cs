using Bogus;
using GoRestL9.Models;

namespace GoRestL9.Helpers
{
    public static class UserGenerator
    {
        public static User InstantiateUser()
        {
            Faker faker = new Faker();

            string userName = faker.Name.FullName();
            string userEmail = faker.Internet.ExampleEmail();

            string gender = getGender();
            string status = getStatus();

            User newUser = new(null, userName, userEmail, gender, status);
            return newUser;
        }

        private static string getGender()
        {
            string[] genders = { "male", "female" };
            Random random = new Random();
            int index = random.Next(0, 2);
            return genders[index];
        }

        private static string getStatus()
        {
            string[] statuses = { "active", "inactive" };
            Random random = new Random();
            int index = random.Next(0, 2);
            return statuses[index];
        }
    }
}
