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
    public class ContactInformationService:IService<ContactInformation>
    {
        IUnitOfWork _uow;
        public ContactInformationService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(ContactInformation entity)
        {
            var contactInformation = GetById(entity.Id);
            if (contactInformation == null)
                _uow.GetRepository<ContactInformation>().Add(entity);
            else
            {
                contactInformation.Location = contactInformation.Location;
                contactInformation.Mail = contactInformation.Mail;
                contactInformation.Phone = contactInformation.Phone;
                contactInformation.WorkHour = contactInformation.WorkHour;
                contactInformation.WorkPeriod = contactInformation.WorkPeriod;
                _uow.GetRepository<ContactInformation>().Update(contactInformation);
            }

            _uow.SaveChanges();
        }

        public List<ContactInformation> GetAll()
        {
            List<ContactInformation> contactInformation = _uow.GetRepository<ContactInformation>().GetAll();
            return contactInformation;
        }

        public ContactInformation GetById(int id)
        {
            ContactInformation contactInformation = _uow.GetRepository<ContactInformation>().Get(x => x.Id == id).FirstOrDefault();
            return contactInformation;
        }

        public void HardDelete(ContactInformation entity)
        {
            var contactInformation = GetById(entity.Id);
            _uow.GetRepository<ContactInformation>().HardDelete(contactInformation);
            _uow.SaveChanges();
        }
    }
}
