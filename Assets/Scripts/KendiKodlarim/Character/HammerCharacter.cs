using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimHammerSystem;

public class HammerCharacter : MonoBehaviour
{

    [Header("Karakterler")]
    [SerializeField] private GameObject[] characters;
    GameObject obje;

    [Header("Controllers")]
    private CameraMovement cameraMovement;

    [Header("NameSpaceKullanimlari")]
    AnimHammer animHammer;

    [Header("Efektler")]
    [SerializeField] private ParticleSystem hammerEfect;
    [SerializeField] private Transform effecTransform;

    private float kuvvetSayisi;

    void Start()
    {
        cameraMovement = GameObject.FindObjectOfType<CameraMovement>();

        obje = Instantiate(characters[(int)(PlayerPrefs.GetFloat("Strength") / 5)], transform.position, Quaternion.Euler(-Vector3.up * 90));
        obje.transform.parent = transform;
        // animHammer = new AnimHammer(transform);
    }

    public void Upload() //Sadece sekil degistirmek icin kullanilir
    {
        if (PlayerPrefs.GetFloat("Strength") % 5 == 0)
        {
            Destroy(obje);
            obje = Instantiate(characters[(int)(PlayerPrefs.GetFloat("Strength") / 5)], transform.position, Quaternion.Euler(-Vector3.up * 90));
            obje.transform.parent = transform;
            //animHammer = new AnimHammer(transform);
        }
    }


    public void ForceMessage(float sayi)
    {
        kuvvetSayisi = sayi;
        animHammer = new AnimHammer(transform);

        if (kuvvetSayisi <= .8f)
        {
            animHammer.Anim1Uygula();
            StartCoroutine(DelayForce(.9f));
        }
        else if (kuvvetSayisi > .8f)
        {
            animHammer.Anim2Uygula();
            StartCoroutine(DelayForce(1.5f));
        }
    }

    IEnumerator DelayForce(float sayi)
    {
        yield return new WaitForSeconds(sayi);
        SendMessage();
    }

    public void SendMessage()
    {
        //    Instantiate(hammerEfect, effecTransform.position, Quaternion.identity);



        Animator anim = GameObject.FindWithTag("Tahterevalli").GetComponent<Animator>();

        //Debug.Log(anim.name);

        anim.SetBool("Zipla", true);

        Invoke("AnimDurdur", 0.5f);

        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++)
        {
            player[i].GetComponent<CharacterControl>().RagdollAktif(kuvvetSayisi);
        }

        StartCoroutine(DelaySending());

        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

        Debug.Log("Oyun Basi Titreşim Çalıştı");
    }

    private void AnimDurdur()
    {
        Animator anim = GameObject.FindWithTag("Tahterevalli").GetComponent<Animator>();
        anim.SetBool("Zipla", false);
    }

    IEnumerator DelaySending()
    {
        yield return new WaitForSeconds(.18f);
        cameraMovement.isMoving = true;
    }
}
