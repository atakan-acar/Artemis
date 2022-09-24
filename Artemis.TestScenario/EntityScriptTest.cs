using Artemis.ConsoleUI.DbSocket;
using Artemis.Domain.Projects;
using Artemis.Domain.Projects.Category;
using Artemis.Domain.Projects.Product;

namespace Artemis.TestScenario
{
    public class EntityScriptTest
    {
        [Fact]
        public void CheckGeneration()
        {
            string productScript = EntityAdaptDatabase.AdaptEntity(typeof(Product));

            string productScriptGeneration = EntityAdaptDatabase.AdaptEntity<Product>();

            Assert.Equal(productScript, productScriptGeneration);
        }

        [Fact]
        public void CheckAll()
        {
            string productScript = EntityAdaptDatabase.AdaptAll("Artemis.Domain.Projects", typeof(Product),typeof(IEntity));

            Assert.NotEmpty(productScript);
        }

        [Fact]
        public void GivenTypes()
        {
            Type[] types = { typeof(Product), typeof(Category) };

            string typesScript = EntityAdaptDatabase.AdaptEntity(types);

            Assert.NotEmpty(typesScript);


        }
    }
}