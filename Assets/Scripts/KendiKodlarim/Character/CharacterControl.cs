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
    private bool hasBegan;

    [SerializeField] private GameObject obj_indicator;


    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        ragdoll = new Ragdoll(transform);
        indicator = new Indicator(transform);

        isJumping = false;
        hasFallen = false;

        hasBegan = false;
        StartCoroutine(StartControl());
    }

    private IEnumerator StartControl()
    {
        while(true)
        {
            if(GameController.instance.isContinue)
            {
                hasBegan = true;
                break;
            }
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (hasBegan)
        {
            if (isJumping)
            {
                transform.Translate(Vector3.up * Time.deltaTime * kuvvet);
                if (kuvvet >= 0)
                {
                    kuvvetDegisim = Mathf.Abs(kuvvet) / 7;
                }
                else if (!hasFallen)
                {
                    if (transform.parent.transform.gameObject == transform.parent.transform.parent.transform.GetChild(0).transform.gameObject)
                    {
                        GameController.instance.isContinue = false;
                        indicator.CreateIndicator(obj_indicator);
                    }

                    GameController.instance.SetScore((int)transform.position.y * 25);

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
        kuvvet = 12 + sayi * (12 + PlayerPrefs.GetFloat("Strength") * Random.Range(1.98f, 2.02f));

        if (kuvvet >= 77.25f)
        {
            kuvvet = 77.25f;
        }

        isJumping = true;
        ragdoll.LaunchingCharacter();
    }
}
