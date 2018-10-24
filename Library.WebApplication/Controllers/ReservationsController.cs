using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;
using Library.Repositories.Interfaces;

namespace Library.WebApplication.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IRepository<Reservation> reservationsRepository;
        private readonly IRepository<Book> booksRepository;

        public ReservationsController(IRepository<Reservation> reservationsRepository,
            IRepository<Book> booksRepository)
        {
            this.reservationsRepository = reservationsRepository;
            this.booksRepository = booksRepository;
        }

        // GET: Reservations
        public ActionResult Index()
        {
            Reservation reservation = GetReservation();
            return View(reservation);
        }

        public ActionResult AddReservation(int bookId)
        {
            Reservation reservation = GetReservation();
            Book reservedBook = booksRepository.GetById(bookId);
            reservation.ReservedBooks.Add(reservedBook);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveBook(int id)
        {
            return RedirectToAction("Index");
        }

        private Reservation GetReservation()
        {
            Reservation reservation = (Reservation) Session["Reservation"];
            if (reservation == null)
            {
                reservation = new Reservation();
                reservation.ReservedBooks = new List<Book>();
                
                Session["Reservation"] = reservation;
            }

            return reservation;
        }
    }
}