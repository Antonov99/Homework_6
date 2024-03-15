using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class MovementMechanic
    {
        private readonly IAtomicValue<bool> _canMove;
        private readonly IAtomicValue<Vector3> _movementDirection;
        private readonly IAtomicValue<float> _moveSpeed;
        private readonly Transform _transform;
        
        public MovementMechanic(
            IAtomicValue<bool> canMove,
            IAtomicValue<Vector3> movementDirection, 
            IAtomicValue<float> moveSpeed, 
            Transform transform
            )
        {
            _canMove = canMove;
            _movementDirection = movementDirection;
            _moveSpeed = moveSpeed;
            _transform = transform;
        }

        public void Update()
        {
            if (_canMove.Value)
            {
                Vector3 offset = _movementDirection.Value * (_moveSpeed.Value * Time.deltaTime);
                _transform.position += offset;
            }
        }
    }
}