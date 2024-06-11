using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CRUD_Students2.Entities;
using CRUD_Students2.Models;

namespace CRUD_Students2.Controllers
{
    public class EspecialidadDocController : Controller
    {
         private readonly ILogger<EspecialidadDocController> _logger;
        private readonly AplicationDbContext _dbContext;
 

        public EspecialidadDocController(ILogger<EspecialidadDocController> logger, AplicationDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }
 public IActionResult EspecialidadList()
        {
             EspecialidadModel espe = new EspecialidadModel();
            espe.Id = new Guid();
            espe.Operacion = 62;
            espe.Especialidad1 = "Odontología";
            espe.TiempoOpera = 23;
         


            //  this._dbContext.Doctors.Add(dr);
            //  this._dbContext.SaveChanges();
            List<EspecialidadModel> list = new List<EspecialidadModel>();
            list = _dbContext.Especialidades.Select(s => new EspecialidadModel()
            {
                Id = s.Id,
                Operacion = s.Operacion,
                Especialidad1 = s.Especialidad1,
                TiempoOpera = s.TiempoOpera


            }).ToList();


            return View(list);
        }
         public IActionResult EspecialidadSave()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EspecialidadSave(EspecialidadModel model)
        {

            if (ModelState.IsValid)
            {
                Especialidad espeAdd = new Especialidad
                {
                    Id = Guid.NewGuid(),
                    Operacion = model.Operacion,
                Especialidad1 = model.Especialidad1,
                TiempoOpera = model.TiempoOpera
                };

                _dbContext.Especialidades.Add(espeAdd);
                _dbContext.SaveChanges();

                return RedirectToAction("EspecialidadList");
            }
            return View(model);
        }

        public IActionResult EspecialidadDeleted(Guid id)
        {
            var espec = _dbContext.Especialidades.FirstOrDefault(p => p.Id == id);
            if (espec != null)
            {
                _dbContext.Especialidades.Remove(espec);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("EspecialidadList");


        }

        public IActionResult EspecialidadEdit(Guid id)
        {
            var espec = _dbContext.Especialidades.FirstOrDefault(p => p.Id == id);
            if (espec == null)
            {
                return RedirectToAction("EspecialidadList");
            }
            var model = new EspecialidadModel
            {
                Id = espec.Id,
                  Operacion = espec.Operacion,
                Especialidad1 = espec.Especialidad1,
                TiempoOpera = espec.TiempoOpera
            };

            return View(model);
        }
[HttpPost]
        public IActionResult EspecialidadEdit(EspecialidadModel model)
        {
            if (ModelState.IsValid)
            {
                var espec = _dbContext.Especialidades.FirstOrDefault(p => p.Id == model.Id);
                if (espec != null)
                {
                
                     espec.Operacion = model.Operacion;
                espec.Especialidad1 = model.Especialidad1;
                espec.TiempoOpera = model.TiempoOpera;
                    _dbContext.SaveChanges();
                    return RedirectToAction("EspecialidadList");
                }
            }
            return View(model);
        }

    }






    }
