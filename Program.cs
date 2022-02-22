using System.Text.Json;
using Generator;

List<User> Users = new();

for (int i = 0; i < 1000; i++)
{
    string password = Randomizer.GeneratePassword(8);
    Console.WriteLine($"password: {password}");

    Users.Add(
        new User{
            Username = $"respondent{i}",
            password = password
        }
    );
}

var format = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize<List<User>>(Users, format);

string directory = System.IO.Directory.GetCurrentDirectory();
File.WriteAllText($"{directory}\\generated-user.json", json);