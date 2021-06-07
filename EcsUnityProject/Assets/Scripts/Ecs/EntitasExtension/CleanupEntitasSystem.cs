namespace Ecs.EntitasExtension
{
    internal class CleanupEntitasSystem<T> : Entitas.ICleanupSystem
    {
        private readonly ILateUpdateSystem _system;

        public CleanupEntitasSystem(ILateUpdateSystem system)
        {
            _system = system;
        }

        public void Cleanup()
        {
            _system.LateUpdate();
        }
    }
}