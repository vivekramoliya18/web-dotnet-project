using Microsoft.AspNetCore.Mvc;
using MediCareWeb.Models;

namespace MediCareWeb.Controllers;

public class AppointmentsController : Controller
{
    private static readonly List<Appointment> Appointments = new();
    private static int _nextId = 1;

    public IActionResult Index() => View(Appointments.OrderBy(a => a.AppointmentDate).ThenBy(a => a.AppointmentTime).ToList());

    public IActionResult Create() => View(new Appointment { AppointmentDate = DateTime.Today });

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Create(Appointment appointment)
    {
        if (appointment.AppointmentDate.Date < DateTime.Today)
            ModelState.AddModelError(nameof(appointment.AppointmentDate), "Appointment date cannot be in the past.");
        if (!ModelState.IsValid) return View(appointment);
        appointment.Id = _nextId++;
        appointment.Status = "Scheduled";
        Appointments.Add(appointment);
        TempData["Success"] = "Appointment booked successfully.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Complete(int id)
    {
        var appointment = Appointments.FirstOrDefault(a => a.Id == id);
        return appointment == null ? NotFound() : View(appointment);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Complete(int id, string? diagnosis, string? visitNotes)
    {
        var appointment = Appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null) return NotFound();
        if (string.IsNullOrWhiteSpace(diagnosis))
        {
            ModelState.AddModelError("diagnosis", "Diagnosis is required to complete a visit.");
            return View(appointment);
        }
        appointment.Diagnosis = diagnosis.Trim();
        appointment.VisitNotes = visitNotes?.Trim();
        appointment.Status = "Completed";
        appointment.CompletedAt = DateTime.Now;
        TempData["Success"] = "Visit marked as completed and visit notes saved.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Cancel(int id)
    {
        var appointment = Appointments.FirstOrDefault(a => a.Id == id);
        if (appointment == null) return NotFound();
        appointment.Status = "Cancelled";
        TempData["Success"] = "Appointment cancelled.";
        return RedirectToAction(nameof(Index));
    }
}
