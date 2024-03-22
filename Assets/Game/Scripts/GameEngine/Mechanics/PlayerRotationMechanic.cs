using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class PlayerRotationMechanic
    {
        private readonly Camera _camera;
        private readonly Transform _transform;
        private readonly IAtomicValue<bool> _enabled;
        private const float _ROTATION_SPEED = 10f;
        
        public PlayerRotationMechanic(IAtomicValue<bool> enabled,Transform transform)
        {
            _enabled = enabled;
            _transform = transform;
            _camera=Camera.main;
        }

        public void Update()
        {
            if (_camera is null || !_enabled.Value) return;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 targetDirection = hitInfo.point - _transform.position; 
                targetDirection.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection); 
                _transform.rotation = Quaternion.Lerp(_transform.rotation, targetRotation, _ROTATION_SPEED * Time.deltaTime);
            }
        }
    }
}