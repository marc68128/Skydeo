namespace Skydeo.Kernel
{
    /// <summary>
    /// Static class used to configure dependency injection.
    /// </summary>
    public static class KernelConfig
    {
        /// <summary>
        /// <see cref="Kernel.RegisterInstance{T}"/>
        /// </summary>
        public static void RegisterInstance<T>(T instance)
        {
            Kernel.RegisterInstance(instance);
        }
    }
}