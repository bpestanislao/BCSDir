using BCS.Directory.APP.Models.ViewModels;
using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Directory.APP.Mapper
{
    public static class SystemParameterMapper
    {
        public static List<SystemParameterViewModel> Convert(List<SystemParameter> systemParameters)
        {
            List<SystemParameterViewModel> systemParametersVM = new List<SystemParameterViewModel>();
            foreach (var item in systemParameters)
            {
                systemParametersVM.Add(new SystemParameterViewModel() {
                    FieldGroup = item.FieldGroup,
                    FieldId = item.FieldId,
                    IsActive = item.IsActive,
                    FieldValue = item.FieldValue,
                });
            }
            return systemParametersVM;
        }
    }
}
