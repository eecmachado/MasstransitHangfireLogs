using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using MongoDB.Driver;

namespace Microsoft.Extensions.DependencyInjection;

public static class HangFireApplicationBuilderExtensions
{
    public static IServiceCollection AddHangFire(this IServiceCollection services, IConfiguration configuration)
    {
        // var mongoUrlBuilder = new MongoUrlBuilder(configuration.GetConnectionString("HangfireConnection"));
        // var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());
        //
        // services
        //     .AddHangfire(configuration => configuration
        //         .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //         .UseSimpleAssemblyNameTypeSerializer()
        //         .UseRecommendedSerializerSettings()
        //         .UseMongoStorage(mongoClient, mongoUrlBuilder.DatabaseName, new MongoStorageOptions
        //         {
        //             MigrationOptions = new MongoMigrationOptions
        //             {
        //                 MigrationStrategy = new MigrateMongoMigrationStrategy(),
        //                 BackupStrategy = new CollectionMongoBackupStrategy(),
        //             },
        //             Prefix = "test.dispatcher",
        //             CheckConnection = true,
        //             CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
        //         }))
        //     .AddHangfireServer(serverOptions =>
        //     {
        //         serverOptions.ServerName = "test.dispatcher server";
        //     });

        services
            .AddHangfire(opt => { opt.UseMemoryStorage(); })
            .AddHangfireServer(serverOptions => { serverOptions.ServerName = "test.dispatcher server"; });

        return services;
    }
}