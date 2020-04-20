namespace TankProject.Units
{
    public abstract class AliveUnitBehaviour : UnitBehaviour
    {
        private IMovementInput _movementInput;
        private IController<IMovementInput> _movementController;

        protected override void Awake()
        {
            base.Awake();

            _movementInput = GetComponent<IMovementInput>();
            _movementController = GetComponent<IController<IMovementInput>>();
        }

        protected void Move()
        {
            _movementController.Control(_movementInput);
        }
    }
}
