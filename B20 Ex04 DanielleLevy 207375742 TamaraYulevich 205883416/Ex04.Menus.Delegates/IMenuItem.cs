﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public interface IMenuItem
    {
        string GetTitle();

        void Clicked();
    }
}
