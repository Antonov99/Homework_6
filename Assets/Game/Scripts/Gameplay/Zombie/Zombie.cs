using Atomic.Objects;
using UnityEngine;

namespace Gameplay.Zombie
{
    public class Zombie : AtomicObject
    {
        [Section]
        [SerializeField] 
        private ZombieCore zombieCore;

        [Section]
        [SerializeField] 
        private ZombieView zombieView;
        
        public override void Compose()
        {
            base.Compose();
            zombieCore.Compose();
            zombieView.Compose(zombieCore);
        }

        private void Awake()
        {
            Compose();
        }
        
        private void OnEnable()
        {
            zombieCore.OnEnable();
            zombieView.OnEnable();
        }
        
        private void OnDisable()
        {
            zombieCore.OnDisable();
            zombieView.OnDisable();
        }
        
        private void Update()
        {
            zombieCore.Update();
            zombieView.Update();
        }

        private void OnDestroy()
        {
            zombieCore.Dispose();
        }
    }
}