using SDL2;
using System.Reflection;

namespace L250218
{
    public class GameObject
    {
        public List<Component> componentList;
        public Transform transform;
        public bool isCollide;
        public bool isTrigger;

        public string Name;
        public static int objectCount = 0;

        #region 생성자
        public GameObject()
        {
            componentList = new();
            Init();
        }

        public GameObject(int _posX, int _posY)
        {
            componentList = new();
            Init();
            transform.X = _posX;
            transform.Y = _posY;

        }

        public GameObject(int _posX, int _posY, char _shape, int _orderLayer, string _fileName)
        {
            //컴포넌트
            componentList = new();
            Init();
            
        }
        #endregion


        public void Init()
        {
            transform = new Transform();
            AddComponent<Transform>(new Transform());
            //transform.transform = transform;
        }

        public T AddComponent<T>(T _addComponent) where T : Component
        {
            componentList.Add(_addComponent);
            _addComponent.gameObject = this;
            _addComponent.transform = transform;
            return _addComponent;
        }

        public T GetComponet<T>() where T : Component
        {
            foreach (Component component in componentList)
            {
                if (component is T)
                {
                    return component as T;
                }
            }

            return null;
        }
        
        public void ExcuteMethod(string _methodName, object[] _param)
        {
            foreach (var component in componentList)
            {
                //해당 오브젝트가 가진 컴포넌트를 모두 본다
                Type type = component.GetType();
                //함수 다 가져옴
                MethodInfo[] methodes = type.GetMethods(BindingFlags.Public 
                    | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var method in methodes)
                {
                    if (method.Name.CompareTo(_methodName) == 0)
                    {
                        method.Invoke(component, _param);
                    }
                }

            }
        }

        public static GameObject Find(string _goName)
        {
            foreach (var go in Engine.Instance.GameObjectList)
            {
                if(go.Name.CompareTo(_goName) == 0)
                {
                    return go;
                }
            }
            return null;
        }
    }
}
