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
    public class IndexPageService:IService<IndexPage>
    {
        IUnitOfWork _uow;
        public IndexPageService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(IndexPage entity)
        {
            var indexPage = GetById(entity.Id);
            if (indexPage == null)
                _uow.GetRepository<IndexPage>().Add(entity);
            else
            {
                indexPage.MainImage = entity.MainImage;
                indexPage.SliderText1 = entity.SliderText1;
                indexPage.SliderText2 = entity.SliderText2;
                indexPage.SliderText3 = entity.SliderText3;
                _uow.GetRepository<IndexPage>().Update(indexPage);
            }

            _uow.SaveChanges();
        }

        public List<IndexPage> GetAll()
        {
            List<IndexPage> indexPages = _uow.GetRepository<IndexPage>().GetAll();
            return indexPages;
        }

        public IndexPage GetById(int id)
        {
            IndexPage indexPage = _uow.GetRepository<IndexPage>().Get(x => x.Id == id).FirstOrDefault();
            return indexPage;
        }

        public void HardDelete(IndexPage entity)
        {
            var indexPage = GetById(entity.Id);
            _uow.GetRepository<IndexPage>().HardDelete(indexPage);
            _uow.SaveChanges();
        }
    }
}
