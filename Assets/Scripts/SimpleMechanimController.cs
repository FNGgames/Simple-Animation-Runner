namespace DefaultNamespace
{
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    public class SimpleMechanimController : AnimationController<MechanimData>
    {
    }

    [Serializable]
    public class MechanimData : AnimationData
    {
        public AnimationClip clip;
        
        private Animator _animator;

        protected override void GetReferences()
        {
            _animator = gameObject.GetComponent<Animator>();
            
            if (_animator == null)
                throw new NullReferenceException("Animator Requires Sprite Renderer Component");
        }

        public override void Activate()
        {
            _animator.Play(clip.name);
        }
    }
}