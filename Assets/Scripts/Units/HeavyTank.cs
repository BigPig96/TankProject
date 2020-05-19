using System;
using ObjectPool;
using TankProject.Interfaces;
using UnityEngine;
using Zenject;

namespace TankProject.Units
{
    public sealed class HeavyTank : MovableUnitBehaviour, ObjectPool.IPoolable<HeavyTank>
    {
        public static HeavyTank Tank { get; private set; }
        public Pool<HeavyTank> Pool { get; set; }
        public static event Action OnPlayerDie;
        
        [SerializeField] private TowerBehaviour towerBehaviour;

        private IWeaponInput _weaponInput;
        private IController<IWeaponInput> _weaponController;

        private Explode _explode;

        [Inject]
        private void InstallBindings(Explode explode)
        {
            _explode = explode;
        }

        protected override void Awake()
        {
            base.Awake();
            
            Tank = this;
            
            _weaponInput = GetComponent<IWeaponInput>();
            _weaponController = GetComponent<IController<IWeaponInput>>();
        }

        protected override void OnDie()
        {
            Explode();
            OnPlayerDie?.Invoke();
            
            base.OnDie();
        }

        public override void Disable()
        {
            base.Disable();
            
            Pool?.ToPool(this);
        }

        protected override void Update()
        {
            base.Update();
            
            Weapon();
            RotateTower();
        }

        private void RotateTower()
        {
            towerBehaviour.Rotate();
        }

        private void Weapon()
        {
            _weaponController.Control(_weaponInput);
        }

        private void Explode()
        {
            Vector2 position = transform.position;
            _explode.Execute(position);
        }
    }
}
