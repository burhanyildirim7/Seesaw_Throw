using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [Header("AnimasyonAyarlari")]
    private Animation anim;

    [Header("Efektler")]
    [SerializeField] private ParticleSystem hammerEfect;
    [SerializeField] private Transform effecTransform;

    [Header("Controllers")]
    private CameraMovement cameraMovement;

    private float kuvvetSayisi;

    void Start()
    {
        anim = GetComponent<Animation>();
        cameraMovement = GameObject.FindObjectOfType<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ForceMessage(float sayi)
    {
        anim.Play("HammerAnim");
        kuvvetSayisi = sayi;
    }

    public void SendMessage()
    {
        Instantiate(hammerEfect, effecTransform.position, Quaternion.identity);


        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++)
        {
            player[i].GetComponent<Ragdoll>().LaunchingCharacter(kuvvetSayisi);
        }

        StartCoroutine(DelaySending());
    }

    IEnumerator DelaySending()
    {
        yield return new WaitForSeconds(.25f);
        cameraMovement.isMoving = true;
    }
}
