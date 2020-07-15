using Recodme.RD.Lennyouse.BusinessLayer.Base;
using Recodme.RD.Lennyouse.BusinessLayer.OperationResults;
using Recodme.RD.Lennyouse.Data.RestaurantInfo;
using Recodme.RD.Lennyouse.Data.UserInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.RestaurantInfo;
using Recodme.RD.Lennyouse.DataAccessLayer.DataAccessObjects.UserInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.RD.Lennyouse.BusinessLayer.BusinessObjects.UserInfo
{
    public class LennyouseUserBusinessObject : BaseBusinessObject
    {
        private LennyouseUserDataAccessObject _dao;
        public LennyouseUserBusinessObject()
        {
            _dao = new LennyouseUserDataAccessObject();
        }

        #region List
        public OperationResult<List<LennyouseUser>> List()
        {
            return ExecuteOperation(() => _dao.List());
        }
        public async Task<OperationResult<List<LennyouseUser>>> ListAsync()
        {
            return await ExecuteOperationAsync(() => _dao.ListAsync());
        }
        #endregion

        #region Create
        public OperationResult Create(LennyouseUser LennyouseUser)
        {
            try
            {
              
                _dao.Create(LennyouseUser);
                

                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> CreateAsync(LennyouseUser LennyouseUser)
        {
            try
            {
                
                await _dao.CreatAsync(LennyouseUser);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read
        public OperationResult<LennyouseUser> Read(Guid id)
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
                    return new OperationResult<LennyouseUser>() { Success = true, Result = res };
                }
                 

            }
            catch (Exception e)
            {
                return new OperationResult<LennyouseUser>() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult<LennyouseUser>> ReadAsync(Guid id)
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
                    return new OperationResult<LennyouseUser>() { Success = true, Result = res };
                }
                   

            }
            catch (Exception e)
            {
                return new OperationResult<LennyouseUser>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public OperationResult Update(LennyouseUser LennyouseUser)
        {
            try
            {
                
                _dao.Update(LennyouseUser);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> UpdateAsync(LennyouseUser LennyouseUser)
        {
            try
            {
                
                await _dao.UpdateAsync(LennyouseUser);
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public OperationResult Delete(LennyouseUser LennyouseUser)
        {
            try
            {
                
                _dao.Delete(LennyouseUser);
                return new OperationResult() { Success = true };

            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        public async Task<OperationResult> DeleteAsync(LennyouseUser LennyouseUser)
        {
            try
            {
                
                await _dao.DeleteAsync(LennyouseUser);
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



