using Microsoft.EntityFrameworkCore;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo
{
    public class BookingDataAccessObject
    {

        private RestaurantContext _context;

        public BookingDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Booking> List()
        {
            return _context.Set<Booking>().ToList();
        }

        public async Task<List<Booking>> ListAsync()
        {
            return await _context.Set<Booking>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Booking booking)
        {
            _context.Booking.Add(booking);
            _context.SaveChanges();
        }

        public async Task CreatAsync(Booking booking)
        {
            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Booking Read(Guid id)
        {
            return _context.Booking.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Booking> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Booking>().FirstOrDefault(x => x.Id == id));



        }
        #endregion

        #region Update
        public void Update(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Booking booking)
        {
            booking.IsDeleted = true;
            Update(booking);
        }
        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }
        public async Task DeleteAsync(Booking booking)
        {
            booking.IsDeleted = true;
            await UpdateAsync(booking);
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
