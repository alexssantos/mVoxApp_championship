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
        ManagerKeygroup _mngerKey;

        // GET: Championship
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Tables()
        {
            _mnger = new Manager();
            ViewData["table1"] = _mnger.GetAll();
            ViewData["table2"] = _mnger.GetAll();

            //Keygroup
            _mngerKey = new ManagerKeygroup();
            List<KeyGroup> _listKeygroups = new List<KeyGroup>();
            _listKeygroups = _mngerKey.GetAll().OrderBy(x=>x.id).ToList();

            //pegar cada OBJETO da lista
            for (int i = 0; i < _listKeygroups.Count; i++)
            {
                ViewData[$"keygroup{i+1}"] = _mngerKey.GetAll();
            }

            //pegar parametro NAME de cada OBJETO dentro da lista
            int count = 1;
            foreach (var item in _listKeygroups)
            {                
                ViewData[$"keygroupname{count}"] = item.name;
                count++;
            }

            ViewData["keygroupAll"] = _listKeygroups;          

            //Text test
            ViewBag.TableTitle = "ViewBab-Title";

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

                return View("Index");
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
