using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using TestApi.Domain.Attributes;
using TestApi.Domain.Core;

namespace TestApi.Domain.Models;

[EntityType]
public class Product : EntityBase
{
    [StringLength(100)] public string? Title { get; set; }

    public int Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<ProductProperty> Properties { get; set; } = new Collection<ProductProperty>();
}