using Microsoft.AspNetCore.Mvc;
using MediCareWeb.Models;

namespace MediCareWeb.Controllers
{
    public class PatientsController : Controller
    {
        private static readonly List<Patient> _patients = new();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(_patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
                return View(patient);

            patient.Id = _nextId++;
            _patients.Add(patient);

            TempData["Success"] = "Patient added successfully!";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Patient updatedPatient)
        {
            if (id != updatedPatient.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(updatedPatient);

            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                return NotFound();

            patient.FullName = updatedPatient.FullName;
            patient.Phone = updatedPatient.Phone;
            patient.Email = updatedPatient.Email;
            patient.Gender = updatedPatient.Gender;
            patient.DateOfBirth = updatedPatient.DateOfBirth;

            TempData["Success"] = "Patient updated successfully!";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
                return NotFound();

            _patients.Remove(patient);

            TempData["Success"] = "Patient deleted successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}