﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvergenceBlazor.Components.Interfaces
{
    public interface IExternalAuthenticationStateProvider
    {
        Task LogInAsync();
        void LogOut();
    }
}
