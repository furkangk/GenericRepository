using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
     public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public bool Hardcover { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public string PrintDate { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string PrintCount { get; set; }
        public int LocationId { get; set; }
    }
}
