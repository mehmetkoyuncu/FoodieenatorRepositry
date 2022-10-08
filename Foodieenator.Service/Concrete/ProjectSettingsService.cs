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
    public class ProjectSettingsService:IService<ProjectSettings>
    {
        IUnitOfWork _uow;
        public ProjectSettingsService()
        {
            _uow = new EFUnitOfWork(new EfContext());
        }

        public void AddOrUpdate(ProjectSettings entity)
        {
            var projectSettings = GetById(entity.Id);
            if (projectSettings == null)
                _uow.GetRepository<ProjectSettings>().Add(entity);
            else
            {
                projectSettings.InfoText = entity.InfoText;
                projectSettings.Name = entity.Name;
                _uow.GetRepository<ProjectSettings>().Update(projectSettings);
            }

            _uow.SaveChanges();
        }

        public List<ProjectSettings> GetAll()
        {
            List<ProjectSettings> projectSettingss = _uow.GetRepository<ProjectSettings>().GetAll();
            return projectSettingss;
        }

        public ProjectSettings GetById(int id)
        {
            ProjectSettings projectSettings = _uow.GetRepository<ProjectSettings>().Get(x => x.Id == id).FirstOrDefault();
            return projectSettings;
        }

        public void HardDelete(ProjectSettings entity)
        {
            var projectSettings = GetById(entity.Id);
            _uow.GetRepository<ProjectSettings>().HardDelete(projectSettings);
            _uow.SaveChanges();
        }
    }
}
