using System;
using Atomic.Elements;
using GameEngine.Actions;
using GameEngine.Mechanics;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class BulletComponent
    {
        private BulletCollisionMechanic _bulletCollisionMechanic;
        private DealDamageAction _dealDamageAction;
        
        public AtomicValue<int> damage;

        public void Compose()
        {
            _dealDamageAction=new DealDamageAction(damage);
            _bulletCollisionMechanic = new BulletCollisionMechanic(_dealDamageAction);
        }

        public void OnCollisionEnter(Collision collision)
        {
            _bulletCollisionMechanic.OnCollisionEnter(collision);
        }
    }
}