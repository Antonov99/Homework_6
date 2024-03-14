using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Actions;
using GameEngine.Functions;
using UnityEngine;

namespace GameEngine.Components
{
    [Serializable]
    public class FireComponent:IDisposable
    {
        public AtomicVariable<bool> fireEnabled=new(true);
        public AtomicEvent fireEvent;
        
        public Transform firePoint;
        public GameObject bulletPrefab;
    
        public ShootCondition shootCondition;
        public SpawnBulletAction spawnBulletAction;
    
        public AtomicVariable<int> bullets;
        
        [Get(ObjectAPI.FireAction)]
        public FireAction fireAction;

        public void Compose()
        {
            spawnBulletAction.Compose(firePoint,bulletPrefab);
            shootCondition.Compose(bullets,fireEnabled);
            fireAction.Compose(spawnBulletAction,shootCondition,bullets,fireEvent);
        }

        public void Dispose()
        {
            fireEvent?.Dispose();
            fireEnabled?.Dispose();
            bullets?.Dispose();
        }
    }
}