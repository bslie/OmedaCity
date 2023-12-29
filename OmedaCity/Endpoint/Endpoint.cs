using Newtonsoft.Json;
using OmedaCity.Exceptions;
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
        if (string.IsNullOrWhiteSpace(baseUrl))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(baseUrl));

        KeepAlive = false;

        try
        {
            _uriBuilder = new UriBuilder(baseUrl);
        }
        catch (UriFormatException)
        {
            throw new UriFormatException("Base URL is not a valid URL.");
        }

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

        try
        {
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"The server returned a status code {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result == null ? throw new InvalidOperationException("Failed to deserialize the response from the server") : result;
        }
        catch (HttpRequestException ex)
        {
            throw new EndpointException("An error occurred while executing an HTTP request", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new EndpointException("The request was canceled", ex);
        }
        catch (InvalidOperationException ex)
        {
            throw new EndpointException("Invalid operation", ex);
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _handler?.Dispose();
        GC.SuppressFinalize(this);
    }
}