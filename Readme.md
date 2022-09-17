<h1>Artemis</h1>
The Artemis project allows to create the database object if it does not exist in the database.


<h4>
 
 namespace ProjectName.Entities { 
    class Product : IEntity
    { 
      Guid Id {get; set;} 

      Title string {get; set; }
    }
  }
  ####### Converted #######

  Create Table Product {
    Id uniqueidentifier not null,
    Title  nvarchar not null
   }
  
 </h4>
