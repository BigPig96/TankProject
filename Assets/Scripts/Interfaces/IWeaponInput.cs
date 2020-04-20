namespace TankProject
{
    public interface IWeaponInput
    {
        bool IsAttack();
        bool PreviousWeapon();
        bool NextWeapon();
    }
}
