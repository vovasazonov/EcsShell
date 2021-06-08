using System;

namespace Ecs
{
    [AttributeUsage(AttributeTargets.Struct)]
    public class FrameAttribute : Attribute
    {
        public bool IsDestroyEntity { get; }
        
        public FrameAttribute() { }
        
        public FrameAttribute(bool isDestroyEntity)
        {
            IsDestroyEntity = isDestroyEntity;
        }
    }
}