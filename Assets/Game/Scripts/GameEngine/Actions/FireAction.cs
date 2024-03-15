using System;
using Atomic.Elements;
using Sirenix.OdinInspector;

namespace GameEngine.Actions
{
    [Serializable]
    public class FireAction:IAtomicAction
    {
        private IAtomicAction _spawnBulletAction;
        private IAtomicValue<bool> _shootCondition;
        private IAtomicVariable<int> _bullets;
        private IAtomicEvent _fireEvent;
        
        public void Compose(IAtomicAction spawnBulletAction,IAtomicValue<bool> shootCondition,IAtomicVariable<int> bullets, IAtomicEvent fireEvent)
        {
            _spawnBulletAction = spawnBulletAction;
            _shootCondition = shootCondition;
            _bullets = bullets;
            _fireEvent = fireEvent;
        }
        
        [Button]
        public void Invoke()
        {
            if(!_shootCondition.Value) return;

            _spawnBulletAction.Invoke();
            _bullets.Value--;
            _fireEvent.Invoke();
        }
    }
}