﻿using Exemplo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo02.Repositories
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        void Promocao(int id, decimal valor);
    }
}
