namespace Ecs
{
    public interface IEntity
    {
        T GetComponent<T>() where T : struct;
        void ReplaceComponent<T>(T component) where T : struct;
        void RemoveComponent<T>() where T : struct;
        bool ContainsComponent<T>() where T : struct;
        void RegisterListenerComponent<T>(IComponentListener<T> listener) where T : struct;
        void UnregisterListenerComponent<T>(IComponentListener<T> listener) where T : struct;
        void Destroy();
    }
}