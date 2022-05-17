using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCharacter : MonoBehaviour
{

    [Header("Karakterler")]
    [SerializeField] private GameObject[] characters;
    GameObject obje;

    void Start()
    {
        obje = Instantiate(characters[(int)(PlayerPrefs.GetFloat("Strength") / 5)], transform.position, Quaternion.Euler(-Vector3.up * 90));
        obje.transform.parent = transform;
    }

    public void Upload()
    {
        if (PlayerPrefs.GetFloat("Strength") % 5 == 0)
        {
            Destroy(obje);
            obje = Instantiate(characters[(int)(PlayerPrefs.GetFloat("Strength") / 5)], transform.position, Quaternion.Euler(-Vector3.up * 90));
            obje.transform.parent = transform;
        }
    }
}
