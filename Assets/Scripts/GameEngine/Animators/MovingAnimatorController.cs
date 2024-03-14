using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Animators
{
    public sealed class MovingAnimatorController
    {
        private static readonly int IsMoving = Animator.StringToHash("Move");

        private readonly Animator _animator;
        private readonly IAtomicValue<bool> _isMoving;

        public MovingAnimatorController(Animator animator, IAtomicValue<bool> isMoving)
        {
            _animator = animator;
            _isMoving = isMoving;
        }

        public void Update()
        {
            _animator.SetBool(IsMoving,_isMoving.Value);
        }
    }
}