using System;

namespace GameEngine.GameEngine.Data
{
    [Serializable]
    public sealed class Countdown
    {
        private float _duration;
        private float _currentTime;

        public Countdown()
        {
        }

        public Countdown(float duration)
        {
            _duration = duration;
        }

        public bool IsPlaying()
        {
            return _currentTime > 0;
        }

        public bool IsStopped()
        {
            return _currentTime <= 0;
        }

        public void Tick(float deltaTime)
        {
            _currentTime = Math.Max(_currentTime-deltaTime,0);
        }

        public void Reset()
        {
            _currentTime = _duration;
        }
    }
}