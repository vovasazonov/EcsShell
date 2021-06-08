namespace Ecs
{
    public sealed class HandleFrameComponentSystem<TComponent> : ILateUpdateSystem where TComponent : struct
    {
        private readonly bool _isDestroyEntity;
        private readonly IFilter _filter;

        public HandleFrameComponentSystem(IWorld world, bool isDestroyEntity)
        {
            _isDestroyEntity = isDestroyEntity;
            _filter = world.GetFilter(m => m.Has<TComponent>());
        }
        
        public void LateUpdate()
        {
            foreach (var entity in _filter.GetEntities())
            {
                if (_isDestroyEntity)
                {
                    entity.Destroy();
                }
                else
                {
                    entity.RemoveComponent<TComponent>();
                }
            }
        }
    }
}