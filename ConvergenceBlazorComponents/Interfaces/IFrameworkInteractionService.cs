﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvergenceBlazorComponents.Interfaces
{
  public interface IFrameworkInteractionService
  {
    void OpenPageInWindow(string pagePath, string pageTitle);
  }
}
