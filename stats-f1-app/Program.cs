using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Program
{
	public class Program
	{
		static async Task Main()
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					string baseUrl = "https://ergast.com/api/f1/";
					string endpoint = "2024/2/results.json";
					string url = $"{baseUrl}{endpoint}";

					HttpResponseMessage response = await client.GetAsync(url);

					if (response.IsSuccessStatusCode)
					{
						var jsonContent = await response.Content.ReadFromJsonAsync<JsonElement>();
						var options = new JsonSerializerOptions { WriteIndented = true };
						string jsonString = JsonSerializer.Serialize(jsonContent, options);
						Console.WriteLine(jsonString);
					}
					else
					{
						Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}
			}
		}
	}
}
