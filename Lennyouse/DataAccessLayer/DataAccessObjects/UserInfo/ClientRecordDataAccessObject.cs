using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfo
{
    public class ClientRecordDataAccessObject
    {
        private RestaurantContext _context;
        public ClientRecordDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<ClientRecord> List()
        {
            return _context.Set<ClientRecord>().ToList();
        }

        public async Task<List<ClientRecord>> ListAsync()
        {
            return await _context.Set<ClientRecord>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(ClientRecord clientRecord)
        {
            _context.ClientRecord.Add(clientRecord);
            _context.SaveChanges();
        }

        public async Task CreatAsync(ClientRecord clientRecord)
        {
            await _context.ClientRecord.AddAsync(clientRecord);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public ClientRecord Read(Guid id)
        {
            return _context.ClientRecord.FirstOrDefault(x => x.Id == id);
        }

        public async Task<ClientRecord> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<ClientRecord>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(ClientRecord clientRecord)
        {
            _context.Entry(clientRecord).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(ClientRecord clientRecord)
        {
            _context.Entry(clientRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(ClientRecord clientRecord)
        {
            clientRecord.IsDeleted = true;
            Update(clientRecord);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(ClientRecord clientRecord)
        {
            clientRecord.IsDeleted = true;
            await UpdateAsync(clientRecord);
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