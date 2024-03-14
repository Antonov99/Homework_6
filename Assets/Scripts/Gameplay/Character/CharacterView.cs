using System;
using GameEngine.Animators;
using UnityEngine;

namespace Gameplay.Character
{
    [Serializable]
    public class CharacterView
    {
        [SerializeField]
        private Animator animator;

        [SerializeField] 
        private ParticleSystem shootVFX;

        [SerializeField] 
        private AudioSource audio;

        [SerializeField]
        private AudioClip shootSound;

        [SerializeField]
        private AudioClip deathSound;
        
        private MovingAnimatorController _movingAnimatorController;
        private DeathAnimatorTrigger _deathAnimatorTrigger;
        
        public void Compose(CharacterCore characterCore)
        {
            _movingAnimatorController = new MovingAnimatorController(animator, characterCore.moveComponent.isMoving);
            _deathAnimatorTrigger = new DeathAnimatorTrigger(characterCore.healthComponent.deathEvent,animator);
            
            characterCore.fireComponent.fireEvent.Subscribe(()=>shootVFX.Play(withChildren:true));
            characterCore.fireComponent.fireEvent.Subscribe(()=>audio.PlayOneShot(shootSound));
            characterCore.healthComponent.deathEvent.Subscribe(()=>audio.PlayOneShot(deathSound));
        }

        public void OnEnable()
        {
            _deathAnimatorTrigger.OnEnable();
        }

        public void OnDisable()
        {
            _deathAnimatorTrigger.OnDisable();
        }

        public void Update()
        {
            _movingAnimatorController.Update();
        }
    }
}