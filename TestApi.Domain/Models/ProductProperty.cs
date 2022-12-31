using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestApi.Domain.Core;

namespace TestApi.Domain.Models;

public class ProductProperty : EntityBase
{
    public int ProductId { get; set; }
    
    [JsonIgnore]
    public Product? Product { get; set; }

    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(400)]
    public string? Description { get; set; }
}
