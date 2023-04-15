using Google.Apis.Util.Store;

namespace GmailProvider;

public class MyDataStore: IDataStore
{
    /// <inheritdoc />
    public Task StoreAsync<T>(string key, T value)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task DeleteAsync<T>(string key)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<T> GetAsync<T>(string key)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task ClearAsync()
    {
        throw new NotImplementedException();
    }
};