using Atomic.Objects;
using GameEngine.Components;
using UnityEngine;

namespace Gameplay
{
    public sealed class Bullet : AtomicObject
    {
        [Section] public MoveComponent moveComponent;

        public BulletComponent bulletComponent;

        public override void Compose()
        {
            base.Compose();
            moveComponent.Compose(transform);
            bulletComponent.Compose();
        }

        private void OnCollisionEnter(Collision collision)
        {
            bulletComponent.OnCollisionEnter(collision);
            Destroy(gameObject);
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