using System;
using Atomic.Elements;

namespace GameEngine.Mechanics
{
    public class TakeDamageMechanic
    {
        private readonly IAtomicObservable<int> _takeDamageEvent;
        private readonly IAtomicVariable<int> _hitPoints;

        public TakeDamageMechanic(IAtomicObservable<int> takeDamageEvent, IAtomicVariable<int> hitPoints)
        {
            _takeDamageEvent = takeDamageEvent;
            _hitPoints = hitPoints;
        }

        public void OnEnable()
        {
            _takeDamageEvent.Subscribe(OnTakeDamage);
        }

        public void OnDisable()
        {
            _takeDamageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int damage)
        {
            if(_hitPoints.Value>0) _hitPoints.Value = Math.Max(0, _hitPoints.Value - damage);
        }
    }
}