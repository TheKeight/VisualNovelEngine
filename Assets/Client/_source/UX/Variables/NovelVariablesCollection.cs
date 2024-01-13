using System.Collections.Generic;
using DevourDev.Unity.NovelEngine.Entities.Interfaces;

namespace NovelEngine.UX.Variables
{
    public sealed class NovelVariablesCollection
    {
        private sealed class Container<T>
        {
            public T Value { get; set; }
        }


        private readonly Dictionary<object, object> _dict = new();


        public T GetValueOrDefault<T>(NovelVariable<T> variable)
        {
            if (!_dict.TryGetValue(variable, out var container))
            {
                return variable.DefaultValue;
            }

            return ((Container<T>)container).Value;
        }

        public void SetValue<T>(NovelVariable<T> variable, T value)
        {
            GetOrCreateContainer(variable).Value = value;
        }

        private Container<T> GetOrCreateContainer<T>(NovelVariable<T> variable)
        {
            if (!_dict.TryGetValue(variable, out var container))
            {
                container = new Container<T>()
                {
                    Value = variable.DefaultValue
                };

                _dict[variable] = container;
            }

            return (Container<T>)container;
        }
    }
}
