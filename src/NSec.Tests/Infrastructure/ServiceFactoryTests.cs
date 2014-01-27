using NSec.Infrastructure;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NSec.Tests.Infrastructure
{
    public class ServiceFactoryTests
    {
        [Fact]
        public void Setup()
        {
            ServiceFactory.Setup();
            Console.Write(ObjectFactory.Container.WhatDoIHave());
        }
    }
}