using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeadCharacter : MonoBehaviour
{
    private Rigidbody fizik;

    private Vector3 hedef;

    [SerializeField] private float rotaValue;


    void Start()
    {
        fizik = GetComponent<Rigidbody>();

        StartCoroutine(ControlRagdoll());
    }

    IEnumerator ControlRagdoll()
    {
        while (true)
        {
            if (!fizik.useGravity)
            {
                CharacterControl characterControl = transform.GetComponentInParent<CharacterControl>();
                rotaValue = characterControl.kuvvet / 500;
                Debug.Log(rotaValue);

                transform.DOMoveX(transform.position.x + Random.Range(-1f, 1f) * rotaValue, Random.Range(.75f, 2f)).SetLoops(500000, LoopType.Yoyo);
                transform.DOMoveZ(transform.position.z + Random.Range(-1f, 1f) * rotaValue, Random.Range(.75f, 2f)).SetLoops(500000, LoopType.Yoyo);
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
