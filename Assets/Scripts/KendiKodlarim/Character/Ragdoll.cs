using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [Header("ÝçeridenGerekenler")]
    Rigidbody[] rigidbodies;
    Animator anim;
   // Ragdoll ragdoll;



    [SerializeField] private float kuvvet;
    private bool isJumping;

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        //  ragdoll = GetComponent<Ragdoll>();
        isJumping = false;

          rigidbodies = transform.GetChild(0).GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
        }
    }

    public void LaunchingCharacter()
    {
        foreach (var rigidBody in rigidbodies)
        {
            // rigidBody.velocity = Vector3.up * kuvvet;
            rigidBody.useGravity = false;
            isJumping = true;
        }
        RagdollAktif();
    }

    private void FixedUpdate()
    {
        if(GameController.instance.isContinue)
        {
            if (isJumping)
            {
                transform.Translate(Vector3.up * Time.deltaTime * kuvvet);
                kuvvet = kuvvet - 10 * Time.deltaTime;
            }

            if (transform.position.y <= 3 && kuvvet < 0 && isJumping)
            {
                isJumping = false;
                foreach (var rigidBody in rigidbodies)
                {
                    rigidBody.velocity = -Vector3.up * 12;
                    rigidBody.useGravity = true;
                }
            }
        }
    }


    public void RagdollPasif()
    {
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = true;
        }
        anim.enabled = true;
    }

    public void RagdollAktif()
    {
        foreach (var rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        anim.enabled = false;
    }
}
