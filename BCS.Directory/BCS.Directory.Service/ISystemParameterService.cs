using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.Service
{
    public interface ISystemParameterService
    {
        List<SystemParameter> GetSystemParameterByFieldGroup(string fieldGroup);
    }
}
