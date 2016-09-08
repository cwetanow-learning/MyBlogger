﻿using BlogSystem.Domain.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using BlogSystem.Domain.Concrete;
using System.Web.Mvc;

namespace BlogSystem.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
            this.AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.kernel.Bind<IPostRepository>().To<PostRepository>();
            this.kernel.Bind<ICommentRepository>().To<CommentRepository>();
        }
    }
}