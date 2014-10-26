using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeraFood.Models.Repositories;

namespace SeraFood.Models.UnitOfWork
{
   public interface IUnitOfWork
    {
        IGenericRepository<Product> Products { get; }

        IGenericRepository<Brand> Brand { get; }
        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Review> Reviews { get; }

        void Save(); //Commit
    }
}
