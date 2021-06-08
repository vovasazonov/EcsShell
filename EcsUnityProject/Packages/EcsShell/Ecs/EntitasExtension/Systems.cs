namespace Ecs.EntitasExtension
{
    public class Systems : ISystems
    {
        private readonly World _world;
        private readonly Feature _feature = new Feature("Systems");

        public Systems(World world)
        {
            _world = world;
            _world.ProjectEcsInfo.InitDefaultSystems(_world, this);            
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
            if (system is IUpdateSystem update)
            {
                if (system is IReactSystem react)
                {
                    var collector = CreateCollector(system, react);
                    _feature.Add(new ReactiveEntitasSystem<T>(react, collector));
                }
                else
                {
                    _feature.Add(new ExecuteEntitasSystem<T>(update));
                }
            }

            if (system is IInitializeSystem initialize)
            {
                _feature.Add(new InitializeEntitasSystem<T>(initialize));
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

        private Entitas.ICollector<Entity> CreateCollector<T>(T system, IReactSystem react) where T : ISystem
        {
            Entitas.ICollector<Entity> collector;
            Entitas.IMatcher<Entity> matcher = ((Matcher) react.Matcher.Invoke(_world.Matcher)).GetMatcher();
            if (system is IEventSystem)
            {
                collector = Entitas.CollectorContextExtension.CreateCollector(_world.Context, Entitas.TriggerOnEventMatcherExtension.Added(matcher));
            }
            else
            {
                collector = _world.Context.CreateCollector(matcher);
            }

            return collector;
        }
    }
}
