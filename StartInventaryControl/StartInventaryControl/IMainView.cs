﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl
{
    public interface IMainView
    {
        MainPresenter Presenter { set; }

        string ErrorMessage { set; }
    }
}
