namespace LibraryManager.Shared.IoC
{
    public abstract class ServiceContainer
    {
        public abstract void RegisterControllers();
        public abstract void EnableMvc();
    }
}