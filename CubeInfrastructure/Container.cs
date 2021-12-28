using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CubeInfrastructure
{
    public class Container
    {
        private static Container _instance;
        private readonly Dictionary<Type, Type> types = new ();

        private Container()
        {

        }

        public static Container Instance()
        {
            if (_instance == null)
            {
                _instance = new Container();
            }
            return _instance;
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            types.Add (typeof (TInterface), typeof (TImplementation));
        }

        public void ResgisterController(Type type)
        {
            types.Add(type, type);
        }

        public TInterface Create<TInterface>()
        {
            return (TInterface)Create(typeof(TInterface));

        }

        public object Create(Type type)
        {
            var concreteType = types[type];
            var defaultConstructor = concreteType.GetConstructors()[0];
            var defaultParams = defaultConstructor.GetParameters();
            var parameters = defaultParams.Select(param => Create(param.ParameterType)).ToArray();

            return defaultConstructor.Invoke(parameters);
        }
    }
}
