using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialControlFront.Models;

namespace MaterialControlFront.Interfaces
{
    public interface IMatTypeService
    {
        IEnumerable<MatTypeViewModel> GetAll();
        MatTypeViewModel GetByCode(string code);
        bool Add(MatTypeModel model);
        bool Edit(MatTypeModel model);
        bool Delete(string code);
    }
}