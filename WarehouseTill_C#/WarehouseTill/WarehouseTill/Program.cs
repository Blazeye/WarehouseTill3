using WarehouseTill.display;
using WarehouseTill.products;
using WarehouseTill.till;

namespace WarehouseTill
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Make a new 'till' based on the ITill interface
            ITill till = new Till(new ProductCatalog());

            // Construct a console interaction file
            var consoleInteraction = new ConsoleTillDisplay(till);

            // Start the main loop
            consoleInteraction.Run();
        }
    }
}
