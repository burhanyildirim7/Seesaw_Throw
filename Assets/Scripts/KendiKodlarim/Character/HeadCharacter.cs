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
                //Debug.Log(rotaValue);
                GameObject parentObject = characterControl.transform.gameObject;

                parentObject.transform.DORotate((parentObject.transform.rotation.eulerAngles.x + Random.Range(-3, 3)) * Vector3.right, Random.Range(5f, 10f)).SetLoops(500000, LoopType.Yoyo);
                transform.DOMoveX(transform.position.x + Random.Range(-1f, 1f) * rotaValue, Random.Range(1f, 3f)).SetLoops(500000, LoopType.Yoyo);
                transform.DOMoveZ(transform.position.z + Random.Range(-1f, 1f) * rotaValue, Random.Range(1f, 3f)).SetLoops(500000, LoopType.Yoyo);
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
