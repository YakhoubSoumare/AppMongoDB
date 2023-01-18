using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppMongoDB;

internal class ContractorModel
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement ("age")]
    public int? Age { get; set; }

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("licenses")]
    public List<LicenceModel>? Licence { get; set;}

}

internal class LicenceModel
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("name")]
    public string? Name { get; set; }

    [BsonElement("level")]
    public int? Level { get; set; }
}
