using Atomic.Objects;
using GameEngine.Components;

namespace Gameplay
{
    public sealed class Bullet:AtomicObject
    {
        [Section]
        public MoveComponent moveComponent;

        public override void Compose()
        {
            base.Compose();
            moveComponent.Compose(transform);
        }

        private void Awake()
        {
            Compose();
        }
        
        private void Update()
        {
            moveComponent.Update();
        }

        private void OnDestroy()
        {
            moveComponent.Dispose();
        }
    }
}