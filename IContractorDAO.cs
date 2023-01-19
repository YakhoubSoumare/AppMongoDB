using MongoDB.Bson;

namespace AppMongoDB;

internal interface IContractorDAO
{
    public List<ContractorModel> ReadAll();
    public ContractorModel ReadOne(ObjectId id);
    public void CreateOne(ContractorModel document);
    public void UpdateSingle(ObjectId id, int age);
    public void DeleteSingle(ObjectId id);
}
