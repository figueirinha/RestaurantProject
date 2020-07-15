using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo
{
    public class StaffTitleDataAccessObject
    {
        private RestaurantContext _context;
        public StaffTitleDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<StaffTitle> List()
        {
            return _context.Set<StaffTitle>().ToList();
        }
        public async Task<List<StaffTitle>> ListAsync()
        {
            return await _context.Set<StaffTitle>().ToListAsync();
        }
        #endregion 

        #region Create
        public void Create(StaffTitle staffTitle)
        {
            _context.StaffTitle.Add(staffTitle);
            _context.SaveChanges();
        }

        public async Task CreatAsync(StaffTitle staffTitle)
        {
            await _context.StaffTitle.AddAsync(staffTitle);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public StaffTitle Read(Guid id)
        {
            return _context.StaffTitle.FirstOrDefault(x => x.Id == id);
        }

        public async Task<StaffTitle> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<StaffTitle>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(StaffTitle staffTitle)
        {
            _context.Entry(staffTitle).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(StaffTitle staffTitle)
        {
            _context.Entry(staffTitle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(StaffTitle staffTitle)
        {
            staffTitle.IsDeleted = true;
            Update(staffTitle);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(StaffTitle staffTitle)
        {
            staffTitle.IsDeleted = true;
            await UpdateAsync(staffTitle);
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
