﻿using SDL2;

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

        public GameObject()
        {
            componentList = new();
            Init();
        }

        public GameObject(int _posX, int _posY, char _shape, int _orderLayer, string _fileName)
        {
            //컴포넌트
            componentList = new();
            Init();
            
        }

        public void Init()
        {
            transform = AddComponent<Transform>(new Transform());
        }

        public T AddComponent<T>(T _addComponent) where T : Component
        {
            componentList.Add(_addComponent);
            _addComponent.gameObject = this;
            return _addComponent;
        }

        public virtual void Update()
        {
            
        }

        
    }
}
