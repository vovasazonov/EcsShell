using System.Collections.Generic;

namespace Ecs
{
    internal struct ListenerComponent<TComponent> where TComponent : struct
    {
        public List<IComponentListener<TComponent>> Value;
    }
}