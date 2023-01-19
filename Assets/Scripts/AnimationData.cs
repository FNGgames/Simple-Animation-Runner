using System;
using UnityEngine;

[Serializable]
public abstract class AnimationData
{
    public Key key;
    protected GameObject gameObject;

    public KeyCode KeyCode { get; protected set; }

    public virtual void Initialize(GameObject gameObject)
    {
        this.gameObject = gameObject;
        KeyCode = key.ToKeyCode();
        GetReferences();
    }

    protected abstract void GetReferences();

    public abstract void Activate();
}