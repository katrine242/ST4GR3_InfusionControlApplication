﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new ViewModelCreateInfusion();
        }

       

      
    }
}
