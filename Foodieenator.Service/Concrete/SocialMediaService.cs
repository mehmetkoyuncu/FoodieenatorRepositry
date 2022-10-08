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
    public class SocialMediaService:IService<SocialMediaURL>
    {
        IUnitOfWork _uow;
        public SocialMediaService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(SocialMediaURL entity)
        {
            var socialMedia=GetById(entity.Id);
            if (socialMedia == null)
                _uow.GetRepository<SocialMediaURL>().Add(entity);
            else
            {
                socialMedia.Icon = entity.Icon;
                socialMedia.Name = entity.Name;
                socialMedia.URL = entity.URL;
                _uow.GetRepository<SocialMediaURL>().Update(socialMedia);
            }
    
            _uow.SaveChanges();
        }

        public List<SocialMediaURL> GetAll()
        {
           List<SocialMediaURL> socialMedias= _uow.GetRepository<SocialMediaURL>().GetAll();
            return socialMedias;
        }

        public SocialMediaURL GetById(int id)
        {
            SocialMediaURL socialMedia = _uow.GetRepository<SocialMediaURL>().Get(x=>x.Id==id).FirstOrDefault();
            return socialMedia;
        }

        public void HardDelete(SocialMediaURL entity)
        {
            var socialMedia = GetById(entity.Id);
            _uow.GetRepository<SocialMediaURL>().HardDelete(socialMedia);
            _uow.SaveChanges();
        }
    }
}
