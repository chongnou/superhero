using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using Superhero.Models;

namespace Superhero.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private object id;

        // GET: Superhero 
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var heroes = context.Superheroes.ToList();
            return View(heroes);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create([Bind(Include = "Id,Name,AlterEgo,PrimarySuperheroAbility,SecondarySuperheroAbility,Catchphrase")] Superheroes superhero)
        {
            if (ModelState.IsValid)
            {
                db.Superheroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superhero);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superheroes hero = db.Superheroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Superheroes hero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hero);
        }

        public ActionResult Details()
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superheroes hero = db.Superheroes.Find(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }
    }
}