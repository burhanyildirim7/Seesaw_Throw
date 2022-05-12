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

        private CapsuleCollider collider;
        

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
                if(rigidbody.mass <= 2)
                {
                   rigidbody.velocity = Vector3.one * Random.Range(-3f, 3f);
                }
                else if (rigidbody.mass >= 2 && rigidbody.mass <= 5)
                {
                    rigidbody.velocity = Vector3.one * Random.Range(-2f, 2f);
                }

                rigidbody.drag = .25f;
            }
        }

      /*  public void ApplyForce()
        {
            foreach (var rigidbody in _rigidbodies)
            {
                if(rigidbody.transform.gameObject.GetComponent<CapsuleCollider>() != null)
                {
                    collider = rigidbody.transform.gameObject.GetComponent<CapsuleCollider>();
                    collider.enabled = false;
                    

                }
                rigidbody.useGravity = true;
            }
        }*/
    }
}
