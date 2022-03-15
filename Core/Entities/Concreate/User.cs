using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ConCreate
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Tckn { get; set; }
        public string Image { get; set; }
        public byte[] PasswordSalt{ get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
