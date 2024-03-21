using System;
using Atomic.Elements;
using Atomic.Extensions;
using Atomic.Objects;
using GameEngine.Data;
using Gameplay;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameEngine.Actions
{
    [Serializable]
    public class SpawnBulletAction:IAtomicAction
    {
        private AtomicObject _bullet;
        private Transform _firePoint;
        private GameObject _bulletPrefab;
        
        public void Compose(Transform firePoint,GameObject bulletPrefab)
        {
            _firePoint = firePoint;
            _bulletPrefab = bulletPrefab;
        }

        public void Invoke()
        {
            var bullet = Object.Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation, null);
            _bullet = bullet.GetComponent<Bullet>();
            var moveDirection=_bullet.GetVariable<Vector3>(ObjectAPI.MoveDirection);
            moveDirection.Value = _firePoint.transform.forward;
        }
    }
}