using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SeraFood.Models.Repositories;

namespace SeraFood.Models.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    
    {
        SeraFoodCtx _context;
        public UnitOfWork()
        {
            _context = new SeraFoodCtx();
        }
        private IGenericRepository<ApplyJob> _ApplyJobs;
        public Repositories.IGenericRepository<ApplyJob> ApplyJobs
        {
            get
            {
                if (_ApplyJobs == null)
                {
                    return new EfGenericRepository<ApplyJob>(_context);
                }
                return _ApplyJobs;
            }
        }
        private IGenericRepository<Job> _Jobs;
        public Repositories.IGenericRepository<Job> Jobs
        {
            get
            {
                if (_Jobs == null)
                {
                    return new EfGenericRepository<Job>(_context);
                }
                return _Jobs;
            }
        }
        private IGenericRepository<Product> _Producs;
        public Repositories.IGenericRepository<Product> Products
        {
            get
            {
                if (_Producs == null)
                {
                    return new EfGenericRepository<Product>(_context);
                }
                return _Producs;
            }
        }

        public IGenericRepository<Brand>  _Brands;
        public Repositories.IGenericRepository<Brand> Brand
        {
            get
            {
                if (_Brands == null)
                {
                    return new EfGenericRepository<Brand>(_context);
                }
                return _Brands;
            }
        }

        private IGenericRepository<Review> _Reviews;
        public Repositories.IGenericRepository<Review> Reviews
        {
            get
            {
                if (_Reviews == null)
                {
                    return new EfGenericRepository<Review>(_context);
                }
                return _Reviews;
            }
        }

        public IGenericRepository<Category> _Categories;
        public Repositories.IGenericRepository<Category> Categories
        {
            get
            {
                if (_Categories == null)
                {
                    return new EfGenericRepository<Category>(_context);
                }
                return _Categories;
            }
        }

        private IGenericRepository<ApplicationUser> _users;
        public Repositories.IGenericRepository<ApplicationUser> Users
        {
            get
            {
                if (_users == null)
                {
                    return new EfGenericRepository<ApplicationUser>(_context);
                }
                return _users;
            }
        }

        private IGenericRepository<IdentityRole> _roles;
        public Repositories.IGenericRepository<IdentityRole> Roles
        {
            get
            {
                if (_roles == null)
                {
                    return new EfGenericRepository<IdentityRole>(_context);
                }
                return _roles;
            }
        }
      

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }





      
    }
}