namespace OrderManager.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICommands commandsService { get; }
        IQueries queriesService { get; }
        Task CompleteAsync();
    }
}
