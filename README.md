# TinyBeans.Caching
The purpose of TinyBeans.Caching is to provide an easy wrapper to allow caching using IDistributedCache via lambda expression.

## Caching Aspect
Though technically not an aspect since it does require manually calling, it still takes care of caching concerns without having to write custom caching routines or muddy code with using IDistributedCache directly.  Using the ICachingAspect interface is straight forward.

Add the ICachingAspect to your IServiceCollection in one of three ways.  Using defaults, supplying the options, or supplying the configuration.
```cs
public class Startup {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
        services
            .AddTinyCaching();

        services
            .AddTinyCaching(options => {
                // Removed for brevity
            });

        services
            .AddTinyCaching(_configuration.GetSection("TinyCaching"));
    }
}
```

```json
{
  "TinyCaching": {
    "AbsoluteExpiration": "00:30:00",
    "SlidingExpiration": "00:05:00"
  }
}
```

After that, simply wrap anything you want to cache with a lambda expression.  ICachingAspect has support for async as well as an optional parameter for individual caching options.  If the options are not specified, it will use the options supplied during setup.

```cs
var temp = _cachingAspect.Invoke("key", () => {
    return MyAsyncMethod();
});
```

```cs
var temp = await _cachingAspect.InvokeAsync("key", async () => {
    return await MyAsyncMethod();
});
```

## Notes
It is up to the application to wire in the IDistributedCache.