using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_Students2.Models;
using CRUD_Students2.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace CRUD_Students2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
private readonly AplicationDbContext _dbContext;
    public HomeController(ILogger<HomeController> logger, AplicationDbContext context)
    {
        _logger = logger;
        _dbContext = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {

        Student estudiante = new Student();
        estudiante.Id = new Guid();
estudiante.Nombre="Ricardo";
estudiante.Edad=34;
estudiante.Carrera="Fisica";
estudiante.Sexo="Masculino";

this._dbContext.Students.Add(estudiante);
this._dbContext.SaveChanges();


//Actualizar datos
//Student estudianteActualiza = this._dbContext.Students
//.Where(c=>c.Id == new Guid("B548103D-640B-45D5-416C-08DC85002F9E"))
//.First();
//estudiante.Nombre="Pepe";
//this._dbContext.Students.Update(estudianteActualiza);
//this._dbContext.SaveChanges();
//
//Student estudianteActualiza = this._dbContext.Students
//.Where(c=>c.Id == new Guid("B548103D-640B-45D5-416C-08DC85002F9E"))
//.First();
//estudiante.Nombre="Pepe";
//this._dbContext.Students.Remove(estudianteActualiza);
//this._dbContext.SaveChanges();


List<StudentModel> list = new List<StudentModel>();
list = _dbContext.Students.Select(s => new StudentModel()
{
    Id= s.Id,
    Nombre = s.Nombre,
    Edad=s.Edad,
    Carrera=s.Carrera,
    Sexo=s.Sexo,


    }).ToList();



        return View(list);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
