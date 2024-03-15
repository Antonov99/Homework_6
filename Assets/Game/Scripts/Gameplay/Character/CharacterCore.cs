using System;
using Atomic.Objects;
using GameEngine.Components;
using GameEngine.Mechanics;
using UnityEngine;

namespace Gameplay.Character
{
    [Serializable]
    public class CharacterCore:IDisposable
    {
        [SerializeField] 
        private Transform transform;
        
        [Section]
        public HealthComponent healthComponent;
        
        [Section]
        public MoveComponent moveComponent;

        [Section] 
        public FireComponent fireComponent;

        public RotationMechanic rotationMechanic;

        private UpdateMechanics _stateController;

        public void Compose()
        {
            healthComponent.Compose();
            moveComponent.Compose(transform);
            fireComponent.Compose();

            rotationMechanic = new RotationMechanic(moveComponent.movementDirection,healthComponent.IsAlive,transform);

            _stateController = new UpdateMechanics(() =>
            {
                bool isAlive = healthComponent.IsAlive.Value;
                moveComponent.moveEnabled.Value = isAlive;
                fireComponent.fireEnabled.Value = isAlive;
            });
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
        }

        public void Dispose()
        {
            healthComponent?.Dispose();
            moveComponent?.Dispose();
            fireComponent?.Dispose();
        }
    }
}