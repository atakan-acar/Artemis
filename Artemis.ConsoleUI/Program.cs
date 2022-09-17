using Artemis.ConsoleUI.DbSocket;
using Artemis.Domain.Projects;
using Artemis.Domain.Projects.Product;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

string result = EntityAdaptDatabaseTable.AdaptAll("Artemis.Domain.Projects", typeof(Product), typeof(IEntity));



Console.WriteLine("Executed Script:\n{0}", result);