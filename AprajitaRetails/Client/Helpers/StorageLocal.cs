using Microsoft.JSInterop;
using System.Net.NetworkInformation;

namespace AprajitaRetails.Helpers;

public class LocalStorageAccessor : IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;

    public LocalStorageAccessor(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<T> GetValueAsync<T>(string key)
    {
        await WaitForReference();
        var result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);

        return result;
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task Clear()
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("clear");
    }

    public async Task RemoveAsync(string key)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
    }

    private async Task WaitForReference()
    {
        if (_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/LocalStorageAccessor.js"));
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }
}

//Usage
//@using AprajitaRetails.Helpers
//@inject LocalStorageAccessor LocalStorageAccessor

//StoredValue = await LocalStorageAccessor.GetValueAsync<string>(Key);
// await LocalStorageAccessor.SetValueAsync(Key, Value);

//Add in program or startup 
//builder.Services.AddScoped<LocalStorageAccessor>();


public class SessionStorageAccessor : IAsyncDisposable
{
    private Lazy<IJSObjectReference> _accessorJsRef = new();
    private readonly IJSRuntime _jsRuntime;

    public SessionStorageAccessor(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<T> GetValueAsync<T>(string key)
    {
        await WaitForReference();
        var result = await _accessorJsRef.Value.InvokeAsync<T>("get", key);

        return result;
    }

    public async Task SetValueAsync<T>(string key, T value)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
    }

    public async Task Clear()
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("clear");
    }

    public async Task RemoveAsync(string key)
    {
        await WaitForReference();
        await _accessorJsRef.Value.InvokeVoidAsync("remove", key);
    }

    private async Task WaitForReference()
    {
        if (_accessorJsRef.IsValueCreated is false)
        {
            _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/SessionStorageAccessor.js"));
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_accessorJsRef.IsValueCreated)
        {
            await _accessorJsRef.Value.DisposeAsync();
        }
    }
}