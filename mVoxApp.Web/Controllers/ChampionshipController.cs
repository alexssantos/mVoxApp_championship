﻿using mVoxApp.Web.App_Data.Repository;
using mVoxApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mVoxApp.Web.Controllers
{
    public class ChampionshipController : Controller
    {
        // GET: Championship
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registreds()
        {
            Repository teamRepository = new Repository();
            List<Team> ListaTodos = teamRepository.GetTeams();
            var a = ListaTodos.OrderBy(x => x.name);
            return View(a);
        }

        // GET: Championship/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Championship/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Championship/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Championship/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Championship/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Championship/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Championship/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
