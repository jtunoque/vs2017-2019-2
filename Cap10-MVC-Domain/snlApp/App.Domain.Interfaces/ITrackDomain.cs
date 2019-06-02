﻿using App.Entities.Base;
using App.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ITrackDomain
    {
        IEnumerable<ConsultaTracks> Buscar
                (string trackName, int genero);

        bool Guardar(Track entity);

    }
}
