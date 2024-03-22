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

        public PlayerRotationMechanic playerRotationMechanic;

        private UpdateMechanics _stateController;

        public void Compose()
        {
            healthComponent.Compose();
            moveComponent.Compose(transform);
            fireComponent.Compose();

            playerRotationMechanic = new PlayerRotationMechanic(healthComponent.IsAlive,transform);

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
            playerRotationMechanic.Update();
            fireComponent.Update();
        }

        public void Dispose()
        {
            healthComponent?.Dispose();
            moveComponent?.Dispose();
            fireComponent?.Dispose();
        }
    }
}