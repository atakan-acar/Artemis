[EN]
<h1>Artemis 🚀</h1> 
The Artemis project allows to create the database object if it does not exist in the database. 
You give the specified path and the class to inherit that file finds the objects under it and creates the table views 
You can get the script output of the objects by using the specified type or types as parameters.

Example: ✍️
```
// Create an Entity
namespace Artemis.Domain.Projects.Product
{
    public class Product : IEntity
    { 
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
```

#### And Using Artemis ### 

Output: 🗃️
```
--Will output the following table creation script
Create Table Product (
    UnitPrice decimal(18,0) not null,
    CreatedAt datetime2(7) not null,
)
```


