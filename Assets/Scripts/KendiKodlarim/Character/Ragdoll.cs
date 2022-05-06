using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RagdollSystem
{
    public class Ragdoll
    {
        [Header("ÝçeridenGerekenler")]
        private Transform _transform;
        private Rigidbody[] _rigidbodies;
        

        public Ragdoll(Transform transform)
        {
            _transform = transform;
            _rigidbodies = _transform.GetChild(0).GetComponentsInChildren<Rigidbody>();

            foreach (var rigidBody in _rigidbodies)
            {
                rigidBody.isKinematic = true;
            }
        }

        public void LaunchingCharacter()
        {
            //Ragdoll ayarini bu kisim yapar
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = false;
                rigidbody.useGravity = false;
                rigidbody.velocity = Vector3.one * Random.Range(-2f, 2f);
            }
        }

        public void ApplyForce()
        {
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.velocity = Vector3.up * Random.Range(-15f, -5f);
                rigidbody.useGravity = true;
            }
        }
    }
}
