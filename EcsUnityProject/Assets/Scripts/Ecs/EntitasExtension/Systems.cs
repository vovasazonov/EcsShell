// ReSharper disable UnusedTypeParameter

namespace Ecs.EntitasExtension
{
    public class Systems : ISystems
    {
        private readonly Feature _feature = new Feature("Systems");

        public void Initialize()
        {
            _feature.Initialize();
        }

        public void Update()
        {
            _feature.Execute();
        }

        public void LateUpdate()
        {
            _feature.Cleanup();
        }

        public void Destroy()
        {
            _feature.TearDown();
        }

        public void Add<T>(T system) where T : ISystem
        {
            if (system is IInitializeSystem initialize)
            {
                _feature.Add(new InitializeEntitasSystem<T>(initialize));
            }

            if (system is IUpdateSystem update)
            {
                _feature.Add(new ExecuteEntitasSystem<T>(update));
            }

            if (system is ILateUpdateSystem lateUpdate)
            {
                _feature.Add(new CleanupEntitasSystem<T>(lateUpdate));
            }

            if (system is IDestroySystem destroy)
            {
                _feature.Add(new TearDownEntitasSystem<T>(destroy));
            }
        }
    }

    internal class InitializeEntitasSystem<T> : Entitas.IInitializeSystem
    {
        private readonly IInitializeSystem _system;

        public InitializeEntitasSystem(IInitializeSystem system)
        {
            _system = system;
        }

        public void Initialize()
        {
            _system.Initialize();
        }
    }

    internal class ExecuteEntitasSystem<T> : Entitas.IExecuteSystem
    {
        private readonly IUpdateSystem _system;

        public ExecuteEntitasSystem(IUpdateSystem system)
        {
            _system = system;
        }

        public void Execute()
        {
            _system.Update();
        }
    }

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

    internal class TearDownEntitasSystem<T> : Entitas.ITearDownSystem
    {
        private readonly IDestroySystem _system;

        public TearDownEntitasSystem(IDestroySystem system)
        {
            _system = system;
        }

        public void TearDown()
        {
            _system.Destroy();
        }
    }
}