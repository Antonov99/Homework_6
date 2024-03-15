using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class RotationMechanic
    {
        private readonly IAtomicValue<Vector3> _lookDirection;
        private readonly IAtomicValue<bool> _enabled;
        private readonly Transform _transform;

        public RotationMechanic(IAtomicValue<Vector3> lookDirection, IAtomicValue<bool> enabled, Transform transform)
        {
            _lookDirection = lookDirection;
            _enabled = enabled;
            _transform = transform;
        }

        public void Update()
        {
            if (!_enabled.Value) return;

            Vector3 direction=_lookDirection.Value;
            if(direction==Vector3.zero)return;
            _transform.rotation=Quaternion.LookRotation(direction,Vector3.up);
        }
    }
}