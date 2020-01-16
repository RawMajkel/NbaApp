using Microsoft.Extensions.Configuration;
using NbaApp.Persistance;

namespace NbaApp.Services
{
    public abstract class BaseService
    {
        protected readonly Context _context;
        protected IConfiguration _configuration;

        public BaseService(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
    }
}
