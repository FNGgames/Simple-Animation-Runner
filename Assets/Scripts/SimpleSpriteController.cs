using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SimpleSpriteController : AnimationController<SpriteData>
{ }

[Serializable]
public class SpriteData : AnimationData
{
    public Sprite sprite;
    private SpriteRenderer _sr;

    protected override void GetReferences()
    {
        _sr = gameObject.GetComponent<SpriteRenderer>();
        if (_sr == null) throw new Exception("Sprite Animator Requires Sprite Renderer Component");
    }

    public override void Activate()
    {
        _sr.sprite = sprite;
    }
}