using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCTest.Models.EF
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{

	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}