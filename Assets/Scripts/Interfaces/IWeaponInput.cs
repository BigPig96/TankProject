namespace TankProject.Interfaces
{
    public interface IWeaponInput
    {
        bool IsAttack();
        bool PreviousWeapon();
        bool NextWeapon();
    }
}
