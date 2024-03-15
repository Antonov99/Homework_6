using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class MoveController
    {
        private readonly IAtomicVariable<Vector3> _moveDirection;

        public MoveController(IAtomicVariable<Vector3> moveDirection)
        {
            _moveDirection = moveDirection;
        }

        public void Update()
        {
            if(_moveDirection==null) return;
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction.z = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction.z = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }

            _moveDirection.Value = direction;
        }
    }
}