using System.Threading.Tasks;

namespace Vega.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private VegaDbContext context;

        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }
}
