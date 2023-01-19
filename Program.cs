

namespace AppMongoDB;

internal class Program
{
    static void Main(string[] args)
    {
        IUI presentation;
        IContractorDAO integration;
        CatalogueController business;

        presentation = new TerminaUI();
        integration = new ContractorDAO(ConnectionString.connectionString, "ContractorDatabase");
        business = new CatalogueController(presentation, integration);

        business.Start();
    }
}