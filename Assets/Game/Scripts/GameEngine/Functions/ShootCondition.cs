using System;
using Atomic.Elements;

namespace GameEngine.Functions
{
    [Serializable]
    public class ShootCondition:IAtomicValue<bool>
    {
        public bool Value => _isAlive.Value && _bullets.Value > 0;

        private IAtomicValue<int> _bullets;
        private IAtomicValue<bool> _isAlive;

        public void Compose(IAtomicValue<int> bullets, IAtomicValue<bool> isAlive)
        {
            _bullets = bullets;
            _isAlive = isAlive;
        }
    }
}