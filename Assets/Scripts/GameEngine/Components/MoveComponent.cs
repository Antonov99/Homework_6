using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class MoveComponent:IDisposable
    {
        private MovementMechanic _movementMechanic;

        public AtomicVariable<bool> moveEnabled=new(true);

        public AtomicFunction<bool> isMoving;
        
        [Get(ObjectAPI.MoveDirection)]
        public AtomicVariable<Vector3> movementDirection;
        public AtomicVariable<float> moveSpeed=new(3);
        
        public void Compose(Transform transform)
        {
            isMoving.Compose(()=>moveEnabled.Value && movementDirection.Value.magnitude>0);
            _movementMechanic = new MovementMechanic(moveEnabled,movementDirection, moveSpeed, transform);
        }

        public void Update()
        {
            _movementMechanic.Update();
        }

        public void Dispose()
        {
            moveEnabled?.Dispose();
            movementDirection?.Dispose();
            moveSpeed?.Dispose();
        }
    }
}