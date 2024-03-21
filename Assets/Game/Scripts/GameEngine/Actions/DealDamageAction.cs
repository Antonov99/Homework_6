using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using UnityEngine;

namespace GameEngine.Actions
{
    public sealed class DealDamageAction:IAtomicAction<IAtomicObject>
    {
        private IAtomicValue<int> _damage;

        public DealDamageAction(IAtomicValue<int> damage)
        {
            _damage = damage;
        }

        public void Invoke(IAtomicObject target)
        {
            IAtomicAction<int> damageAction = target.GetAction<int>(ObjectAPI.TakeDamageEvent);
            damageAction?.Invoke(_damage.Value);
        }
    }
}