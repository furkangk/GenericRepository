using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Location:IEntity
    {
        public int Id { get; set; }
        public string Block { get; set; }
        public string Floor { get; set; }
        public string Shelf { get; set; }
        public string PositionDescription { get; set; }
        public string Title{ get; set; }
    }
}
