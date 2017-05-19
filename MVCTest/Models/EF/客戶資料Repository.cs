using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;


namespace MVCTest.Models.EF
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Get單筆資料ById(int id)
        {
            return this.All().FirstOrDefault(c=>c.Id==id);
        }

        public IQueryable<客戶資料> Get客戶資料列表頁所有資料(bool showAll = false)
        {
            IQueryable<客戶資料> all = this.All();
            if (showAll)
            {
                all = base.All();
            }
            return all
                .OrderBy(c=>c.Id).Take(10);
                
        }

        public void update(客戶資料 客戶資料)
        {
            this.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}