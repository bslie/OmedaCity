using Newtonsoft.Json;
using System.Web;

namespace OmedaCity.Endpoint;

public class Endpoint<T> : IDisposable
{
    public bool KeepAlive { get; }
    private readonly UriBuilder _uriBuilder;
    private readonly HttpClient _httpClient;
    private readonly SocketsHttpHandler _handler;
    public Endpoint(string baseUrl)
    {
        KeepAlive = false;
        _uriBuilder = new UriBuilder(baseUrl);

        _handler = new SocketsHttpHandler();

        if (KeepAlive)
        {
            _handler.PooledConnectionLifetime = TimeSpan.FromMinutes(2);
        }

        _httpClient = new HttpClient(_handler)
        {
            BaseAddress = new Uri(baseUrl)
        };
    }

    public Endpoint<T> AppendPathSegment<TSegment>(TSegment segment)
    {
        if (segment == null) throw new ArgumentNullException(nameof(segment), "Value cannot be null.");

        _uriBuilder.Path = _uriBuilder.Path.TrimEnd('/') + "/" + segment;
        return this;
    }

    public Endpoint<T> SetQueryParam<TName, TValue>(TName name, TValue value)
    {
        if (name == null) return this;
        if (value == null) return this;

        var queryParams = HttpUtility.ParseQueryString(_uriBuilder.Query);
        queryParams[name.ToString()] = value.ToString();
        _uriBuilder.Query = queryParams.ToString();
        return this;
    }

    public async Task<T> GetAsync()
    {
        var url = _uriBuilder.ToString();

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Server returned status code {response.StatusCode}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(content) ?? throw new InvalidOperationException();

        return result;
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _handler?.Dispose();
        GC.SuppressFinalize(this);
    }
}
