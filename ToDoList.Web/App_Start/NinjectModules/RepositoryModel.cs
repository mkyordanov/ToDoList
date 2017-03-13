﻿using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Data;
using ToDoList.Data.EFRepository;

namespace ToDoList.Web.App_Start.NinjectModules
{
    public class RepositoryModel : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ToDoListContext>().ToSelf().InRequestScope();
            this.Bind(typeof(IEFGenericRepository<>)).To(typeof(EFGenericRepository<>)).InRequestScope();
        }
    }
}