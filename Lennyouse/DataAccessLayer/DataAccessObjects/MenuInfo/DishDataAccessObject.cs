using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo
{
    public class DishDataAccessObject
    {
        private RestaurantContext _context;

        public DishDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Dish> List()
        {
            return _context.Set<Dish>().ToList();
        }

        public async Task<List<Dish>> ListAsync()
        {
            return await _context.Set<Dish>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Dish dish)
        {
            _context.Dish.Add(dish);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Dish dish)
        {
            await _context.Dish.AddAsync(dish);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Dish Read(Guid id)
        {
            return _context.Dish.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Dish> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Dish>().FirstOrDefault(x => x.Id == id));



        }
        #endregion

        #region Update
        public void Update(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Dish dish)
        {
            dish.IsDeleted = true;
            Update(dish);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(Dish dish)
        {
            dish.IsDeleted = true;
            await UpdateAsync(dish);
        }
        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion 
    }
}
