using MediatR;
using TestApi.Domain.Models;

namespace TestApi.Domain.Events
{
    public class ProductCreated : INotification
    {
        public Product NewProduct { get; }
        public ProductCreated(Product newProduct) => NewProduct = newProduct;
    }

    public class ProductUpdated : INotification
    {
        public Product NewProduct { get; }
        public ProductUpdated(Product newProduct) => NewProduct = newProduct;
    }

    public class ProductDeleted : INotification
    {
        public Product DeletedProduct { get; }
        public ProductDeleted(Product deletedProduct) => DeletedProduct = deletedProduct;
    }
}
