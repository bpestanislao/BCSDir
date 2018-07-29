using System;
using System.Collections.Generic;
using System.Text;
using BCS.Directory.CORE.Entity;
using BCS.Directory.DAO.Repositories;

namespace BCS.Directory.Service
{
    public class SystemParameterService : ISystemParameterService
    {
        ISystemParameterRepository _systemParameterRepository;
        public SystemParameterService(ISystemParameterRepository systemParameterRepository)
        {
            _systemParameterRepository = systemParameterRepository;
        }
        public List<SystemParameter> GetSystemParameterByFieldGroup(string fieldGroup)
        {
            return _systemParameterRepository.Get(x => x.FieldGroup == fieldGroup);
        }
    }
}
