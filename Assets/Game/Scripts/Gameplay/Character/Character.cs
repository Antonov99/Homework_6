using Atomic.Objects;
using UnityEngine;

namespace Gameplay.Character
{
    public sealed class Character: AtomicObject
    {
        [Section]
        [SerializeField] 
        private CharacterCore characterCore;

        [Section]
        [SerializeField] 
        private CharacterView characterView;

        public override void Compose()
        {
            base.Compose();
            characterCore.Compose();
            characterView.Compose(characterCore);
        }

        private void Awake()
        {
            Compose();
        }

        private void OnEnable()
        {
            characterCore.OnEnable();
            characterView.OnEnable();
        }
        
        private void OnDisable()
        {
            characterCore.OnDisable();
            characterView.OnDisable();
        }
        
        private void Update()
        {
            characterCore.Update();
            characterView.Update();
        }

        private void OnDestroy()
        {
            characterCore.Dispose();
        }
    }
}