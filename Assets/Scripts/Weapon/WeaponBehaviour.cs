using System;
using UnityEngine;

namespace TankProject.Weapon
{
    public abstract class WeaponBehaviour : MonoBehaviour
    {
        protected enum WeaponState
        {
            Idle,
            Reloading
        }
        
        [SerializeField] private float reloadingDelay;

        private float _reloadingTimer;
        
        protected WeaponState State;

        protected void Update()
        {
            Reloading();
        }

        private void Reloading()
        {
            if(State != WeaponState.Reloading) return;
            _reloadingTimer += Time.deltaTime;
            if(_reloadingTimer < reloadingDelay) return;
            State = WeaponState.Idle;
            _reloadingTimer = 0;
        }
        
        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public abstract void Initialize();
        public abstract void Fire();
    }
}
