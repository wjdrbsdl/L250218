
using L250218;

public abstract class Component
{
    public virtual void Awake()
    {

    }

    public abstract void Update();

    public T GetComponet<T>() where T : Component
    {
        foreach(Component component in gameObject.componentList)
        {
            if(component is T)
            {
                return component as T;
            }
        }

        return null;
    }

    public GameObject gameObject;
}
