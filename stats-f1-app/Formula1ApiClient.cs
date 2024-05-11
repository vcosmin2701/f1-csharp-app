using System.Net.Http.Json;
using System.Text.Json;

namespace stats_f1_app
{
	public class Formula1ApiClient
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _jsonOptions;
		private readonly string _baseUrl = "https://ergast.com/api/f1/";

		public Formula1ApiClient(HttpClient client)
		{
			_client = client;
			_jsonOptions = new JsonSerializerOptions { WriteIndented = true };
		}

		public async Task<string> GetRaceResultAsync(string season, string round)
		{
			try
			{
				string endpoint = $"{season}/{round}/results.json";
				string url = $"{_baseUrl}{endpoint}";

				var response = await _client.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var jsonContent = await response.Content.ReadFromJsonAsync<JsonElement>();
					return JsonSerializer.Serialize(jsonContent, _jsonOptions);
				}
				else
				{
					return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
				}
			}
			catch (Exception ex)
			{
				return $"Error: {ex.Message}";
			}
		}
	}
}
