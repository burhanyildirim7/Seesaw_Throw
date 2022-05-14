using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotateSystem
{
    public class RotateControl 
    {
        private Transform _transform;
        private Vector3 _randomRotate;

        public RotateControl(Transform transform)
        {
            _transform = transform;
            _randomRotate = Vector3.forward * Random.Range(-1f, 1f) + Vector3.up * Random.Range(-1f, 1f) + Vector3.right * Random.Range(-1f, 1f);
        }

        public void RotateCharacter()
        {
            _transform.Rotate(_randomRotate * Time.deltaTime * 50);
        }
    }

}
