# Redis
### This document will explain the installation and configuration of redis in a docker container

**Tim Corey's tutorial on youtube** 

   > https://www.youtube.com/watch?v=UrQWii_kfIE&t=186s

1. Start by running `docker run --name my-cache-server -p 5002:6379 -d redis`. 

    **Note: Redis operates on 6379 by default**
2. Run `dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis`

3. Go to `Program.cs` file where you configure your services. Add our caching information to the Dependency Injection system: `builder.Services.AddStackExchangeRedisCache(options => {});`

4. Add an Extension folder to the root of the project and create a `DistributedCacheExtensions` class.