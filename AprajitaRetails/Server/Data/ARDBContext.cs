using Microsoft.EntityFrameworkCore;

namespace AprajitaRetails.Server.Data
{
    public class ARDBContext: DbContext
    {
        public ARDBContext(DbContextOptions<ARDBContext> options)
        : base(options)
        {
        }
    }
}
