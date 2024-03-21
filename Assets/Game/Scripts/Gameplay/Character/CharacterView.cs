using System;
using GameEngine.Animators;
using UnityEngine;
using TMPro;

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

        [SerializeField] 
        private GameObject gameOverPopup;

        [SerializeField] 
        private TextMeshProUGUI hpText;

        [SerializeField] 
        private TextMeshProUGUI bulletsText;

        private MovingAnimatorController _movingAnimatorController;
        private DeathAnimatorTrigger _deathAnimatorTrigger;

        public void Compose(CharacterCore characterCore)
        {
            _movingAnimatorController = new MovingAnimatorController(animator, characterCore.moveComponent.isMoving);
            _deathAnimatorTrigger = new DeathAnimatorTrigger(characterCore.healthComponent.deathEvent, animator);

            characterCore.fireComponent.fireEvent.Subscribe(() => shootVFX.Play(withChildren: true));
            characterCore.fireComponent.fireEvent.Subscribe(() => audio.PlayOneShot(shootSound));
            characterCore.healthComponent.deathEvent.Subscribe(() => audio.PlayOneShot(deathSound));
            characterCore.healthComponent.deathEvent.Subscribe(() => gameOverPopup.SetActive(true));

            characterCore.healthComponent.hitPoints.Subscribe((hp) => hpText.text = "HIT POINTS: " + hp);
            characterCore.fireComponent.bullets.Subscribe((bullets) => bulletsText.text = "BULLETS: " + bullets);
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