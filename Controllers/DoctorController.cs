using CRUD_Students2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace CRUD_Students2.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ILogger<DoctorController> _logger;
        private readonly AplicationDbContext _dbContext;
        public DoctorController(ILogger<DoctorController> logger, AplicationDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public IActionResult DoctorList()
        {

            DoctorModel dr = new DoctorModel();
            dr.Id = new Guid();
            dr.Nombre = "Lopez";
            dr.Edad = 47;
            dr.Sexo = "Masculino";
            dr.Especialidad = "Odontología";


            //  this._dbContext.Doctors.Add(dr);
            //  this._dbContext.SaveChanges();
            List<DoctorModel> list = new List<DoctorModel>();
            list = _dbContext.Doctors.Select(s => new DoctorModel()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Edad = s.Edad,
                Especialidad = s.Especialidad,
                Sexo = s.Sexo,


            }).ToList();


            return View(list);
        }
        public IActionResult DoctorSave()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoctorSave(DoctorModel model)
        {

            if (ModelState.IsValid)
            {
                Doctor docAdd = new Doctor
                {
                    Id = Guid.NewGuid(),
                    Nombre = model.Nombre,
                    Edad = model.Edad,
                    Especialidad = model.Especialidad,
                    Sexo = model.Sexo
                };

                _dbContext.Doctors.Add(docAdd);
                _dbContext.SaveChanges();

                return RedirectToAction("DoctorList");
            }
            return View(model);
        }

        public IActionResult DoctorDeleted(Guid id)
        {
            var doc = _dbContext.Doctors.FirstOrDefault(p => p.Id == id);
            if (doc != null)
            {
                _dbContext.Doctors.Remove(doc);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("DoctorList");


        }

        public IActionResult DoctorEdit(Guid id)
        {
            var doc = _dbContext.Doctors.FirstOrDefault(p => p.Id == id);
            if (doc == null)
            {
                return RedirectToAction("DoctorList");
            }
            var model = new DoctorModel
            {
                Id = doc.Id,
                Nombre = doc.Nombre,
                Edad = doc.Edad,
                Especialidad = doc.Especialidad,
                Sexo = doc.Sexo
            };

            return View(model);
        }
[HttpPost]
        public IActionResult DoctorEdit(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                var doc = _dbContext.Doctors.FirstOrDefault(p => p.Id == model.Id);
                if (doc != null)
                {
                    doc.Nombre = model.Nombre;
                    doc.Edad = model.Edad;
                    doc.Especialidad = model.Especialidad;
                    doc.Sexo = model.Sexo;
                    _dbContext.SaveChanges();
                    return RedirectToAction("DoctorList");
                }
            }
            return View(model);
        }

    }





}
