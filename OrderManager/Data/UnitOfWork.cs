using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OrderManager.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        public ICommands commandsService { get; private set; }
        public IQueries queriesService { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            commandsService = new CommandsService(_context);
            queriesService = new QueriesService(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}