using Microsoft.AspNetCore.Mvc;
using MediCareWeb.Models;

namespace MediCareWeb.Controllers;

public class DoctorsController : Controller
{
    private static readonly List<Doctor> Doctors = new();
    private static int _nextId = 1;

    public IActionResult Index() => View(Doctors);

    public IActionResult Create() => View(new Doctor());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(Doctor doctor)
    {
        if (!ModelState.IsValid) return View(doctor);
        doctor.Id = _nextId++;
        Doctors.Add(doctor);
        TempData["Success"] = "Doctor added successfully.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var doctor = Doctors.FirstOrDefault(d => d.Id == id);
        return doctor == null ? NotFound() : View(doctor);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Doctor input)
    {
        if (id != input.Id) return BadRequest();
        if (!ModelState.IsValid) return View(input);
        var doctor = Doctors.FirstOrDefault(d => d.Id == id);
        if (doctor == null) return NotFound();
        doctor.FullName = input.FullName;
        doctor.Specialty = input.Specialty;
        doctor.Phone = input.Phone;
        doctor.Email = input.Email;
        TempData["Success"] = "Doctor updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var doctor = Doctors.FirstOrDefault(d => d.Id == id);
        if (doctor != null) Doctors.Remove(doctor);
        TempData["Success"] = doctor == null ? "Doctor not found." : "Doctor deleted.";
        return RedirectToAction(nameof(Index));
    }
}
