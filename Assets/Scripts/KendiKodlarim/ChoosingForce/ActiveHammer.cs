using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHammer : MonoBehaviour
{
    [SerializeField] private GameObject[] hammers;

    private GameObject activeHammer;


    void Start()
    {
        activeHammer = Instantiate(hammers[(int)(PlayerPrefs.GetInt("Hammer") / 5)], transform.position, Quaternion.identity);
        activeHammer.transform.parent = transform;
    }

    public void Upload()
    {
        //Debug.Log(PlayerPrefs.GetFloat("Hammer"));
        if(PlayerPrefs.GetFloat("Hammer") % 5 == 0)
        {
            Destroy(activeHammer);
            activeHammer = Instantiate(hammers[(int)(PlayerPrefs.GetFloat("Hammer") / 5)], transform.position, Quaternion.identity);
            activeHammer.transform.parent = transform;
        }
    }
}
