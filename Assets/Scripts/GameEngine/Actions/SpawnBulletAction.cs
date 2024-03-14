using System;
using Atomic.Elements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameEngine.Actions
{
    [Serializable]
    public class SpawnBulletAction:IAtomicAction
    {
        private Transform _firePoint;
        private GameObject _bulletPrefab;

        public void Compose(Transform firePoint,GameObject bulletPrefab)
        {
            _firePoint = firePoint;
            _bulletPrefab = bulletPrefab;
        }

        public void Invoke()
        {
            Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation.normalized, null);
        }
    }
}