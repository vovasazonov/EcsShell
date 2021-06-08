using System.Collections.Generic;

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

        public T GetComponent<T>() where T : struct
        {
            int index = _info.GetIndex<T>();
            return GetByIndex<T>(index).Value;
        }

        public void ReplaceComponent<T>(T component) where T : struct
        {
            int index = _info.GetIndex<T>();
            var storageComponent = (ComponentShell<T>) CreateComponent(index, typeof(ComponentShell<T>));
            storageComponent.Value = component;
            base.ReplaceComponent(index, storageComponent);
        }

        private void ReplaceListenerComponent<T>() where T : struct
        {
            if (!ContainsComponent<ListenerComponent<T>>())
            {
                ReplaceComponent(new ListenerComponent<T> {Value = new List<IComponentListener<T>>()});
            }
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

        public void RegisterListenerComponent<T>(IComponentListener<T> listener) where T : struct
        {
            ReplaceListenerComponent<T>();
            
            ListenerComponent<T> listenerComponent = GetComponent<ListenerComponent<T>>();
            listenerComponent.Value.Add(listener);
        }

        public void UnregisterListenerComponent<T>(IComponentListener<T> listener) where T : struct
        {
            ListenerComponent<T> listenerComponent = GetComponent<ListenerComponent<T>>();
            listenerComponent.Value.Remove(listener);
        }

        private ComponentShell<T> GetByIndex<T>(int index) where T : struct
        {
            return (ComponentShell<T>) base.GetComponent(index);
        }
    }
}