namespace PublicTransportSource.Models;
public class EnvConfig
{
    private const string PORT = "PORT";
    private const string API_BASE_URL = "API_BASE_URL";

    private static string[] DEFAULT_ENVS = new[] { PORT, API_BASE_URL };

    public static EnvConfig CreateDefault()
    {
        return new EnvConfig(DEFAULT_ENVS, (env) => Environment.GetEnvironmentVariable(env));
    }

    internal static EnvConfig CreateDefault(IConfigurationSection envConfigSrc)
    {
        if (envConfigSrc != null)
        {
            return new EnvConfig(DEFAULT_ENVS, (env) => envConfigSrc[env]);
        }
        else
        {
            return CreateDefault();
        }

    }

    private static Exception GetUndefinedEnvironmentException(string env){
        return new Exception($"Environment var {env} is not defined");
    }

    private Dictionary<string, string> _Envs;

    public string ServicePort => _Envs[PORT];
    public string ApiBaseUrl => _Envs[API_BASE_URL];

    public EnvConfig(string[] envs, Func<string, string?> factory)
    {
        _Envs = new Dictionary<string, string>();

        foreach (var env in envs)
        {
            var envValue = factory(env) ?? throw GetUndefinedEnvironmentException(env);
            _Envs.Add(env, envValue);
        }
    }
}