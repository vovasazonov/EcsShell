namespace Ecs.EntitasExtension
{
    internal sealed class Entity : Entitas.Entity, IEntity
    {
        private readonly IComponentsInfo _info;

        public Entity(IComponentsInfo info)
        {
            _info = info;
        }

        public new void Destroy()
        {
            base.Destroy();
        }

        public ref T GetComponent<T>() where T : struct
        {
            int index = _info.GetIndex<T>();
            return ref GetByIndex<T>(index).Value;
        }

        public void ReplaceComponent<T>(T component) where T : struct
        {
            int index = _info.GetIndex<T>();
            var storageComponent = (ComponentShell<T>) CreateComponent(index, typeof(ComponentShell<T>));
            storageComponent.Value = component;
            base.ReplaceComponent(index, storageComponent);
        }

        public void RemoveComponent<T>() where T : struct
        {
            int index = _info.GetIndex<T>();
            GetByIndex<T>(index).Value = default;
            RemoveComponent(index);
        }

        public bool ContainsComponent<T>() where T : struct
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