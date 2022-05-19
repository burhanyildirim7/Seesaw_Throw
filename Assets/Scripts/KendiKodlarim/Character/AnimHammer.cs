using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimHammerSystem
{
    public class AnimHammer
    {
        Transform _transform;
        Animator _anim;

        public AnimHammer(Transform transform)
        {
            _transform = transform;
            _anim = _transform.GetComponentInChildren<Animator>();

        }

        public void Anim1Uygula()
        {
            _anim.SetTrigger("Anim1");
        }

        public void Anim2Uygula()
        {
            _anim.SetTrigger("Anim2");
        }
    }
}

