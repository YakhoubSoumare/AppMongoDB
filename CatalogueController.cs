using MongoDB.Bson;
using System.Reflection.Metadata;
using System.Linq;

namespace AppMongoDB;

internal class CatalogueController
{
	IUI presentation;
	IContractorDAO integration;
	public CatalogueController(IUI presentation, IContractorDAO integration)
	{
		this.presentation = presentation;
		this.integration = integration;
	}
	public void Start()
	{
		presentation.Print("Wellcome to your independant-contractor book!");
        presentation.Print(huvudMeny());

        //remove();
        //alter();
        //listAll();
    }

    void add() {
        var product = new ContractorModel
        {
            Name = "Inserted Person",
            Age = 200,
            Description = "Inserted through CRUD",
            licences = new LicenceModel { Title = "Business Manager", Level = "Mid-Level" } 
        };
        integration.CreateOne(product);
    }

	string listOne()
	{
		string jsonString = MongoDB.Bson.BsonExtensionMethods.ToJson<ContractorModel>(integration.ReadOne(new ObjectId("63c888b6a6acec564963486d")));
		return jsonString;
    }

	void listAll()
	{
		string output = string.Empty;
		integration.ReadAll().ForEach(item => 
		{ 
			if(item.licences != null) 
			{
                output = item.Id + ":" + "\n" + item.Name + "\n" + item.Age.ToString() + "\n" + item.Description + "\n" + item.licences.Title+": " + item.licences.Level;               
			}
			else
			{
                output = item.Id + ":" + "\n" + item.Name + "\n" + item.Age.ToString() + "\n" + item.Description + "\n";
            }

            presentation.Print(output.Trim().Replace("\n\n", "\n"));
            presentation.Print("\n");
		});
    }

	void alter()
	{
		integration.UpdateSingle(new ObjectId("63c9147ae5407e84de72e0c4"), 50);
	}

	void remove()
	{
        integration.DeleteSingle(new ObjectId("63c915cd6c1cdcfca33842f5")); 
    }

	string huvudMeny()
	{
		string meny =  ("\n1. Add new contractor" +
						"\n2. List all contractors" +
						"\n3. List a specific contractor" +
						"\n4. Update a specific contractor" +
                        "\n5. Delete a specific contractor"
                        );
		return meny;
    }
}
