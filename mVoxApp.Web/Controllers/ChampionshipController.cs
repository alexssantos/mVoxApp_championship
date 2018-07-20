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
        ManagerTeamStaticRepository _mngerTeam;
        ManagerKeyGroupStaticRepository _mngerKey;


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
            _mngerTeam = new ManagerTeamStaticRepository();
            List<TeamModel> _listTeams = _mngerTeam.GetAll().OrderBy(x => x.Id).ToList();            

            //Keygroup  
            _mngerKey = new ManagerKeyGroupStaticRepository();
            List<KeyGroupModel> _listKeygroups = _mngerKey.GetAll().OrderBy(x=>x.Id).ToList();        

            /*      +----------------------------------+
                    |              VIEWDATA            |
                    +----------------------------------+
            */                        
            for (int i = 1; i <= _listKeygroups.Count; i++)
            {
                //DETALHES DOS GRUPOS - TABELA PRINCIPAL TOPO
                // NAME: "TeamByKeyGroup1" //  OBJECT: List<Team>    //  TYPE: ViewData 
                ViewData[$"TeamsByKeyGroup{i}"] = _listTeams.FindAll(x => x.KeyGroup == (i-1)).ToList();

                //Count TotalTeams -> KeyGroup                
                int qtdd = _mngerTeam.CountByKeyGroup(i - 1);
                _listKeygroups[i - 1].TotalTeams = qtdd;

                //NOMES DAS TABELAS
                // NAME: "KeyGroupName1" //  OBJECT: Strings    //  TYPE: ViewData      ** pegar parametro NAME de cada OBJETO dentro da lista
                ViewData[$"KeyGroupName{i}"] = _listKeygroups[i-1].Name;
            }

            ViewData["teams-all"] = _listTeams;
            ViewData[$"keygroups-all"] = _listKeygroups;
            ViewData[$"KeyGroups"] = _listKeygroups;                                    

            return View("Tables", _listTeams);
        }

        public ActionResult WonGame(int id)
        {
            try
            {
                _mngerTeam = new ManagerTeamStaticRepository();
                _mngerKey = new ManagerKeyGroupStaticRepository();

                TeamModel _team = _mngerTeam.GetByID(id);
                int nextKeyGroup = _team.KeyGroup + 1;

                if (!_mngerKey.KeyGroupFull(nextKeyGroup))
                {
                    _team.KeyGroup = _team.KeyGroup + 1;                    
                    _mngerTeam.Update(_team);
                }
                else
                {
                    ViewBag.alert = "Alert";
                }
                ViewBag.alert2 = "Alert2";

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
            _mngerTeam = new ManagerTeamStaticRepository();
            TeamModel team = _mngerTeam.GetByID(id);
            return View(team);
        }
        
        // GET: Championship/Details/5
        public ActionResult DeleteFromKeyGroup(int id)
        {
            try
            {
                _mngerTeam = new ManagerTeamStaticRepository();
                TeamModel _team = _mngerTeam.GetByID(id);
                _team.KeyGroup = 0;

                _mngerTeam.Update(_team);
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
            _mngerTeam = new ManagerTeamStaticRepository();            
            List<TeamModel> listReturn = _mngerTeam.GetAll().OrderBy(x => x.Id).ToList();
            ViewData["TeamList"] = listReturn;
            
            return View("Register");
        }

        // POST: Championship/Create
        [HttpPost]
        public ActionResult Create(TeamModel _team)
        {
            try
            {
                _mngerTeam = new ManagerTeamStaticRepository();
                _mngerTeam.Create(_team);
                
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
            _mngerTeam = new ManagerTeamStaticRepository();
            TeamModel retorno = _mngerTeam.GetByID(id);
            return View("Edit", retorno);
        }

        // POST: Championship/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeamModel _team)
        {
            try
            {
                _mngerTeam = new ManagerTeamStaticRepository();               
                _mngerTeam.Update(_team);
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
            _mngerTeam = new ManagerTeamStaticRepository();
            TeamModel retorno = _mngerTeam.GetByID(id);
            return View("Delete", retorno);            
        }

        // POST: Championship/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TeamModel _team)
        {
            try
            {
                _mngerTeam = new ManagerTeamStaticRepository();
                _mngerTeam.Delete(id);
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Championship/Search
        public ActionResult Search()
        {           
            return View("Search");
        }

        // POST: Championship/Search
        [HttpPost]
        public ActionResult Search(TeamModel busca)
        {
            try
            {
                _mngerTeam = new ManagerTeamStaticRepository();
                List<TeamModel> ListaBuscada = _mngerTeam.GetByName(busca.Name);
                ViewData["SearchPView"] = ListaBuscada;

                return View("Search");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult NotCreated()
        {
            return View("NotCreated");
        }

    }
}
