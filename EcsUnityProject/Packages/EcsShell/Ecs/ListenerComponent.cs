using System.Collections.Generic;

namespace Ecs
{
    public struct ListenerComponent<TComponent> where TComponent : struct
    {
        public List<IComponentListener<TComponent>> Value;
    }
}