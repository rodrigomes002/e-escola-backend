using eEscola.Application.Models;
using eEscola.Application.Results;
using eEscola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eEscola.Application.Interfaces
{
    public interface IBoletimApplication
    {
        Task<Result<IEnumerable<Boletim>>> GetAll();
    }
}
