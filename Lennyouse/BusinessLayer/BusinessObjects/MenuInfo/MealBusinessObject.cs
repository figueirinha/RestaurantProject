using Recodme.RD.Lennyouse.BusinessLayer.Base;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.Data.MenuInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.MenuInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.MenuInfo
{
    public class MealBusinessObject : BaseBusinessObject
    {
        private MealDataAccessObject _dao;
        public MealBusinessObject()
        {
            _dao = new MealDataAccessObject();
        }

        #region List
        public OperationResult<List<Meal>> List()
        {
            return ExecuteOperation(() => _dao.List());
        }
        public async Task<OperationResult<List<Meal>>> ListAsync()
        {
            return await ExecuteOperationAsync(() => _dao.ListAsync());
        }
        #endregion

        #region Create
        public OperationResult Create(Meal item)
        {
            try
            {
                
                _dao.Create(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(Meal item)
        {
            try
            {
                
                await _dao.CreateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<Meal> Read(Guid id)
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
                    return new OperationResult<Meal>() { Success = true, Result = res };
                }
                  

            }
            catch (Exception e)
            {
                return new OperationResult<Meal>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<Meal>> ReadAsync(Guid id)
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
                    return new OperationResult<Meal>() { Success = true, Result = res };
                }                   

            }
            catch (Exception e)
            {
                return new OperationResult<Meal>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(Meal item)
        {
            try
            {
               
                _dao.Update(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(Meal item)
        {
            try
            {
               
                await _dao.UpdateAsync(item);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(Meal item)
        {
            try
            {
                
                _dao.Delete(item);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(Meal item)
        {
            try
            {
               
                await _dao.DeleteAsync(item);
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
