using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfo
{
    public class LennyouseUserDataAccessObject
    {
        private RestaurantContext _context;
        public LennyouseUserDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<LennyouseUser> List()
        {
            return _context.Set<LennyouseUser>().ToList();
        }

        public async Task<List<LennyouseUser>> ListAsync()
        {
            return await _context.Set<LennyouseUser>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(LennyouseUser lennyouseUser)
        {
            _context.LennyouseUser.Add(lennyouseUser);
            _context.SaveChanges();
        }

        public async Task CreatAsync(LennyouseUser lennyouseUser)
        {
            await _context.LennyouseUser.AddAsync(lennyouseUser);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public LennyouseUser Read(Guid id)
        {
            return _context.LennyouseUser.FirstOrDefault(x => x.Id == id);
        }

        public async Task<LennyouseUser> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<LennyouseUser>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(LennyouseUser lennyouseUser)
        {
            _context.Entry(lennyouseUser).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(LennyouseUser lennyouseUser)
        {
            _context.Entry(lennyouseUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(LennyouseUser lennyouseUser)
        {
            
            Update(lennyouseUser);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(LennyouseUser lennyouseUser)
        {
            await UpdateAsync(lennyouseUser);
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