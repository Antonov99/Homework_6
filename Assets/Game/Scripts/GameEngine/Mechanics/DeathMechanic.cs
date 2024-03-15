using Atomic.Elements;

namespace GameEngine.Mechanics
{
    public class DeathMechanic
    {
        private readonly IAtomicObservable<int> _hitPoints;
        private readonly IAtomicEvent _deathEvent;

        public DeathMechanic(IAtomicObservable<int> hitPoints, IAtomicEvent deathEvent)
        {
            _hitPoints = hitPoints;
            _deathEvent = deathEvent;
        }

        public void OnEnable()
        {
            _hitPoints.Subscribe(OnHitPointsChanged);
        }        
        
        public void OnDisable()
        {
            _hitPoints.Unsubscribe(OnHitPointsChanged);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            if (hitPoints < 1)
            {
                _deathEvent.Invoke();
            }
        }
    }
}