namespace Ecs.EntitasExtension
{
    internal sealed class ComponentShell<T> : Entitas.IComponent where T : struct
    {
        public T Value;
    }
}