using MongoDB.Bson;
using MongoDB.Driver;

namespace AppMongoDB;

internal class ContractorDAO : IContractorDAO
{
    IMongoCollection<ContractorModel> collection;
    public ContractorDAO(string server, string database)
    {

    }
    public void CreateOne<T>(T document)
    {
        throw new NotImplementedException();
    }

    public void DeleteOne<T>(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public List<T> ReadAll<T>()
    {
        throw new NotImplementedException();
    }

    public T ReadOne<T>(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public void UpdateOne<T>(T document)
    {
        throw new NotImplementedException();
    }
}
