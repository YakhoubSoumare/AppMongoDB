using MongoDB.Bson;

namespace AppMongoDB;

internal interface IContractorDAO
{
    public List<T> ReadAll<T>();
    public T ReadOne<T>(ObjectId id);
    public void CreateOne<T>(T document);
    public void UpdateOne<T>(T document);
    public void DeleteOne<T>(ObjectId id);
}
