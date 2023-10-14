using System.Text.Json;
using Microsoft.JSInterop;

namespace Komsy.infrastructure.Services.LocalStorageService;

public class LocalStorageService : ILocalStorageService {

  private readonly IJSRuntime _jsRuntime;

  public async Task<T> GetItem<T>(string key) {

    var result = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

    if (result == null) {
      return default!;
    }

    return JsonSerializer.Deserialize<T>(result)!;

  }

  public async Task RemoveItem(string key) {

    await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);

  }

  public async Task SetItem<T>(string key, T value) {

    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
  }
}
