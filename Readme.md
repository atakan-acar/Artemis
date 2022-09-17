<h1>Artemis</h1>
The Artemis project allows to create the database object if it does not exist in the database.


You give the specified path and the class to inherit that file finds the objects under it and creates the table views


```
namespace Artemis.Domain.Projects.Product
{
    public class Product : BaseEntity, IEntity
    { 
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
```
