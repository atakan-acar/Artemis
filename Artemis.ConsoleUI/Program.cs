using Artemis.ConsoleUI.DbSocket;
using Artemis.Domain.Projects;
using Artemis.Domain.Projects.h_AppSetings;
using Artemis.Domain.Projects.Product;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

string result = EntityAdaptDatabase.AdaptAll("Artemis.Domain.Projects", typeof(h_AppSettings));

string productScript = EntityAdaptDatabase.AdaptEntity<Product>();

productScript = EntityAdaptDatabase.AdaptEntity(typeof(Product));  
string settingScript = EntityAdaptDatabase.AdaptEntity(typeof(h_AppSettings));



//Console.WriteLine("Executed Script:\n{0}", settingScript);