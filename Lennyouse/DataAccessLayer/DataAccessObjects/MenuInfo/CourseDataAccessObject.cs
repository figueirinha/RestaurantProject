using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo
{
    public class CourseDataAccessObject
    {
        private RestaurantContext _context;

        public CourseDataAccessObject() 
        {
            _context = new RestaurantContext();
        }

        #region List
        public List<Course> List()
        {
            return _context.Set<Course>().ToList();
        }

        public async Task<List<Course>> ListAsync()
        {
            return await _context.Set<Course>().ToListAsync();
        }
        #endregion

        #region Create
        public void Create(Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Course course)
        {
            await _context.Course.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Course Read(Guid id)
        {
            return _context.Course.FirstOrDefault(x => x.Id == id);
        }
        
        public async Task<Course> ReadAsync(Guid id)
        {
            return await Task.Run(() => _context.Set<Course>().FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region Update
        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Course course)
        {
            course.IsDeleted = true;
            Update(course);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(Course course)
        {
            course.IsDeleted = true;
            await UpdateAsync(course);
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
