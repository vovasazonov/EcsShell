namespace Ecs
{
    public interface IEntity
    {
        ref T GetComponent<T>() where T : struct;
        void ReplaceComponent<T>(T component) where T : struct;
        void RemoveComponent<T>() where T : struct;
        bool ContainsComponent<T>() where T : struct;
        void Destroy();
    }
}