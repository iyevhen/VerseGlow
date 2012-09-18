using System;
using System.Collections.Generic;

namespace FreePresenter.UI
{
	public static partial class IoC
	{
		private static readonly Dictionary<Type, Type> registration = new Dictionary<Type, Type>();
		private static readonly Dictionary<Type, object> rot = new Dictionary<Type, object>();
		private static readonly object[] emptyArguments = new object[0];
		private static readonly object syncLock = new object();

		static partial void Initialize();

		static IoC()
		{
			Initialize();
		}

		public static T Resolve<T>()
		{
			return (T)Resolve(typeof(T));
		}

		public static object Resolve(Type type)
		{
			lock (syncLock)
			{
				if (!rot.ContainsKey(type))
				{
					if (!registration.ContainsKey(type))
						throw new ApplicationException(string.Format("Type [{0}] not registered.", type.Name));

					var resolveTo = registration[type] ?? type;
					var constructorInfos = resolveTo.GetConstructors();

					if (constructorInfos.Length > 1)
						throw new Exception(string.Format("Cannot resolve a type [{0}] that has more than one constructor.", type.Name));

					var constructor = constructorInfos[0];
					var parameterInfos = constructor.GetParameters();

					if (parameterInfos.Length == 0)
					{
						rot[type] = constructor.Invoke(emptyArguments);
					}
					else
					{
						var parameters = new object[parameterInfos.Length];

						foreach (var parameterInfo in parameterInfos)
							parameters[parameterInfo.Position] = Resolve(parameterInfo.ParameterType);

						rot[type] = constructor.Invoke(parameters);
					}
				}
				return rot[type];
			}
		}

		public static void Register<TInterface, TImplementation>() where TImplementation : class, TInterface
		{
			lock (syncLock)
			{
				registration.Add(typeof(TInterface), typeof(TImplementation));
			}
		}

		public static void Register<TImplementation>() where TImplementation : class
		{
			lock (syncLock)
			{
				registration.Add(typeof(TImplementation), null);
			}
		}
	}
}