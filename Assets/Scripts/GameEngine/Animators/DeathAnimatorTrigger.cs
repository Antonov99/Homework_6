using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Animators
{
    public class DeathAnimatorTrigger
    {
        private static readonly int Death=Animator.StringToHash("Death");
        private readonly IAtomicEvent _death;
        private readonly Animator _animator;

        public DeathAnimatorTrigger(IAtomicEvent death, Animator animator)
        {
            _death = death;
            _animator = animator;
        }

        public void OnEnable()
        {
            _death.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _death.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
            _animator.SetTrigger(Death);
        }
    }
}