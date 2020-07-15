using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo
{
    public class DietaryRestrictionDataAccessObject
    {
        private RestaurantContext _context;

        public DietaryRestrictionDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<DietaryRestriction> List()
        {
            return _context.Set<DietaryRestriction>().ToList();
        }

        public async Task<List<DietaryRestriction>> ListAsync()
        {
            return await _context.Set<DietaryRestriction>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(DietaryRestriction dietaryRestriction)
        {
            _context.DietaryRestriction.Add(dietaryRestriction);
            _context.SaveChanges();
        }

        public async Task CreateAsync(DietaryRestriction dietaryRestriction)
        {
            await _context.DietaryRestriction.AddAsync(dietaryRestriction);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public DietaryRestriction Read(Guid id)
        {
            return _context.DietaryRestriction.FirstOrDefault(x => x.Id == id);
        }

        public async Task<DietaryRestriction> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<DietaryRestriction>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(DietaryRestriction dietaryRestriction)
        {
            _context.Entry(dietaryRestriction).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(DietaryRestriction dietaryRestriction)
        {
            _context.Entry(dietaryRestriction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(DietaryRestriction dietaryRestriction)
        {
            dietaryRestriction.IsDeleted = true;
            Update(dietaryRestriction);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(DietaryRestriction dietaryRestriction)
        {
            dietaryRestriction.IsDeleted = true;
            await UpdateAsync(dietaryRestriction);
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
