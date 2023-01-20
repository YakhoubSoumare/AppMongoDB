using MongoDB.Bson;
using System.Reflection.Metadata;
using System.Linq;
using System.ComponentModel.DataAnnotations;

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
		choices();
    }

    void add() {
		try
		{
            presentation.Print("Enter name:");
            string name = presentation.GetInput();
            presentation.Print("Enter age:");
            int age = Int32.Parse(presentation.GetInput());
            presentation.Print("Enter Description:");
            string description = presentation.GetInput();
            presentation.Print("Enter title:");
            string title = presentation.GetInput();
            presentation.Print("Enter experience level:");
            string level = presentation.GetInput();

            var product = new ContractorModel
            {
                Name = name,
                Age = age,
                Description = description,
                licences = new LicenceModel { Title = title, Level = level }
            };
            integration.CreateOne(product);
        }
		catch(Exception ex)
		{
			presentation.Print(ex.ToString());
		}
    }

	void listOne()
	{
		string output = string.Empty;
		presentation.Print("Enter Id: ");
		try
		{
            var result = integration.ReadOne(new ObjectId(presentation.GetInput()));
            if (result.licences != null)
            {
                output = "\n" + result.Name + "\n" + result.Age.ToString() + "\n" + result.Description + "\n" + result.licences.Title + ": " + result.licences.Level+ "\n\n";
            }
            else
            {
                output = "\n" + result.Name + "\n" + result.Age.ToString() + "\n" + result.Description + "\n\n";
            }
        }
		catch (Exception ex) 
		{
			presentation.Print(ex.Message);
		}

		presentation.Print(output);
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
		try
		{
            presentation.Print("Enter Id:");
            string Id = presentation.GetInput();
            presentation.Print("Enter property you wish to change:");
            string property = presentation.GetInput();

            if (property != null && property.Equals("age"))
            {
                presentation.Print("Change to:");
                string alterValue = presentation.GetInput();

                integration.UpdateSingle(new ObjectId(Id), property, Int32.Parse(alterValue));
            }
            else if (property != null && property.Equals("licence"))
            {
                presentation.Print("Change title to:");
                string title = presentation.GetInput();
                presentation.Print("Change experience level to:");
                string level = presentation.GetInput();

                integration.UpdateSingle(new ObjectId(Id), property, new LicenceModel { Title = title, Level = level });
            }
            else if (property != null)
            {
                presentation.Print("Change to:");
                string alterValue = presentation.GetInput();
                integration.UpdateSingle(new ObjectId(Id), property, alterValue);
            }
        }
        catch(Exception ex) { presentation.Print(ex.Message); }
	}

	void remove()
	{
		try
		{
            presentation.Print("Enter Id:");
            integration.DeleteSingle(new ObjectId(presentation.GetInput()));
        }
		catch(Exception ex) { presentation.Print(ex.Message); }
    }

	string huvudMeny()
	{
		string meny =  ("\n1. Add new contractor" +
						"\n2. List all contractors" +
						"\n3. List a specific contractor" +
						"\n4. Update a specific contractor" +
                        "\n5. Delete a specific contractor" +
                        "\n6. Exit"
                        );
		return meny;
    }

	void choices()
	{
		int choice;
		if(Int32.TryParse(presentation.GetInput(), out choice))
		{
			switch(choice)
			{
				case 1:
					add(); Start(); break;
				case 2:
					listAll(); Start();  break;
				case 3:
					listOne(); Start(); break;
				case 4:
					alter(); Start(); break;
				case 5:
					remove(); Start(); break;
				case 6:
					presentation.Exit(); break;
			}
		}
	}
}
