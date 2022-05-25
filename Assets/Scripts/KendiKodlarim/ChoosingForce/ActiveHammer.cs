using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveHammer : MonoBehaviour
{
    [SerializeField] private GameObject[] hammers;

    private GameObject activeHammer;


    void Start()
    {
        if ((int)(PlayerPrefs.GetFloat("Hammer") / 5) <= 7)
        {
            activeHammer = Instantiate(hammers[(int)(PlayerPrefs.GetFloat("Hammer") / 5)], transform.position, Quaternion.Euler(Vector3.up * -90));
            activeHammer.transform.parent = transform;
            activeHammer.transform.localRotation = Quaternion.Euler(new Vector3(0, 60f, 150f));
        }
        else
        {
            activeHammer = Instantiate(hammers[7], transform.position, Quaternion.Euler(Vector3.up * -90));
            activeHammer.transform.parent = transform;
            activeHammer.transform.localRotation = Quaternion.Euler(new Vector3(0, 60f, 150f));
        }

    }

    public void Upload()
    {
        if (PlayerPrefs.GetFloat("Hammer") % 5 == 0)
        {
            if ((int)(PlayerPrefs.GetFloat("Hammer") / 5) < 7)
            {
                Destroy(activeHammer);
                activeHammer = Instantiate(hammers[(int)(PlayerPrefs.GetFloat("Hammer") / 5)], transform.position, Quaternion.Euler(Vector3.up * -90));
                activeHammer.transform.parent = transform;
                activeHammer.transform.localRotation = Quaternion.Euler(new Vector3(0, 60f, 150f));
            }
        }
    }
}
