using System.Text;
using System.Text.Json;

namespace Komsy.infrastructure.Services.Http {
  public class HttpService : IHttpService {

    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient) {
      _httpClient = httpClient;
    }

    public async Task<T> Get<T>(string url) {
      var response = await _httpClient.GetAsync(url);

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(await response.Content.ReadAsStringAsync());
      }

      var content = await response.Content.ReadAsStringAsync();
      var result = JsonSerializer.Deserialize<T>(content);

      return result ?? throw new ApplicationException("Problem deserializing data");
    }

    public async Task<T> Post<T>(string url, object data) {

      var json = JsonSerializer.Serialize(data);
      var dataString = new StringContent(json, Encoding.UTF8, "application/json");
      try {
        var response = await _httpClient.PostAsync(url, dataString);
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);

      }
      // if (!response.IsSuccessStatusCode) {
      //   throw new ApplicationException(await response.Content.ReadAsStringAsync());
      // }

      // var content = await response.Content.ReadAsStringAsync();
      var result = JsonSerializer.Deserialize<T>("");

      return result ?? throw new ApplicationException("Problem deserializing data");

    }




  }
}
