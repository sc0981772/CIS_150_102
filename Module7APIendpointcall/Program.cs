using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Module7APIendpointcall
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string baseUrl = "https://api.agify.io/?name=";

            Console.WriteLine("Enter Name 1:");
            string name1 = Console.ReadLine();

            Console.WriteLine("Enter Name 2:");
            string name2 = Console.ReadLine();

            Console.WriteLine("Enter Name 3:");
            string name3 = Console.ReadLine();

            int age1 = await GetAgeFromAPI(name1, baseUrl);
            int age2 = await GetAgeFromAPI(name2, baseUrl);
            int age3 = await GetAgeFromAPI(name3, baseUrl);

            Console.WriteLine($"Name 1: {name1} is apx {age1} years old");
            Console.WriteLine($"Name 2: {name2} is apx {age2} years old");
            Console.WriteLine($"Name 3: {name3} is apx {age3} years old");

            string oldestName = GetOldest(name1, age1, name2, age2, name3, age3);
            Console.WriteLine($"{oldestName} is the oldest.");
        }

        static async Task<int> GetAgeFromAPI(string name, string baseUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = $"{baseUrl}{name}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseData = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(responseData);

                    return json["age"] != null ? json["age"].ToObject<int>() : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching data for {name}: {ex.Message}");
                    return 0;
                }
            }
        }

        static string GetOldest(string name1, int age1, string name2, int age2, string name3, int age3)
        {
            if (age1 >= age2 && age1 >= age3)
                return name1;
            else if (age2 >= age1 && age2 >= age3)
                return name2;
            else
                return name3;
        }
    }
}
