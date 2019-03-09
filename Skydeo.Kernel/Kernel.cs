using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace Skydeo.Kernel
{
    /// <summary>
    /// Static class used to managed dependancy injection.
    /// </summary>
    public static class Kernel
    {
        #region Instance variables

        /// <summary>
        /// Unity container used to register and resolve types. 
        /// </summary>
        private static readonly UnityContainer s_Container;

        #endregion //Instance variables

        #region Constructors

        /// <summary>
        /// Kernel constructor.
        /// Create UnityContainer instance.
        /// </summary>
        static Kernel()
        {
            s_Container = new UnityContainer();
        }

        #endregion //Constructors

        #region Methods

        /// <summary>
        /// <see cref="UnityContainer.Resolve"/>
        /// </summary>
        public static T Resolve<T>()
        {
            return s_Container.Resolve<T>();
        }

        /// <summary>
        /// <see cref="UnityContainer.Resolve"/>
        /// </summary>
        public static bool TryResolve<T>(out T output)
        {
            try
            {
                output = s_Container.Resolve<T>();
                return true;
            }
            catch (Exception)
            {
                output = default(T);
                return false;
            }
        }

        /// <summary>
        /// <see cref="UnityContainer.Resolve"/>
        /// </summary>
        public static object Resolve(Type type)
        {
            return s_Container.Resolve(type);
        }

        /// <summary>
        /// <see cref="UnityContainer.Resolve"/>
        /// </summary>
        public static bool TryResolve(Type type, out object output)
        {
            try
            {
                output = s_Container.Resolve(type);
                return true;
            }
            catch (Exception)
            {
                output = null;
                return false;
            }
        }

        /// <summary>
        /// <see cref="UnityContainer.ResolveAll"/>
        /// </summary>
        public static IEnumerable<T> ResolveCollection<T>()
        {
            return s_Container.ResolveAll(typeof(T)).Select(i => (T)i);
        }

        /// <summary>
        /// <see cref="UnityContainer.ResolveAll"/>
        /// </summary>
        public static IEnumerable<object> ResolveCollection(Type type)
        {
            return s_Container.ResolveAll(type);
        }

        /// <summary>
        /// <see cref="UnityContainer.RegisterInstance"/>
        /// </summary>
        internal static void RegisterInstance<T>(T instance)
        {
            s_Container.RegisterInstance<T>(instance);
        }

        #endregion //Methods
    }
}
