using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeadCharacter : MonoBehaviour
{
    private Rigidbody fizik;

    private Vector3 hedef;

    [SerializeField] private float rotaValue;

    CharacterControl characterControl;
    Vector3 hedefRotate;

    GameObject parentObject;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();

        StartCoroutine(ControlRagdoll());

        characterControl = transform.GetComponentInParent<CharacterControl>();
        parentObject = characterControl.transform.gameObject;
        hedefRotate = Vector3.one * Random.Range(-2f, 2f);
    }

    IEnumerator ControlRagdoll()
    {
        while (true)
        {
            if (!fizik.useGravity)
            {
                rotaValue = characterControl.kuvvet / 500;
                //Debug.Log(rotaValue);

               // parentObject.transform.DORotate((parentObject.transform.rotation.eulerAngles.x + Random.Range(-3, 3)) * Vector3.right, Random.Range(5f, 10f)).SetLoops(500000, LoopType.Yoyo);
                transform.DOMoveX(transform.position.x + Random.Range(-1f, 1f) * rotaValue, Random.Range(1.5f, 4f)).SetLoops(500000, LoopType.Yoyo);
                transform.DOMoveZ(transform.position.z + Random.Range(-1f, 1f) * rotaValue, Random.Range(1.5f, 4f)).SetLoops(500000, LoopType.Yoyo);
                //transform.DORotate(transform.rotation.eulerAngles + Vector3.one * 20, Random.Range(1.5f, 4f)).SetLoops(500000, LoopType.Yoyo);
                // transform.DOMoveY(transform.position.y + Random.Range(-.01f, .01f) * rotaValue, Random.Range(20f, 50f)).SetLoops(500000, LoopType.Yoyo);
                break;
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    void Update()
    {
       /* if(transform.gameObject.CompareTag("Head") && !fizik.useGravity)
        {
            parentObject.transform.Rotate(hedefRotate * Time.deltaTime);
        }*/
    }
}
