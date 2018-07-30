using BCS.Directory.APP.Models.ViewModels;
using BCS.Directory.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Directory.APP.Mapper
{
    public static class CountryMapper
    {
        public static List<CountryViewModel> Convert(List<Country> countries)
        {
            List<CountryViewModel> countryViewModels = new List<CountryViewModel>();
            foreach (var item in countries)
            {
                countryViewModels.Add(new CountryViewModel() {
                    CountryCode = item.CountryCode,
                    CountryName = item.CountryName,
                    State = item.State, 
                });
            }
            return countryViewModels;
        }
    }
}
