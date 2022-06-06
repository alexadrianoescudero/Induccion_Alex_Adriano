using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Repository.Context;

namespace nombremicroservicio.Test.Utilitarios
{
    public class BaseTest
    {
        protected DemoPichinchaContext ConstruirContext(string baseDatos)
        {
            var dbBase = new DbContextOptionsBuilder<DemoPichinchaContext>().UseInMemoryDatabase(baseDatos).Options;
            var dbContext = new DemoPichinchaContext(dbBase);
            return dbContext;
        }
    }
}
