using UnityEngine;

public abstract class AnimationController<T> : MonoBehaviour where T : AnimationData
{
    public ControlMode controlMode = ControlMode.Toggle;
    public T[] animationData;
    private int _activeIndex = -1;

    private void Start()
    {
        foreach (var data in animationData) 
            data.Initialize(gameObject);

        Activate(0);
    }

    private void Activate(int i)
    {
        if (_activeIndex == i) return;
        _activeIndex = i;
        animationData[i].Activate();
    }

    private void Update()
    {
        var keyPressed = false;

        for (var i = 0; i < animationData.Length; i++)
        {
            var data = animationData[i];
            if (!Input.GetKey(data.KeyCode)) continue;
            
            keyPressed = true;
            Activate(i);
            
            break;
        }
        
        if (controlMode == ControlMode.Hold && !keyPressed) Activate(0);
    }
}