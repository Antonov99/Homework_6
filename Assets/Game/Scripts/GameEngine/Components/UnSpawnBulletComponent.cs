using System;
using GameEngine.GameEngine.Data;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class UnSpawnBulletComponent
    {
        [SerializeField]
        private float duration;
        
        private Countdown _countdown;
        
        public void Compose()
        {
            _countdown = new Countdown(duration);
            _countdown.Reset();
        }

        public bool Update(float delta)
        {
            _countdown.Tick(delta);
            if (_countdown.IsStopped()) return true;
            return false;
        }
    }
}