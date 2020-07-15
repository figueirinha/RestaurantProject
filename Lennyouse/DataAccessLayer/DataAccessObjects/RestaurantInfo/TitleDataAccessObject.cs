using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo
{
    public class TitleDataAccessObject
    {
        private RestaurantContext _context;
        public TitleDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Title> List()
        {
            return _context.Set<Title>().ToList();
        }
        public async Task<List<Title>> ListAsync()
        {
            return await _context.Set<Title>().ToListAsync();
        }
        #endregion  

        #region Create
        public void Create(Title title)
        {
            _context.Title.Add(title);
            _context.SaveChanges();
        }

        public async Task CreatAsync(Title title)
        {
            await _context.Title.AddAsync(title);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Title Read(Guid id)
        {
            return _context.Title.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Title> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Title>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(Title title)
        {
            _context.Entry(title).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Title title)
        {
            _context.Entry(title).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Title title)
        {
            title.IsDeleted = true;
            Update(title);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Title title)
        {
            title.IsDeleted = true;
            await UpdateAsync(title);
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
