using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHammer : MonoBehaviour
{
    [SerializeField] private GameObject[] hammers;

    private GameObject activeHammer;


    void Start()
    {
        //Time.timeScale = 2;
        activeHammer = Instantiate(hammers[(int)(PlayerPrefs.GetFloat("Hammer") / 5)], transform.position, Quaternion.Euler(Vector3.up * -90));
        activeHammer.transform.parent = transform;
        activeHammer.transform.localRotation = Quaternion.Euler(new Vector3(-7.5f, 4f, -130f));
       // activeHammer.transform.localPosition = Vector3.right * .02f + Vector3.up * -.6f + Vector3.forward * 4.453f;
    }

    public void Upload()
    {
        //Debug.Log(PlayerPrefs.GetFloat("Hammer"));
        if(PlayerPrefs.GetFloat("Hammer") % 5 == 0)
        {
            Destroy(activeHammer);
            activeHammer = Instantiate(hammers[(int)(PlayerPrefs.GetFloat("Hammer") / 5)], transform.position, Quaternion.Euler(Vector3.up * -90));
            activeHammer.transform.parent = transform;
            activeHammer.transform.localRotation = Quaternion.Euler(new Vector3(-7.5f, 4f, -130f));
            //  activeHammer.transform.localPosition = Vector3.right * .02f + Vector3.up * -.6f + Vector3.forward * 4.453f;
        }
    }
}
