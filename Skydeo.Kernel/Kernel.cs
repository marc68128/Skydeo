using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

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
        private static readonly IKernel _iocKernel;

        #endregion //Instance variables

        #region Constructors

        /// <summary>
        /// Kernel constructor.
        /// Create UnityContainer instance.
        /// </summary>
        static Kernel()
        {
            _iocKernel = new StandardKernel();
        }

        #endregion //Constructors

        #region Methods

        /// <summary>
        /// <see cref="UnityContainer.Resolve"/>
        /// </summary>
        public static T Resolve<T>()
        {
            return _iocKernel.Get<T>();
        }

        /// <summary>
        /// <see cref="UnityContainer.Resolve"/>
        /// </summary>
        public static bool TryResolve<T>(out T output)
        {
            try
            {
                output = _iocKernel.Get<T>();
                return true;
            }
            catch (Exception)
            {
                output = default(T);
                return false;
            }
        }

        /// <summary>
        /// <see cref="UnityContainer.ResolveAll"/>
        /// </summary>
        public static IEnumerable<T> ResolveCollection<T>()
        {
            return _iocKernel.GetAll<T>();
        }

        /// <summary>
        /// <see cref="UnityContainer.RegisterInstance"/>
        /// </summary>
        internal static void RegisterInstance<T>(T instance)
        {
            _iocKernel.Bind<T>().ToConstant(instance);
        }

        #endregion //Methods
    }
}
