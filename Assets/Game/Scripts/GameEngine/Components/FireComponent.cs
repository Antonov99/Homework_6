using System;
using Atomic.Elements;
using Atomic.Objects;
using GameEngine.Actions;
using GameEngine.Data;
using GameEngine.Functions;
using GameEngine.Mechanics;
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
        public AtomicVariable<float> reloadDuration;

        public AddBulletsMechanic addBulletsMechanic;
        
        [Get(ObjectAPI.FireAction)]
        public FireAction fireAction;

        public void Compose()
        {
            spawnBulletAction.Compose(firePoint,bulletPrefab);
            shootCondition.Compose(bullets,fireEnabled);
            fireAction.Compose(spawnBulletAction,shootCondition,bullets,fireEvent);

            addBulletsMechanic = new AddBulletsMechanic(bullets, reloadDuration);
        }

        public void Update()
        {
            addBulletsMechanic.Update();
        }

        public void Dispose()
        {
            fireEvent?.Dispose();
            fireEnabled?.Dispose();
            bullets?.Dispose();
        }
    }
}