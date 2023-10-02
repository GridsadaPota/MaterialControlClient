using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialControlFront.Models;

namespace MaterialControlFront.Interfaces
{
    public interface IMatTypeService
    {
        Task<IEnumerable<MatTypeModelView>> GetMatTypeAll();
        Task<MatTypeModelView> GetMatTypeByCode(string code);
    }
}