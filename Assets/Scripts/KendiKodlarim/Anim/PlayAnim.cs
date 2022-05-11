using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animation anim;


    void Start()
    {
        anim = GetComponent<Animation>();
        //  anim.enabled = false;
        anim.Play("Sil");
    }
}
