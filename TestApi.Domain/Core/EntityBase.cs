using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Core;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime AddDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
