using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IndicatorSystem;
using AnimatorSystem;
using RotateSystem;


public class CharacterControl : MonoBehaviour
{

    [Header("PosizyonDegisimAyarlari")]
    public float kuvvet;
    [SerializeField] private float kuvvetDegisim;

    [Header("namespaceKullanimlari")]
    private Indicator indicator;
    private AnimControl animControl;
    private RotateControl rotateControl;

    [Header("CarpismaAyarlari")]
    private SphereCollider collider;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rigidbody;

    private bool isJumping;
    private bool hasFallen;
    private bool hasBegan;
    private bool isTarget;

    private GameObject target;

    [SerializeField] private GameObject obj_indicator;
    private Transform camera;


    void Start()
    {
        indicator = new Indicator(transform);
        animControl = new AnimControl(transform);
        rotateControl = new RotateControl(transform);

        collider = GetComponent<SphereCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();

        isJumping = false;
        hasFallen = false;

        hasBegan = false;
        StartCoroutine(StartControl());

        if (transform.parent.transform.parent.transform.gameObject != transform.gameObject)
        {
            target = transform.parent.transform.parent.transform.GetChild(0).transform.GetChild(0).gameObject;
        }

        camera = GameObject.FindObjectOfType<CameraMovement>().transform;
    }

    private IEnumerator StartControl()
    {
        while (true)
        {
            if (GameController.instance.isContinue)
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
                transform.Translate(Vector3.up * Time.deltaTime * kuvvet, Space.World);
                if (kuvvet >= 0)
                {
                    kuvvetDegisim = Mathf.Abs(kuvvet) / 7;
                }
                else if (!hasFallen)
                {
                    if (transform.parent.transform.gameObject == transform.parent.transform.parent.transform.GetChild(0).transform.gameObject)
                    {
                        GameController.instance.isContinue = false;

                        GameObject obje = Instantiate(obj_indicator, Vector3.up * transform.position.y + Vector3.forward * 3 + Vector3.right * camera.position.x, Quaternion.identity);
                        indicator.CreateIndicator(obje);
                    }

                    GameController.instance.SetScore((int)(transform.position.y * (10 + PlayerPrefs.GetFloat("Income"))));

                    kuvvetDegisim = 0;
                    hasFallen = true;
                }

                rotateControl.RotateCharacter();
                kuvvet = kuvvet - (12 - kuvvetDegisim) * Time.deltaTime;
            }

            if (transform.position.y <= 2 && kuvvet < 0 && isJumping)
            {
                isJumping = false;
            }
        }
    }

    public void RagdollAktif(float sayi)
    {
        rigidbody.isKinematic = false;
        collider.enabled = true;
        capsuleCollider.enabled = false;
        kuvvet = 12 + sayi * (12 + PlayerPrefs.GetFloat("Strength") * (1 + PlayerPrefs.GetFloat("Hammer") * .1f) * 2/*Random.Range(1.98f, 2.02f)*/);

        if (kuvvet >= 77.25f)
        {
            kuvvet = 77.25f;
        }

        isJumping = true;
        StartCoroutine(AnimControl());
    }

    private IEnumerator AnimControl()
    {
        while (true)
        {
            animControl.ChangeAnim();
            yield return new WaitForSeconds(.1f);
        }
    }
}
