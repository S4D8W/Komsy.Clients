using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Komsy.infrastructure.Models.Auth;
using Komsy.infrastructure.Services.LocalStorageService;
using Microsoft.AspNetCore.Components;

namespace Komsy.infrastructure.Services.Http {
	public class HttpService : IHttpService {

		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _JsonOptions;
		private readonly NavigationManager _navigationManager;
		private readonly ILocalStorageService _localStorageService;
		public HttpService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService) {

			_httpClient = httpClient;
			_navigationManager = navigationManager;
			_localStorageService = localStorageService;

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
			UserModel User = await _localStorageService.GetItem<UserModel>("user")!;

			if (User != null) {
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", User.Token);
			}

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
