using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animations : MonoBehaviour
{
    [Header("RotaBelirlemekIcin")]
    private float hedefEksenX;
    private bool baslangicYonuMu;
    private Vector3 startingPos;

    [System.Flags]
    public enum MoveTurnType
    {
        LeftBaloon,
        RightBaloon,
        rocket,
        zeplin,
        insan,
    }

    public MoveTurnType WhichTurn;
    void Start()
    {
        baslangicYonuMu = false;
        startingPos = transform.position;

        if (WhichTurn == MoveTurnType.LeftBaloon)
        {
            hedefEksenX = 7;
            gameObject.transform.DOMoveX(transform.position.x + hedefEksenX, 5).SetLoops(20, LoopType.Yoyo);
        }
        else if (WhichTurn == MoveTurnType.RightBaloon)
        {
            hedefEksenX = -7;
            gameObject.transform.DOMoveX(transform.position.x + hedefEksenX, 5).SetLoops(20, LoopType.Yoyo);
        }
        else if (WhichTurn == MoveTurnType.rocket)
        {
            hedefEksenX = +20;
            gameObject.transform.DOMoveY(transform.position.y + hedefEksenX, 15).SetLoops(20, LoopType.Restart);
        }
        else if (WhichTurn == MoveTurnType.insan)
        {
            hedefEksenX = -20;
            gameObject.transform.DOMoveY(transform.position.y + hedefEksenX, 15).SetLoops(20, LoopType.Restart);
        }
    }

    private void Update()
    {
        if (baslangicYonuMu)
        {
            if(Vector3.Distance(transform.position, startingPos + hedefEksenX * Vector3.right) <= .25f)
            {
                baslangicYonuMu = false;
            }
            transform.DORotate(Vector3.zero, 1);
        }

        if (!baslangicYonuMu)
        {
            if (Vector3.Distance(transform.position, startingPos) <= .25f)
            {
                baslangicYonuMu = true;
            }
            transform.DORotate(Vector3.up * 180, 1);
        }
    }

}

