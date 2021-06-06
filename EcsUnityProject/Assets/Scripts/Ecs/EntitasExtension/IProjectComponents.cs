using System;
using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    public interface IProjectComponents
    {
        IEnumerable<Type> Components { get; }
    }
}