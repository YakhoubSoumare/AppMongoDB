using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppMongoDB;

//[BsonIgnoreExtraElements]
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

    //[BsonElement("licenses")]
    public LicenceModel? licences { get; set;}

}

//[BsonIgnoreExtraElements]
internal class LicenceModel
{
    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("level")]
    public string Level { get; set; }
}
