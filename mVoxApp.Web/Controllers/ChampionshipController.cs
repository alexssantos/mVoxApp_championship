using mVoxApp.Web.App_Data.Repository;
using mVoxApp.Web.Controllers.BLL;
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
        Manager _mnger;

        // GET: Championship
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tables()
        {
            _mnger = new Manager();
            List<string> _tablesChamp = new List<string>();
               

            foreach (var iTableChamp in _tablesChamp)
            {
                int numb = iTableChamp.IndexOf(iTableChamp) +1;
                ViewData[$"iTable{numb}"] = _mnger.GetAll();
            };

            ViewData["table1"] = _mnger.GetAll();
            ViewData["table2"] = _mnger.GetAll();
            ViewData["table3"] = _mnger.GetAll();
            ViewData["table4"] = _mnger.GetAll();

            return View("Tables", _mnger.GetAll());
        }

        // GET: Championship/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Championship/Create
        public ActionResult Create()
        {
            _mnger = new Manager();
            List<Team> listReturn = _mnger.GetAll();
            ViewData["TeamList"] = listReturn;

            return View("Register");
        }

        // POST: Championship/Create
        [HttpPost]
        public ActionResult Create(Team _team)
        {
            try
            {
                _mnger = new Manager();
                _mnger.Create(_team);
                
                //ViewBag.Msg = "Criado Com Sucesso";

                return RedirectToAction("Register");
            }
            catch
            {
                //ViewBag.Msg = "Erro ao Tentar Criar";
                return View("Error");
            }
        }

        // GET: Championship/Edit/5
        public ActionResult Edit(int id)
        {
            _mnger = new Manager();
            Team retorno = _mnger.GetByID(id);
            return View("Edit", retorno);
        }

        // POST: Championship/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Team _team)
        {
            try
            {
                _mnger = new Manager();
                _mnger.Update(_team);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Championship/Delete/5
        public ActionResult Delete(int id)
        {
            _mnger = new Manager();
            Team retorno = _mnger.GetByID(id);
            return View("Delete", retorno);            
        }

        // POST: Championship/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Team _team)
        {
            try
            {
                _mnger = new Manager();
                _mnger.Delete(id);
                return RedirectToAction("Register");
            }
            catch
            {
                return View();
            }
        }
    }
}
