using Recodme.RD.Lennyouse.BusinessLayer.Base;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.RestaurantInfo
{
    public class BookingBusinessObject : BaseBusinessObject
    {
        private BookingDataAccessObject _dao;
        public BookingBusinessObject()
        {
            _dao = new BookingDataAccessObject();
        }

        #region List
        public OperationResult<List<Booking>> List()
        {
            return ExecuteOperation(() => _dao.List());
        }
        public async Task<OperationResult<List<Booking>>> ListAsync()
        {
            return await ExecuteOperationAsync(() => _dao.ListAsync());
        }
        #endregion

        #region Create
        public OperationResult Create(Booking booking)
        {
            try
            {
                
                _dao.Create(booking);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(Booking booking)
        {
            try
            {
                
                await _dao.CreatAsync(booking);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Booking> Read(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = _dao.Read(id);
                    transactionScope.Complete();
                    return new OperationResult<Booking>() { Success = true, Result = res };
                }
                    

            }
            catch (Exception e)
            {
                return new OperationResult<Booking>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<Booking>> ReadAsync(Guid id)
        {
            try
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromSeconds(30)
                };
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var res = await _dao.ReadAsync(id);
                    transactionScope.Complete();
                    return new OperationResult<Booking>() { Success = true, Result = res };
                }
                   

            }
            catch (Exception e)
            {
                return new OperationResult<Booking>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Booking booking)
        {
            try
            {
                
                _dao.Update(booking);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(Booking booking)
        {
            try
            {
                
                await _dao.UpdateAsync(booking);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Booking booking)
        {
            try
            {
                
                _dao.Delete(booking);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Booking booking)
        {
            try
            {
                
                await _dao.DeleteAsync(booking);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public OperationResult Delete(Guid id)
        {
            try
            {
                
                _dao.Delete(id);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                
                await _dao.DeleteAsync(id);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}



