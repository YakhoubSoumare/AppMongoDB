using System.Reflection.Metadata;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AppMongoDB;

internal class ContractorDAO : IContractorDAO
{
    IMongoCollection<ContractorModel> collection;
    public ContractorDAO(string dbClient, string mongoDatabase)
    {
        var client = new MongoClient(dbClient);
        var database = client.GetDatabase(mongoDatabase);
        this.collection = database.GetCollection<ContractorModel>("Contractors");
    }
    public void CreateOne(ContractorModel document)
    {
        this.collection.InsertOne(document);
    }

    public void DeleteSingle(ObjectId id)
    {
        var filter = Builders<ContractorModel>.Filter.Eq("Id", id);
        collection.DeleteOne(filter);
    }

    public List<ContractorModel> ReadAll()
    {
        return this.collection.Find(new BsonDocument()).ToList();
    }

    public ContractorModel ReadOne(ObjectId id)
    {
        var filter = Builders<ContractorModel>.Filter.Eq("Id", id);
        return this.collection.Find(filter).SingleOrDefault();
    }

    public void UpdateSingle<T>(ObjectId id, string property, T value)
    {
        var filter = Builders<ContractorModel>.Filter.Eq("Id", id);
        var update = Builders<ContractorModel>.Update.Set(property, value);
        
        this.collection.UpdateOne(filter, update);
    }
}
