using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo
{
    public class MealDataAccessObject
    {
        private RestaurantContext _context;
        public MealDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Meal> List()
        {
            return _context.Set<Meal>().ToList();
        }

        public async Task<List<Meal>> ListAsync()
        {
            return await _context.Set<Meal>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Meal meal)
        {
            _context.Meal.Add(meal);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Meal meal)
        {
            await _context.Meal.AddAsync(meal);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Meal Read(Guid id)
        {
            return _context.Meal.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Meal> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Meal>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Meal meal)
        {
            meal.IsDeleted = true;
            Update(meal);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(Meal meal)
        {
            meal.IsDeleted = true;
            await UpdateAsync(meal);
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
