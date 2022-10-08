using Foodieenator.Data.Context;
using Foodieenator.Data.UnitOfWork;
using Foodieenator.Entities.Entities;
using Foodieenator.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Service.Concrete
{
    public class ReservationService:IService<Reservation>
    {
        IUnitOfWork _uow;
        public ReservationService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(Reservation entity)
        {
            var reservation = GetById(entity.Id);
            if (reservation == null)
                _uow.GetRepository<Reservation>().Add(entity);
            else
            {
                reservation.IsApprove = entity.IsApprove;
                reservation.IsCancellationReservation = entity.IsCancellationReservation;
                reservation.IsSeen = entity.IsSeen;
                reservation.Mail = entity.Mail;
                reservation.Name = entity.Name;
                reservation.PersonCount = entity.PersonCount;
                reservation.Phone = entity.Phone;
                reservation.ReservationDate = entity.ReservationDate;
                _uow.GetRepository<Reservation>().Update(reservation);
            }

            _uow.SaveChanges();
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservation = _uow.GetRepository<Reservation>().GetAll();
            return reservation;
        }

        public Reservation GetById(int id)
        {
            Reservation reservation = _uow.GetRepository<Reservation>().Get(x => x.Id == id).FirstOrDefault();
            return reservation;
        }

        public void HardDelete(Reservation entity)
        {
            var reservation = GetById(entity.Id);
            _uow.GetRepository<Reservation>().HardDelete(reservation);
            _uow.SaveChanges();
        }
    }
}
