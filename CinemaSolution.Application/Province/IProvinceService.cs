using CinemaSolution.ViewModels.Province;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSolution.Application.Province
{
    public interface IProvinceService
    {
        Task<List<ProvinceViewModel>> GetAll();
    }
}
