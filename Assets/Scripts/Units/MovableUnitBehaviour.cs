using TankProject.Interfaces;

namespace TankProject.Units
{
    public abstract class MovableUnitBehaviour : UnitBehaviour
    {
        private IMovementInput _movementInput;
        private IController<IMovementInput> _movementController;

        protected override void Awake()
        {
            base.Awake();

            _movementInput = GetComponent<IMovementInput>();
            _movementController = GetComponent<IController<IMovementInput>>();
        }

        protected virtual void Update()
        {
            Move();
        }

        private void Move()
        {
            _movementController.Control(_movementInput);
        }
    }
}
