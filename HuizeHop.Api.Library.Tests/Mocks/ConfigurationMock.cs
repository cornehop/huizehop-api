using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace HuizeHop.Api.Library.Tests.Mocks;

public class ConfigurationMock : IConfiguration
{
    public IConfigurationSection GetSection(string key)
    {
        return null;
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        return null;
    }

    public IChangeToken GetReloadToken()
    {
        return null;
    }

    public string? this[string key]
    {
        get => null;
        set => throw new NotImplementedException();
    }
}