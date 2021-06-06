namespace Ecs.EntitasExtension
{
    internal sealed class Entity : Entitas.Entity, IEntity
    {
        private readonly IComponentsInfo _info;

        public Entity(IComponentsInfo info)
        {
            _info = info;
        }
        
        void IEntity.Destroy()
        {
            base.Destroy();
        }

        ref T IEntity.GetComponent<T>()
        {
            int index = _info.GetIndex<T>();
            return ref GetByIndex<T>(index).Value;
        }

        void IEntity.ReplaceComponent<T>(T component)
        {
            int index = _info.GetIndex<T>();
            var storageComponent = (ComponentShell<T>) CreateComponent(index, typeof(ComponentShell<T>));
            storageComponent.Value = component;
            base.ReplaceComponent(index, storageComponent);
        }

        void IEntity.RemoveComponent<T>()
        {
            int index = _info.GetIndex<T>();
            GetByIndex<T>(index).Value = default;
            RemoveComponent(index);
        }

        bool IEntity.ContainsComponent<T>()
        {
            int index = _info.GetIndex<T>();
            return HasComponent(index);
        }
        
        private ComponentShell<T> GetByIndex<T>(int index) where T : struct
        {
            return (ComponentShell<T>) base.GetComponent(index);
        }
    }
}