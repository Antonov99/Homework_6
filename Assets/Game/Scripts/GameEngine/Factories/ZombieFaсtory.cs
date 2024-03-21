using System.Collections.Generic;
using GameEngine.GameEngine.Data;
using UnityEngine;

namespace GameEngine.Factories
{
    public class ZombieFaсtory
    {
        private readonly GameObject _zombiePrefab;
        private readonly List<Transform> _spawnPositions;
        private int _positionNumber;
        private readonly Quaternion _rotation;
        private readonly Countdown _countdown;

        public ZombieFaсtory(GameObject zombiePrefab, List<Transform> spawnPositions, Countdown countdown)
        {
            _zombiePrefab = zombiePrefab;
            _spawnPositions = spawnPositions;
            _countdown = countdown;
            _rotation = _zombiePrefab.transform.rotation;
        }

        public void Update()
        {
            _countdown.Tick(Time.deltaTime);
            if (_countdown.IsPlaying()) return;
            _countdown.Reset();
            SpawnZombie();
        }

        private void SpawnZombie()
        {
            _positionNumber = Random.Range(0, _spawnPositions.Count);
            Object.Instantiate(_zombiePrefab, _spawnPositions[_positionNumber].position, _rotation, null);
        }
    }
}