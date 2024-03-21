using System.Collections.Generic;
using Atomic.Extensions;
using Atomic.Objects;
using GameEngine.Controllers;
using GameEngine.Data;
using GameEngine.Factories;
using GameEngine.GameEngine.Data;
using UnityEngine;

namespace Gameplay.Systems
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] private AtomicObject character;

        private MoveController _moveController;
        private FireController _fireController;

        [SerializeField] private GameObject zombiePrefab;

        [SerializeField] private List<Transform> spawnPositions;

        private ZombieFaсtory _zombieFaсtory;
        [SerializeField] private Countdown countdown;
        private const float _DURATION = 2f;

        public void Start()
        {
            var moveDirection = character.GetVariable<Vector3>(ObjectAPI.MoveDirection);
            var fireAction = character.GetAction(ObjectAPI.FireAction);

            _moveController = new MoveController(moveDirection);
            _fireController = new FireController(fireAction);
            countdown = new Countdown(_DURATION);
            _zombieFaсtory = new ZombieFaсtory(zombiePrefab, spawnPositions,countdown);
        }

        public void Update()
        {
            _moveController.Update();
            _fireController.Update();
            _zombieFaсtory.Update();
        }
    }
}