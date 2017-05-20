using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTest.Models.EF;

namespace MVCTest.Controllers
{
    public class 客戶資料Controller : Controller
    {
        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();
        客戶資料清單Repository repo客戶資料清單;

        public 客戶資料Controller()
        {
            repo客戶資料清單 = RepositoryHelper.Get客戶資料清單Repository(repo.UnitOfWork);
        }

        //private 客戶資料Entities db = new 客戶資料Entities();

        public ActionResult 客戶資料清單()
        {
            //return View(db.客戶資料清單.ToList());
            return View(repo客戶資料清單.All().ToList());
        }
        
        // GET: 客戶資料
        public ActionResult Index(string keyword)
        {
            //return View(db.客戶資料.Where(p=>false==p.是否已刪除).ToList());

            //var data = repo.All()//db.客戶資料
            //          .Where(p => false == p.是否已刪除).AsQueryable();

            //var data = repo.Get客戶資料列表頁所有資料(showAll:true);
            var data = repo
                      .Get客戶資料列表頁所有資料(showAll: false)
                      .Where(p=>false==p.是否已刪除).AsQueryable();

            if (!String.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.客戶名稱.Contains(keyword));
            }

            return View(data.ToList());
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Get單筆資料ById(id.Value);
            if (客戶資料 == null || 客戶資料.是否已刪除==true)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();

                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Get單筆資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        //[Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料
        {
            var 客戶資料 = repo.Find(id);

            if (TryUpdateModel(客戶資料))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Get單筆資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //客戶資料.是否已刪除 = true;
            //db.SaveChanges();

            客戶資料 客戶資料 = repo.Get單筆資料ById(id);
            repo.Delete(客戶資料);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 實作一個清單頁面，顯示欄位有「客戶名稱、聯絡人數量、銀行帳戶數量」共三個欄位
        /// </summary>
        /// <returns></returns>
        //public ActionResult 客戶資料清單()
        //{
        //    var 聯絡人數量 = (from 客戶聯絡人 in db.客戶聯絡人
        //                 from 客戶資料 in db.客戶資料
        //                 where 客戶聯絡人.客戶Id== 客戶資料.Id
        //                 select 客戶聯絡人).Count();

        //    var 銀行帳戶數量 = (from 客戶銀行資訊 in db.客戶銀行資訊
        //                  from 客戶資料 in db.客戶資料
        //                  where 客戶銀行資訊.客戶Id== 客戶資料.Id
        //                  select 客戶銀行資訊).Count();

        //    var data = (from a in db.客戶資料
        //               select new {a.客戶名稱, 聯絡人數量 , 銀行帳戶數量 }).Distinct();



        //    return View(data);
        //}



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
