namespace TankProject
{
    public interface IController<in T>
    {
        void Control(T input);
    }
}