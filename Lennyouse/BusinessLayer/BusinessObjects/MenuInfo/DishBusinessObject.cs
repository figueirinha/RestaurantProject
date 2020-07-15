using Recodme.RD.Lennyouse.BusinessLayer.Base;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo
{
    public class DishBusinessObject : BaseBusinessObject
    {
        private DishDataAccessObject _dao;
        public DishBusinessObject()
        {
            _dao = new DishDataAccessObject();
        }

        #region List
        public OperationResult<List<Dish>> List()
        {
            return ExecuteOperation(() => _dao.List());
        }
        public async Task<OperationResult<List<Dish>>> ListAsync()
        {
            return await ExecuteOperationAsync(() => _dao.ListAsync());
        }
        #endregion

        #region Create
        public OperationResult Create(Dish dish)
        {
            try
            {
                
                _dao.Create(dish);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(Dish dish)
        {
            try
            {
                
                await _dao.CreateAsync(dish);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Dish> Read(Guid id)
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
                    return new OperationResult<Dish>() { Success = true, Result = res };
                }
                   

            }
            catch (Exception e)
            {
                return new OperationResult<Dish>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<Dish>> ReadAsync(Guid id)
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
                    return new OperationResult<Dish>() { Success = true, Result = res };
                }
                    

            }
            catch (Exception e)
            {
                return new OperationResult<Dish>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Dish dish)
        {
            try
            {
                
                _dao.Update(dish);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(Dish dish)
        {
            try
            {
               
                await _dao.UpdateAsync(dish);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Dish dish)
        {
            try
            {
               
                _dao.Delete(dish);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Dish dish)
        {
            try
            {
               
                await _dao.DeleteAsync(dish);
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
