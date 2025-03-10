﻿using Autofac.Core.Activators.Reflection;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace CQRS.Infrastructure.Processing
{
    internal class AllConstructorFinder : IConstructorFinder
    {
        private static readonly ConcurrentDictionary<Type, ConstructorInfo[]> Cache =
            new ConcurrentDictionary<Type, ConstructorInfo[]>();


        public ConstructorInfo[] FindConstructors(Type targetType)
        {
            var result = Cache.GetOrAdd(targetType,
                t => t.GetTypeInfo().DeclaredConstructors.ToArray());

            return result.Length > 0 ? result : throw new NoConstructorsFoundException(targetType);
        }
    }
}