using System;
using Atomic.Elements;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class HealthComponent:IDisposable
    {
        [SerializeField]
        private AtomicFunction<bool> isAlive;
        public IAtomicValue<bool> IsAlive => isAlive; 
        
        public AtomicEvent deathEvent;
        public AtomicEvent<int> takeDamageEvent;
        public AtomicVariable<int> hitPoints;
        
        private TakeDamageMechanic _takeDamageMechanic;
        private DeathMechanic _deathMechanic;

        public void Compose()
        {
            isAlive.Compose(()=>hitPoints.Value>0);
            _takeDamageMechanic = new TakeDamageMechanic(takeDamageEvent, hitPoints);
            _deathMechanic = new DeathMechanic(hitPoints, deathEvent);
        }
        
        public void OnEnable()
        {
            _takeDamageMechanic.OnEnable();
            _deathMechanic.OnEnable();
        }
        
        public void OnDisable()
        {
            _takeDamageMechanic.OnDisable();
            _deathMechanic.OnDisable();
        }

        public void Dispose()
        {
            deathEvent?.Dispose();
            takeDamageEvent?.Dispose();
            hitPoints?.Dispose();
        }
    }
}