using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [Header("ÝçeridenGerekenler")]
    Rigidbody[] rigidbodies;
    Animator anim;
    // Ragdoll ragdoll;



    [Header("PosizyonDegisimAyarlari")]
    //[SerializeField] private float kuvvet;
    private float kuvvet;  //Maksimum 30-40 olabilir
    [SerializeField] private float kuvvetDegisim;

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

    public void LaunchingCharacter(float sayi)
    {
        foreach (var rigidBody in rigidbodies)
        {
            rigidBody.useGravity = false;
            rigidBody.velocity = Vector3.one * Random.Range(-2f, 2f);
        }
        kuvvet = 12 + sayi * 12;
        Debug.Log(20 + kuvvet * 20);
        isJumping = true;

        RagdollAktif();
    }

    private void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            if (isJumping)
            {
                transform.Translate(Vector3.up * Time.deltaTime * kuvvet);
                if(kuvvet <= 0)
                {
                    kuvvetDegisim = Mathf.Abs(kuvvet) / 7;
                }
                else
                {
                    kuvvetDegisim = 0;
                }
                
                kuvvet = kuvvet - (12 - kuvvetDegisim) * Time.deltaTime;
            }

            if (transform.position.y <= 5 && kuvvet < 0 && isJumping)
            {
                isJumping = false;
                foreach (var rigidBody in rigidbodies)
                {
                    rigidBody.velocity = -Vector3.up * 15;
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
