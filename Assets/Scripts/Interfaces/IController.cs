namespace TankProject.Interfaces
{
    public interface IController<in T>
    {
        void Control(T input);
    }
}