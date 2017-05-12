﻿using System;
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
    public class 客戶資料清單Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: 客戶資料清單
        public ActionResult Index()
        {
            return View(db.客戶資料清單.ToList());
        }

        // GET: 客戶資料清單/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料清單 客戶資料清單 = db.客戶資料清單.Find(id);
            if (客戶資料清單 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料清單);
        }

        // GET: 客戶資料清單/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料清單/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "客戶名稱,聯絡人數量,銀行帳戶數量,ID")] 客戶資料清單 客戶資料清單)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料清單.Add(客戶資料清單);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料清單);
        }

        // GET: 客戶資料清單/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料清單 客戶資料清單 = db.客戶資料清單.Find(id);
            if (客戶資料清單 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料清單);
        }

        // POST: 客戶資料清單/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "客戶名稱,聯絡人數量,銀行帳戶數量,ID")] 客戶資料清單 客戶資料清單)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料清單).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料清單);
        }

        // GET: 客戶資料清單/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料清單 客戶資料清單 = db.客戶資料清單.Find(id);
            if (客戶資料清單 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料清單);
        }

        // POST: 客戶資料清單/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            客戶資料清單 客戶資料清單 = db.客戶資料清單.Find(id);
            db.客戶資料清單.Remove(客戶資料清單);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
