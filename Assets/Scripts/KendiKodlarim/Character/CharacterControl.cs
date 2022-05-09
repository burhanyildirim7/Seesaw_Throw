using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RagdollSystem;
using IndicatorSystem;

public class CharacterControl : MonoBehaviour
{

    [Header("PosizyonDegisimAyarlari")]
    public float kuvvet;  //Maksimum 30-40 olabilir
    [SerializeField] private float kuvvetDegisim;

    [Header("AnimasyonAyarlari")]
    private Animator anim;

    [Header("nameSpaceKullanimlari")]
    private Ragdoll ragdoll;
    private Indicator indicator;


    private bool isJumping;
    private bool hasFallen;

    [SerializeField] private GameObject obj_indicator;


    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        ragdoll = new Ragdoll(transform);
        indicator = new Indicator(transform);

        isJumping = false;
        hasFallen = false;
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
                else if(!hasFallen)
                {
                    indicator.CreateIndicator(obj_indicator);
                    kuvvetDegisim = 0;
                    hasFallen = true;
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
        kuvvet = 12 + sayi * (12 + PlayerPrefs.GetFloat("Strength") * Random.Range(1.8f, 2.2f));
        Debug.Log(kuvvet);
        isJumping = true;
        ragdoll.LaunchingCharacter();
    }
}
