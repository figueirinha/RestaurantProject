using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo
{
    public class RestaurantDataAccessObject
    {
        private RestaurantContext _context;
        public RestaurantDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Restaurant> List()
        {
            return _context.Set<Restaurant>().ToList();
        }
        public async Task<List<Restaurant>> ListAsync()
        {
            return await _context.Set<Restaurant>().ToListAsync();
        }
        #endregion 

        #region Create
        public void Create(Restaurant restaurant)
        {
            _context.Restaurant.Add(restaurant);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Restaurant restaurant)
        {
            await _context.Restaurant.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Restaurant Read(Guid id)
        {
            return _context.Restaurant.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Restaurant> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Restaurant>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            Update(restaurant);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            await UpdateAsync(restaurant);
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

