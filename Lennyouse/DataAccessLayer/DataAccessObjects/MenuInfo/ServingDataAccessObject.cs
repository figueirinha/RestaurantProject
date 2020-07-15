using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo
{
    public class ServingDataAccessObject
    {
        private RestaurantContext _context;
        public ServingDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Serving> List()
        {
            return _context.Set<Serving>().ToList();
        }

        public async Task<List<Serving>> ListAsync()
        {
            return await _context.Set<Serving>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Serving serving)
        {
            _context.Serving.Add(serving);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Serving serving)
        {
            await _context.Serving.AddAsync(serving);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Serving Read(Guid id)
        {
            return _context.Serving.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Serving> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Serving>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(Serving serving)
        {
            _context.Entry(serving).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Serving serving)
        {
            _context.Entry(serving).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Serving serving)
        {
            serving.IsDeleted = true;
            Update(serving);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Serving serving)
        {
            serving.IsDeleted = true;
            await UpdateAsync(serving);
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
