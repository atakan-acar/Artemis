using Artemis.ConsoleUI.DbSocket;
using Artemis.Domain.Entities.User;
using Artemis.Domain.Projects;
using Artemis.Domain.Projects.Category;
using Artemis.Domain.Projects.h_AppSetings;
using Artemis.Domain.Projects.Product;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


//string productScript = EntityAdaptDatabase.AdaptEntity<Product>();

//string categoryScript = EntityAdaptDatabase.AdaptEntity(typeof(Category));

string allScript = EntityAdaptDatabase.AdaptAll("Artemis.Domain.Entities", typeof(User), typeof(IEntity));

//string objectScript = EntityAdaptDatabase.AdaptEntity(new Product());

//Type[] types = { typeof(Product), typeof(Category) };

//string allTypes = EntityAdaptDatabase.AdaptEntity(types);

//Console.WriteLine(objectScript);


//Type[] types = { typeof(Product), typeof(Category) };
//string allTypes = EntityAdaptDatabase.AdaptEntity(types);
//Console.WriteLine(allTypes);

Console.WriteLine(allScript);