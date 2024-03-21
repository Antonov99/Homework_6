using GameEngine.Components;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class UpdateMovementDirectionMechanic
    {
        private readonly Transform _target;
        private readonly Transform _transform;
        private readonly MoveComponent _moveComponent;
        private const float _STOPPING_DISTANCE = 2f;

        public UpdateMovementDirectionMechanic(Transform target, Transform transform, MoveComponent moveComponent)
        {
            _target = target;
            _transform = transform;
            _moveComponent = moveComponent;
        }

        public void Update()
        {
            if (Vector3.Distance(_target.position, _transform.position) < _STOPPING_DISTANCE)
            {
                _moveComponent.movementDirection.Value=Vector3.zero;
                
            }

            var direction = _target.position - _transform.position;
            var normalizedDirection = direction.normalized;
            _moveComponent.movementDirection.Value = normalizedDirection;
        }
    }
}