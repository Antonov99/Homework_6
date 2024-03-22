using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Actions;
using GameEngine.Components;
using GameEngine.GameEngine.Data;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class ZombieAIMechanic
    {
        private readonly AtomicObject _target;
        private readonly Transform _transform;
        private readonly MoveComponent _moveComponent;
        private const float _STOPPING_DISTANCE = 1f;
        private readonly DealDamageAction _dealDamageAction;
        private readonly Transform _targetTransform;

        private readonly Countdown _countdown;

        public ZombieAIMechanic(AtomicObject target, Transform transform, MoveComponent moveComponent, IAtomicVariable<int> damage)
        {
            _target = target;
            _transform = transform;
            _moveComponent = moveComponent;
            _dealDamageAction = new DealDamageAction(damage);
            _targetTransform = _target.transform;

            _countdown = new Countdown(1f);
        }

        public void Update()
        {
            if (!_moveComponent.moveEnabled.Value) return; 
            if (Vector3.Distance(_targetTransform.position, _transform.position) < _STOPPING_DISTANCE)
            {
                _countdown.Tick(Time.deltaTime);
                if(_countdown.IsPlaying()) return;
                _moveComponent.movementDirection.Value = Vector3.zero;
                _dealDamageAction.Invoke(_target);
                _countdown.Reset();
                return;
            }
            
            var direction = _targetTransform.position - _transform.position;
            var normalizedDirection = direction.normalized;
            _moveComponent.movementDirection.Value = normalizedDirection;
        }
    }
}