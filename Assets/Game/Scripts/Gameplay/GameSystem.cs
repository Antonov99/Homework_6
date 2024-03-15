using Atomic.Extensions;
using Atomic.Objects;
using GameEngine;
using GameEngine.Controllers;
using UnityEngine;

namespace Gameplay
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] 
        private AtomicObject character;

        private MoveController _moveController;
        private FireController _fireController;

        public void Start()
        {
            var moveDirection = character.GetVariable<Vector3>(ObjectAPI.MoveDirection);
            var fireAction = character.GetAction(ObjectAPI.FireAction);

            _moveController = new MoveController(moveDirection);
            _fireController = new FireController(fireAction);
        }

        public void Update()
        {
            _moveController.Update();
            _fireController.Update();
        }
    }
}