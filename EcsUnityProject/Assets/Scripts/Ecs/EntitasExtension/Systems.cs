namespace Ecs.EntitasExtension
{
    public class Systems : ISystems
    {
        private readonly World _world;
        private readonly Feature _feature = new Feature("Systems");

        public Systems(World world)
        {
            _world = world;
        }

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
            if (system is IReactSystem react)
            {
                _feature.Add(new ReactiveEntitasSystem<T>(_world.Context, react, _world.Matcher));
            }
            
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
}