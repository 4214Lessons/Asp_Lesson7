using Lesson7.EfCore.Data;
using Lesson7.EfCore.Data.Repositories;
using Lesson7.EfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lesson7.EfCore.Controllers
{
    public class CarController : Controller
    {
        //private readonly AppDbContext context;

        //public CarController(AppDbContext context)
        //{
        //    this.context = context;
        //}

        private readonly IRepository<Car> repository;

        public CarController(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            // with Context
            //var cars = await context.Cars.ToListAsync();

            try
            {
                var cars = await repository.GetAllAsync();
                return View(cars);
            }
            catch (Exception)
            {
                return View("error.cshtml");
            }

        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();   
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            // with Context
            //context.Cars.Add(car);
            //await context.SaveChangesAsync();

            try
            {
                repository.Add(car);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("error.cshtml");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            // with Context
            //var car = context.Cars.FirstOrDefault(c => c.Id == id);
            //context.Cars.Remove(car);
            //await context.SaveChangesAsync();

            try
            {
                repository.Delete(id);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View("error.cshtml");
            }
        

            return RedirectToAction("Index");
        }
    }
}
