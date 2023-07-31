var httpClient = new HttpClient();

//var request = new HttpRequestMessage(HttpMethod.Get, "https://api.anilibria.tv/v2/getTitle?code=yasuke");

var response = await httpClient.GetAsync("https://api.anilibria.tv/v2/getTitle?code=tokyoghoul");

var result = await response.Content.ReadAsStringAsync();

Console.WriteLine("Hello, world");