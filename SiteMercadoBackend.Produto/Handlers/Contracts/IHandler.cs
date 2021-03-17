using SiteMercadoBackend.Produto.Shared.Contracts;

namespace SiteMercadoBackend.Produto.Handlers.Contracts{

    public interface IHandler<T> where T : ICommand {
        ICommandResult Handle(T command);
    }
}