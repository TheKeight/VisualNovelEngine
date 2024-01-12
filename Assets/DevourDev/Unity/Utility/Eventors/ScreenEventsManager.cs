using UnityEngine;

namespace DevourDev.Unity.Utility.Eventers
{
    public static class ScreenEventsManager
    {
        public delegate void ResolutionChangedEventArgs(Vector2 previousResolution, Vector2 newResolution);

        public interface IResolutionListener
        {
            Vector2 Resolution { get; }
            float WidthToHeightRatio { get; }
            float HeightToWidthRatio { get; }

            event ResolutionChangedEventArgs ResolutionChanged;
        }

        private sealed class ResolutionListenerProxy : IResolutionListener
        {
            private ResolutionListenerComponent _listener;

            public Vector2 Resolution => _listener != null ? _listener.Resolution : GetResolution();

            public float WidthToHeightRatio
            {
                get
                {
                    var resolution = Resolution;
                    return resolution.x / resolution.y;
                }
            }

            public float HeightToWidthRatio
            {
                get
                {
                    var resolution = Resolution;
                    return resolution.y / resolution.x;
                }
            }


            public event ResolutionChangedEventArgs ResolutionChanged
            {
                add
                {
                    if (_listener == null)
                    {
                        _listener = new GameObject(nameof(ResolutionListener)).AddComponent<ResolutionListenerComponent>();
                        GameObject.DontDestroyOnLoad(_listener.gameObject);
                    }

                    _listener.ResolutionChanged += value;
                }

                remove
                {
                    if (_listener == null)
                        return;

                    _listener.ResolutionChanged -= value;
                }
            }


            private Vector2 GetResolution()
            {
                return new(Screen.width, Screen.height);
            }
        }

        private sealed class ResolutionListenerComponent : MonoBehaviour, IResolutionListener
        {
            private Vector2 _resolution;


            public Vector2 Resolution => _resolution;
            public float WidthToHeightRatio => _resolution.x / _resolution.y;
            public float HeightToWidthRatio => _resolution.y / _resolution.x;

            public event ResolutionChangedEventArgs ResolutionChanged;


            private void Awake()
            {
                _resolution = GetResolution();
            }

            private void Update()
            {
                Vector2 newResolution = GetResolution();

                if (newResolution != _resolution)
                {
                    Vector2 prevResolution = _resolution;
                    _resolution = newResolution;
                    ResolutionChanged?.Invoke(prevResolution, newResolution);
                }
            }

            private Vector2 GetResolution()
            {
                return new(Screen.width, Screen.height);
            }
        }


        private static ResolutionListenerProxy _listenerProxy;


        public static IResolutionListener ResolutionListener
        {
            get
            {
                _listenerProxy ??= new();
                return _listenerProxy;
            }
        }


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void RuntimeInit()
        {
            _listenerProxy = null;
        }
    }
}
