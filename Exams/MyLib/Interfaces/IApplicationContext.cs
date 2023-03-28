using Microsoft.EntityFrameworkCore;
using MyLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<PieceOfFurniture> PieceOfFurnitures { get; set; }

        int SaveChanges();

        void Dispose();
    }
}
