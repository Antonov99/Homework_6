using System;

namespace GameEngine.Mechanics
{
    public class UpdateMechanics
    {
        private readonly Action _action;

        public UpdateMechanics(Action action)
        {
            _action = action;
        }

        public void Update()
        {
            _action?.Invoke();
        }
    }
}