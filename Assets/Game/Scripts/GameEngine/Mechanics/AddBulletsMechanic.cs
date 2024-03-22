using Atomic.Elements;
using GameEngine.GameEngine.Data;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class AddBulletsMechanic
    {
        private readonly Countdown _countdown;
        private readonly IAtomicVariable<int> _bullets;

        public AddBulletsMechanic(IAtomicVariable<int> bullets, IAtomicVariable<float> reloadDuration)
        {
            _bullets = bullets;
            _countdown = new Countdown(reloadDuration.Value);
        }

        public void Update()
        {
            if (_bullets.Value > 9) return;
            
            _countdown.Tick(Time.deltaTime);
            if (_countdown.IsStopped())
            {
                _bullets.Value++;
                _countdown.Reset();
            }
        }
    }
}