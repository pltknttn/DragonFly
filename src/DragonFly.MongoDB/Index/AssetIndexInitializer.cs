// Copyright (c) usercode
// https://github.com/usercode/DragonFly
// MIT License

using DragonFly.Init;
using DragonFly.MongoDB.Storages;
using MongoDB.Driver;

namespace DragonFly.MongoDB;

/// <summary>
/// CreateIndexInitializer
/// </summary>
class AssetIndexInitializer : IPostInitialize
{
    public AssetIndexInitializer(MongoClient client)
    {
        Client = client;
    }

    /// <summary>
    /// Storage
    /// </summary>
    public MongoClient Client { get; }

    public async Task ExecuteAsync(IDragonFlyApi api)
    {
        IMongoCollection<MongoAsset> assets = Client.Database.GetAssetCollection();

        await assets.AddIndexAsync($"{nameof(MongoAsset.Name)}").ConfigureAwait(false);
        await assets.AddIndexAsync($"{nameof(MongoAsset.Slug)}").ConfigureAwait(false);
        await assets.AddIndexAsync($"{nameof(MongoAsset.Alt)}").ConfigureAwait(false);
        await assets.AddIndexAsync($"{nameof(MongoAsset.MimeType)}").ConfigureAwait(false);
        await assets.AddIndexAsync($"{nameof(MongoAsset.Size)}").ConfigureAwait(false);
        await assets.AddIndexAsync($"{nameof(MongoAsset.CreatedAt)}").ConfigureAwait(false);
        await assets.AddIndexAsync($"{nameof(MongoAsset.ModifiedAt)}").ConfigureAwait(false);
    }
}
