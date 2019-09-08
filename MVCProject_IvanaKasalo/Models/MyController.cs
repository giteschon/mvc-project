using MVCProject_IvanaKasalo.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_IvanaKasalo.Models
{
    public class MyController :Controller
    {
        public IRepo repo = new Repository();

    }
}