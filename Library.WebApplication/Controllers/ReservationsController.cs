using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;
using Library.Repositories.Interfaces;
using Microsoft.AspNet.Identity;

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

            if (!reservation.ReservedBooks.Any(x => x.Id == bookId))
            {
                reservation.ReservedBooks.Add(reservedBook);
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult RemoveBook(int id)
        {
            Reservation reservation = GetReservation();

            Book reservedBook = reservation.ReservedBooks.First(x => x.Id == id);

            if (reservedBook != null)
            {
                reservation.ReservedBooks.Remove(reservedBook);
            }

            return RedirectToAction("Index");
        }

        private Reservation GetReservation()
        {
            Reservation reservation = (Reservation) Session["Reservation"];
            if (reservation == null)
            {
                reservation = new Reservation();
                reservation.ReservedBooks = new List<Book>();
                var userName = HttpContext.User.Identity.GetUserName();
                reservation.UserName = userName;
                
                Session["Reservation"] = reservation;
            }

            return reservation;
        }

        public ActionResult Create()
        {
            Reservation reservation = GetReservation();
            return View(reservation);
        }

        [HttpPost]
        public void Create(Reservation reservation)
        {
            var reservedBooks = GetReservation().ReservedBooks;
            reservation.UserName = HttpContext.User.Identity.GetUserName();
            reservation.ReservedBooks = reservedBooks;
            reservationsRepository.Create(reservation);
            reservationsRepository.Save();
        }
    }
}