using System;
using ObjectPool;
using TankProject.Managers;
using TankProject.Vfx;
using UnityEngine;

namespace TankProject.Units
{
    public sealed class HeavyTank : AliveUnitBehaviour
    {
        public static event Action OnPlayerDie;
        
        [SerializeField] private TowerBehaviour towerBehaviour;
        [SerializeField] private ExplosionData dieExplosion;

        public float LesionRadius => dieExplosion.lesionRadius;
        
        private IWeaponInput _weaponInput;
        private IController<IWeaponInput> _weaponController;

        private Explode _explode;

        protected override void Awake()
        {
            base.Awake();

            _weaponInput = GetComponent<IWeaponInput>();
            _weaponController = GetComponent<IController<IWeaponInput>>();
            
            _explode = new Explode(dieExplosion);
        }

        protected override void OnDie()
        {
            Explode();
            OnPlayerDie?.Invoke();
            
            base.OnDie();
        }

        private void Update()
        {
            Process();
        }

        private void Process()
        {
            Move();
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
