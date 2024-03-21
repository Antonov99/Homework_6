using System;
using GameEngine.Animators;
using UnityEngine;

namespace Gameplay.Zombie
{
    [Serializable]
    public class ZombieView
    {
        [SerializeField]
        private Animator animator;

        [SerializeField] 
        private AudioSource audio;

        [SerializeField]
        private AudioClip deathSound;
        
        private MovingAnimatorController _movingAnimatorController;
        private DeathAnimatorTrigger _deathAnimatorTrigger;
        
        public void Compose(ZombieCore zombieCore)
        {
            _movingAnimatorController = new MovingAnimatorController(animator, zombieCore.moveComponent.isMoving);
            _deathAnimatorTrigger = new DeathAnimatorTrigger(zombieCore.healthComponent.deathEvent,animator);
            
            zombieCore.healthComponent.deathEvent.Subscribe(()=>audio.PlayOneShot(deathSound));
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