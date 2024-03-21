using Atomic.Objects;
using GameEngine.Components;
using UnityEngine;

namespace Gameplay
{
    public sealed class Bullet : AtomicObject
    {
        [Section] 
        public MoveComponent moveComponent;

        public BulletComponent bulletComponent;
        
        [SerializeField]
        private UnSpawnBulletComponent unSpawnBulletComponent;

        public override void Compose()
        {
            base.Compose();
            moveComponent.Compose(transform);
            bulletComponent.Compose();
            unSpawnBulletComponent.Compose();
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
            if (unSpawnBulletComponent.Update(Time.deltaTime)) Destroy(gameObject);
        }

        private void OnDestroy()
        {
            moveComponent.Dispose();
        }
    }
}