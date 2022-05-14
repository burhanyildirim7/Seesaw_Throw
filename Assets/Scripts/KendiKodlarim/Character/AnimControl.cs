using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorSystem
{
    public class AnimControl : MonoBehaviour
    {
        private Transform _transform;
        private Animator anim;

        private int sayi;

        public AnimControl(Transform transform)
        {
            _transform = transform;
            anim = _transform.GetChild(0).transform.gameObject.GetComponent<Animator>();
        }

        public void ChangeAnim()
        {
            sayi = Random.Range(1, 4);
            anim.SetInteger("AnimNumber", sayi);
        }
    }

}
