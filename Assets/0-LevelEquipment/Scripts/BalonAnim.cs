using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalonAnim : MonoBehaviour
{
    [System.Flags]
    public enum MoveTurnType
    {
        LeftBaloon,
        RightBaloon,
        rocket,
        zeplin,
        insan,
    }
    // Start is called before the first frame update
    public MoveTurnType WhichTurn;
    void Start()
    {
        if (WhichTurn == MoveTurnType.LeftBaloon)
        {

            gameObject.transform.DOMoveX(transform.position.x + 7, 5).SetLoops(20, LoopType.Yoyo);
        }
        
        else if(WhichTurn == MoveTurnType.RightBaloon)
        {
            gameObject.transform.DOMoveX(transform.position.x - 7, 5).SetLoops(20, LoopType.Yoyo);
        }

        else if (WhichTurn == MoveTurnType.rocket)
        {
            gameObject.transform.DOMoveY(transform.position.y+20, 15).SetLoops(20, LoopType.Restart);
        }

        else if (WhichTurn == MoveTurnType.insan)
        {
            gameObject.transform.DOMoveY(transform.position.y - 20, 15).SetLoops(20, LoopType.Restart);
        }
    }

}

