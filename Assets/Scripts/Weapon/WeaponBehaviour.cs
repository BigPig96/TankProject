using System;
using UnityEngine;

namespace TankProject.Weapon
{
    public abstract class WeaponBehaviour : MonoBehaviour
    {
        protected enum WeaponState
        {
            Idle,
            DelayBetweenShots
        }
        
        [SerializeField] private float delayBetweenShots;

        private float _waitBetweenShots;
        
        protected WeaponState State;

        protected virtual void Update()
        {
            WaitShotsDelayProcess();
        }

        private void WaitShotsDelayProcess()
        {
            if(State != WeaponState.DelayBetweenShots) return;
            _waitBetweenShots += Time.deltaTime;
            if(_waitBetweenShots < delayBetweenShots) return;
            State = WeaponState.Idle;
            _waitBetweenShots = 0;
        }
        
        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public virtual void Initialize()
        {
            State = WeaponState.Idle;
        }
        
        public void Fire()
        {
            if(State == WeaponState.Idle) Launch();
            State = WeaponState.DelayBetweenShots;
        }
        
        protected abstract void Launch();
    }
}
