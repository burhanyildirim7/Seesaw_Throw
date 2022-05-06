using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RagdollSystem;

public class CharacterControl : MonoBehaviour
{

    [Header("PosizyonDegisimAyarlari")]
    private float kuvvet;  //Maksimum 30-40 olabilir
    [SerializeField] private float kuvvetDegisim;

    private bool isJumping;

    [Header("AnimasyonAyarlari")]
    private Animator anim;

    [Header("RagdollAyarlari")]
    private Ragdoll ragdoll;


    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        ragdoll = new Ragdoll(transform);

        isJumping = false;
    }

    private void FixedUpdate()
    {
        if (GameController.instance.isContinue)
        {
            if (isJumping)
            {
                transform.Translate(Vector3.up * Time.deltaTime * kuvvet);
                if (kuvvet >= 0)
                {
                    kuvvetDegisim = Mathf.Abs(kuvvet) / 7;
                }
                else
                {
                    Debug.Log("Dusme tamamlandi");
                    kuvvetDegisim = 0;
                }

                kuvvet = kuvvet - (12 - kuvvetDegisim) * Time.deltaTime;
            }

            if (transform.position.y <= 2 && kuvvet < 0 && isJumping)
            {
                ragdoll.ApplyForce();
                isJumping = false;
            }
        }
    }

    public void RagdollAktif(float sayi)
    {
        anim.enabled = false;
        kuvvet = 12 + sayi * (12 + PlayerPrefs.GetFloat("Strength") * 2);
        Debug.Log(sayi);
        isJumping = true;
        ragdoll.LaunchingCharacter();
    }
}
