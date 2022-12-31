using MediatR;
using TestApi.Domain.Models;

namespace TestApi.Domain.Events
{
    public class CategoryCreated : INotification
    {
        public Category NewCategory { get; }
        public CategoryCreated(Category newCategory) => NewCategory = newCategory;
    }

    public class CategoryUpdated : INotification
    {
        public Category NewCategory { get; }
        public CategoryUpdated(Category newCategory) => NewCategory = newCategory;
    }

    public class CategoryDeleted : INotification
    {
        public Category DeletedCategory { get; }
        public CategoryDeleted(Category deletedCategory) => DeletedCategory = deletedCategory;
    }
}
