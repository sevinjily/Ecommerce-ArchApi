using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductPhoto:BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
