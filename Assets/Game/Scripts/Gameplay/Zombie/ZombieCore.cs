using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Components;
using GameEngine.Mechanics;
using UnityEngine;

namespace Gameplay.Zombie
{
    [Serializable]
    public class ZombieCore
    {
        [SerializeField] 
        private Transform transform;
        
        [Section]
        public HealthComponent healthComponent;
        
        [Section]
        public MoveComponent moveComponent;

        public RotationMechanic rotationMechanic;

        private UpdateMechanics _stateController;

        private ZombieAIMechanic _zombieAIMechanic;
        
        public AtomicVariable<int> damage;

        [SerializeField] 
        private AtomicObject target;

        public void Compose()
        {
            healthComponent.Compose();
            moveComponent.Compose(transform);

            rotationMechanic = new RotationMechanic(moveComponent.movementDirection,healthComponent.IsAlive,transform);

            _stateController = new UpdateMechanics(() =>
            {
                bool isAlive = healthComponent.IsAlive.Value;
                moveComponent.moveEnabled.Value = isAlive;
            });

            _zombieAIMechanic = new ZombieAIMechanic(target, transform,moveComponent,damage);
        }
        
        public void OnEnable()
        {
            healthComponent.OnEnable();
        }

        public void OnDisable()
        {
            healthComponent.OnDisable();
        }

        public void Update()
        {
            _stateController.Update();
            moveComponent.Update();
            rotationMechanic.Update();
            _zombieAIMechanic.Update();
        }

        public void Dispose()
        {
            healthComponent?.Dispose();
            moveComponent?.Dispose();
        }
    }
}