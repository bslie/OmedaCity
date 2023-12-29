using NUnit.Framework;
using OmedaCity.Endpoint;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using OmedaCity.Exceptions;

namespace OmedaCityTests;

[TestFixture]
public class EndpointTests
{
    private Endpoint<string> _endpoint;

    private static void NotNull<T>([NotNull] T t)
    {
        _ = t ?? throw new ArgumentNullException();
    }

    [SetUp]
    public void Setup()
    {
        _endpoint = new Endpoint<string>("https://example.com");
    }

    [Test]
    public void Constructor_InvalidUrl_ThrowsException()
    {
        Assert.Throws<UriFormatException>(() => new Endpoint<string>("invalid url"));
    }

    [Test]
    public void AppendPathSegment_NullSegment_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => _endpoint.AppendPathSegment<string>(null));
    }

    [Test]
    public void SetQueryParam_NullName_ReturnsSameInstance()
    {
        var result = _endpoint.SetQueryParam<string, string>(null, "value");
        Assert.That(_endpoint, Is.SameAs(result));
    }

    [Test]
    public void SetQueryParam_NullValue_ReturnsSameInstance()
    {
        var result = _endpoint.SetQueryParam<string, string>("name", null);
        Assert.That(_endpoint, Is.SameAs(result));
        
    }

    [Test]
    public void GetAsync_ServerError_ThrowsException()
    {
        _endpoint.AppendPathSegment("error");

        Assert.ThrowsAsync<EndpointException>(() => _endpoint.GetAsync());
    }

    [TearDown]
    public void TearDown()
    {
        _endpoint.Dispose();
    }
}