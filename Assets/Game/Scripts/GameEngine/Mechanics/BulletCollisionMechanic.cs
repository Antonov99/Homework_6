using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class BulletCollisionMechanic
    {
        private readonly IAtomicAction<IAtomicObject> _dealDamageAction;

        public BulletCollisionMechanic(IAtomicAction<IAtomicObject> dealDamageAction)
        {
            _dealDamageAction = dealDamageAction;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent(out IAtomicObject target)) return;
            _dealDamageAction.Invoke(target);
            
        }
    }
}