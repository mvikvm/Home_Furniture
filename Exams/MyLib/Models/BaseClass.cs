using MyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Models
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract void Update(BaseClass obj);
    }
}
