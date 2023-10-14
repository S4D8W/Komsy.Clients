using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace Komsy.infrastructure.Services.Http {
  public class HttpService : IHttpService {

    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _JsonOptions;
    private NavigationManager _navigationManager;
    public HttpService(HttpClient httpClient, NavigationManager navigationManager) {

      _httpClient = httpClient;
      _navigationManager = navigationManager;

      _JsonOptions = new JsonSerializerOptions {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        IgnoreReadOnlyProperties = true,

      };

    }

    public async Task<T> Get<T>(string url) {

      HttpRequestMessage pRequest = new HttpRequestMessage(HttpMethod.Get, url);


      var response = await SendRequest<T>(pRequest);

      return response;

    }

    public async Task<T> Post<T>(string url, object data) {

      var json = JsonSerializer.Serialize(data);
      var dataString = new StringContent(json, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(url, dataString);

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(await response.Content.ReadAsStringAsync());
      }

      var content = await response.Content.ReadAsStringAsync();
      var result = JsonSerializer.Deserialize<T>(content, _JsonOptions);

      return result ?? throw new ApplicationException("Problem deserializing data");

    }

    private async Task<T> SendRequest<T>(HttpRequestMessage request) {

      T result;

      //TODO: dodać token do nagłówka jak bedzie dorobiony serwis appstate
      // if (cAppState.User != null) {
      // 	request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", cAppState.User.Token);
      // }
      HttpResponseMessage response = await _httpClient.SendAsync(request);

      return result = await HandleResponse<T>(response);

    }

    private async Task<T> HandleResponse<T>(HttpResponseMessage response) {

      T result;
      string exceptionMessage;

      if (response.StatusCode == HttpStatusCode.Unauthorized) {
        _navigationManager.NavigateTo("/login");
        return default;
      }

      if (!response.IsSuccessStatusCode) {
        //dodać obsługę błędów z api
      }


      var content = await response.Content.ReadAsStringAsync();
      result = JsonSerializer.Deserialize<T>(content, _JsonOptions)!;

      return result ?? default!;
    }

  }
}
