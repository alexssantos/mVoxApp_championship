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
        ManagerTeamRepository _mnger;
        ManagerKeygroupRepository _mngerKey;

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
            //Teams     --------------------------------
            _mnger = new ManagerTeamRepository();
            List<TeamModel> _listTeams = _mnger.GetAll();
            

            //Keygroup  --------------------------------
            _mngerKey = new ManagerKeygroupRepository();
            List<KeyGroupModel> _listKeygroups = _mngerKey.GetAll().OrderBy(x=>x.Id).ToList();

            //--------- VIEWDATA ----------------//
            #region ViewData's

            ViewData["keygroupAll"] = _listKeygroups;
            ViewData["table1"] = _listTeams;
            ViewData["table2"] = _listTeams;

            ViewBag.TableTitle = "ViewBab-Title";

            //ViewData DINAMIC // [TeamKeyGroup1] (List<Team>)  // 
            for (int i = 1; i <= _listKeygroups.Count(); i++)
            {
                ViewData[$"TeamsKeyGroup{i}"] = _listTeams.FindAll(x => x.KeyGroup == i).ToList();
            }
            //ViewData DINAMIC // [KeyGroup1] (List<KeyGrupo>)  // ----- pegar cada OBJETO da lista
            for (int i = 1; i < _listKeygroups.Count; i++)
            {
                ViewData[$"KeyGroup{i}"] = _listKeygroups.OrderBy(x=>x.Id);

            }
            //ViewData DINAMIC // [KeyGroupName1] (Strings)     // ---- pegar parametro NAME de cada OBJETO dentro da lista
            int count = 1; 
            foreach (var item in _listKeygroups)
            {                
                ViewData[$"KeyGroupName{count}"] = item.Name;
                count++;
            }

            #endregion

            return View("Tables", _mnger.GetAll());
        }

        public ActionResult WonGame(int id)
        {
            try
            {
                _mnger = new ManagerTeamRepository();
                _mngerKey = new ManagerKeygroupRepository();

                TeamModel _team = _mnger.GetByID(id);
                int nextKeyGroup = _team.KeyGroup + 1;

                //if (!_mngerKey.KeyGroupFull(nextKeyGroup))
                //{
                //    _team.KeyGroup = _team.KeyGroup + 1;
                //    //_team.allKeyGroups.Clear();
                //    //for (int i = 1; i <= _team.KeyGroup; i++)
                //    //{                        
                //    //    _team.allKeyGroups.Add(i);
                //    //}
                //    _mnger.Update(_team);
                //}
                //else
                //{
                //    ViewBag.KeyGroupFull = "Key Group CHEIA!";
                //}                

                
                return RedirectToAction("Tables");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Championship/Details/5
        public ActionResult Details(int id)
        {
            _mnger = new ManagerTeamRepository();
            TeamModel team = _mnger.GetByID(id);
            return View(team);
        }
        
        // GET: Championship/Details/5
        public ActionResult DeleteFromKeyGroup(int id)
        {
            try
            {
                _mnger = new ManagerTeamRepository();
                TeamModel _team = _mnger.GetByID(id);
                _team.KeyGroup = 1;

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
            _mnger = new ManagerTeamRepository();            
            List<TeamModel> listReturn = _mnger.GetAll();
            ViewData["TeamList"] = listReturn;

            _mngerKey = new ManagerKeygroupRepository();


            return View("Register");
        }

        // POST: Championship/Create
        [HttpPost]
        public ActionResult Create(TeamModel _team)
        {
            try
            {
                _mnger = new ManagerTeamRepository();
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
            _mnger = new ManagerTeamRepository();
            TeamModel retorno = _mnger.GetByID(id);
            return View("Edit", retorno);
        }

        // POST: Championship/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeamModel _team)
        {
            try
            {
                _mnger = new ManagerTeamRepository();
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
            _mnger = new ManagerTeamRepository();
            TeamModel retorno = _mnger.GetByID(id);
            return View("Delete", retorno);            
        }

        // POST: Championship/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TeamModel _team)
        {
            try
            {
                _mnger = new ManagerTeamRepository();
                _mnger.Delete(id);
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NotCreated()
        {
            return View("NotCreated");
        }
    }
}
