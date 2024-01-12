﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Tools
{
    public class Service
    {
        public object Implementation { get; set; }
        public Type Type { get; set; }
        public Life Life { get; set; }
    }

    public enum Life
    {
        Singleton,
        Transient
    }
}
