using Atomic.Elements;
using UnityEngine;

namespace GameEngine.Controllers
{
    public class FireController
    {
        private readonly IAtomicAction _fireAction;

        public FireController(IAtomicAction fireAction)
        {
            _fireAction = fireAction;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fireAction?.Invoke();
            }
        }
    }
}