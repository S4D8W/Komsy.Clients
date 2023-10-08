namespace Komsy.infrastructure.Services.Http;


public interface IHttpService {
	Task<T> Get<T>(string url);
	Task<T> Post<T>(string url, object data);
	
}

