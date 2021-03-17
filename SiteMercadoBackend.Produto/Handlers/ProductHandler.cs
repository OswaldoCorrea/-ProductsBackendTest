using SiteMercadoBackend.Produto.Commands;
using SiteMercadoBackend.Produto.Entities;
using SiteMercadoBackend.Produto.Handlers.Contracts;
using SiteMercadoBackend.Produto.Repositories;
using SiteMercadoBackend.Produto.Shared.Contracts;

namespace SiteMercadoBackend.Produto.Handlers {

    public class ProductHandler : 
    IHandler<CreateProductCommand>,
    IHandler<UpdateProductCommand>,
    IHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateProductCommand command)
        {
            if(!command.IsValid()){
                return new GenericCommandResult(false,"Ops, aconteceu algo de errado ao criar o produto!", null);
            }
            var product = new Product(command.Name,command.Price,command.ImagePath);
            _repository.Create(product);
            return new GenericCommandResult(true,"Seu produto foi salvo com sucesso!", product);
        }

        public ICommandResult Handle(UpdateProductCommand command)
        {
            if(!command.IsValid()){
                return new GenericCommandResult(false,"Ops, aconteceu algo de errado ao atualizar o produto!", null);
            }
            
            var product = _repository.GetById(command.Id);
            product.UpdateName(command.Name);
            product.UpdatePrice(command.Price);
            product.UpdateImagePath(command.ImagePath);
            
            _repository.Update(product);
            return new GenericCommandResult(true,"Seu produto foi salvo com sucesso!", product);
        }

        public ICommandResult Handle(DeleteProductCommand command)
        {
            if(!command.IsValid()){
                return new GenericCommandResult(false,"Ops, aconteceu algo de errado ao excluir o produto!", null);
            }
            
            var product = _repository.GetById(command.Id);
            _repository.Delete(product);
            return new GenericCommandResult(true,"Seu produto foi excluído com sucesso!", product);
        }
    }

}