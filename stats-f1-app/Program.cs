using stats_f1_app;
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
				Formula1ApiClient apiClient = new Formula1ApiClient(client);
				var result = await apiClient.GetRaceResultAsync("2024", "2");
				Console.WriteLine(result);
			}
		}
	}
}
