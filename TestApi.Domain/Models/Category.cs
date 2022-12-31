using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestApi.Domain.Core;

namespace TestApi.Domain.Models;

public class Category : EntityBase
{
    [StringLength(100)]
    public string? Title { get; set; }

    public int? ParentId { get; set; }
    
    [JsonIgnore]
    public Category? Parent { get; set; }

    public virtual ICollection<Category> Childs { get; set; } = new Collection<Category>();
}
