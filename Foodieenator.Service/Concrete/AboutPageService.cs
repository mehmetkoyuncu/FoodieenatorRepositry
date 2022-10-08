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
    public class AboutPageService:IService<AboutPage>
    {
        IUnitOfWork _uow;
        public AboutPageService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(AboutPage entity)
        {
            var aboutPage = GetById(entity.Id);
            if (aboutPage == null)
                _uow.GetRepository<AboutPage>().Add(entity);
            else
            {
                aboutPage.AboutImage = aboutPage.AboutImage;
                aboutPage.AboutText = aboutPage.AboutText;
                _uow.GetRepository<AboutPage>().Update(aboutPage);
            }

            _uow.SaveChanges();
        }

        public List<AboutPage> GetAll()
        {
            List<AboutPage> aboutPage = _uow.GetRepository<AboutPage>().GetAll();
            return aboutPage;
        }

        public AboutPage GetById(int id)
        {
            AboutPage aboutPage = _uow.GetRepository<AboutPage>().Get(x => x.Id == id).FirstOrDefault();
            return aboutPage;
        }

        public void HardDelete(AboutPage entity)
        {
            var aboutPage = GetById(entity.Id);
            _uow.GetRepository<AboutPage>().HardDelete(aboutPage);
            _uow.SaveChanges();
        }
    }
}
