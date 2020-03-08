using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.ViewModel;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
			try
			{
				List<ListarUserViewModel> lst = null;
				using (cursomvcEntities db = new cursomvcEntities())
				{
					 lst = (from d in db.user
						   where d.idStates==1
						   orderby d.email
						   select new ListarUserViewModel
						   {
							   Email= d.email,
							   Id =d.id,
							   Edad = d.edad
						   }).ToList();

					return View(lst);
				}
			}
			catch(Exception ex)
			{
				return Content("hay un error");
			}    
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursomvcEntities())
            {
                user oUser = new user();
                oUser.email = model.Email;
                oUser.idStates = 1;
                oUser.password = model.Password;
                oUser.edad = model.Edad;

                db.user.Add(oUser);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/user/"));
        }

        
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new cursomvcEntities())
            {
                var oUser = db.user.Find(id);
                model.Id = oUser.id;
                model.Email = oUser.email;
                model.Edad = (int)oUser.edad;


            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var db = new cursomvcEntities())
            {
                var oUser = db.user.Find(id);
                oUser.idStates = 0;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        
            return Content("1");
        }


    }
}