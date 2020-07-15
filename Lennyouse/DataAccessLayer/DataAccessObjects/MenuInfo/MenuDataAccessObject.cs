using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo
{
    public class MenuDataAccessObject
    {
        private RestaurantContext _context;
        public MenuDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Menu> List()
        {
            return _context.Set<Menu>().ToList();
        }

        public async Task<List<Menu>> ListAsync()
        {
            return await _context.Set<Menu>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Menu menu)
        {
            _context.Menu.Add(menu);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Menu menu)
        {
            await _context.Menu.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Menu Read(Guid id)
        {
            return _context.Menu.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Menu> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Menu>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Menu menu)
        {
            menu.IsDeleted = true;
            Update(menu);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(Menu menu)
        {
            menu.IsDeleted = true;
            await UpdateAsync(menu);
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
