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
            //Teams
            _mnger = new Manager();
            

            //Keygroup --------------------------------
            _mngerKey = new ManagerKeygroup();
            List<KeyGroup> _listKeygroups = _mngerKey.GetAll().OrderBy(x=>x.id).ToList();

            //ViewData -----------------------------------
            ViewData["keygroupAll"] = _listKeygroups;
            ViewData["table1"] = _mnger.GetAll();
            ViewData["table2"] = _mnger.GetAll();

            ViewBag.TableTitle = "ViewBab-Title";

            //ViewData Dinamic [TeamKeyGroup1] (List<Team>)
            for (int i = 1; i <= _mngerKey.GetAll().Count(); i++)
            {
                ViewData[$"TeamsKeyGroup{i}"] = _mnger.GetAll().FindAll(x => x.keyGroup == i).ToList();
            }
            //ViewData Dinamic [KeyGroup1] (List<KeyGrupo>) ----- pegar cada OBJETO da lista
            for (int i = 1; i < _listKeygroups.Count; i++)
            {
                ViewData[$"KeyGroup{i}"] = _mngerKey.GetAll().OrderBy(x=>x.id);
            }
            //ViewData Dinamic [KeyGroupName1] (Strings)  ---- pegar parametro NAME de cada OBJETO dentro da lista
            int count = 1; 
            foreach (var item in _listKeygroups)
            {                
                ViewData[$"KeyGroupName{count}"] = item.name;
                count++;
            }            

            return View("Tables", _mnger.GetAll());
        }

        // GET: Championship/Details/5
        public ActionResult Details(int id)
        {
            _mnger = new Manager();
            Team team = _mnger.GetByID(id);
            return View(team);
        }
        
        // GET: Championship/Details/5
        public ActionResult ChangeKeyGroup(int id)
        {
            try
            {
                _mnger = new Manager();
                Team _team = _mnger.GetByID(id);
                _team.keyGroup = 1;

                _mnger.Update(_team);
                return RedirectToAction("Tables");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Championship/Create
        public ActionResult Create()
        {
            _mnger = new Manager();            
            List<Team> listReturn = _mnger.GetAll();
            ViewData["TeamList"] = listReturn;

            _mngerKey = new ManagerKeygroup();


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
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}
