using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    [Header("Karakterler")]
    [SerializeField] private GameObject[] characterView;
    int childCount;
    private GameObject obje;

    void Start()
    {
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (transform.gameObject == transform.parent.transform.GetChild(i).transform.gameObject)
            {
                childCount = i;
                break;
            }
        }
        PlayerPrefs.SetInt("level", 2);
        Debug.Log((int)(PlayerPrefs.GetInt("level")) / 5);

        if (PlayerPrefs.GetInt("level") >= childCount)
        {
            if (childCount >= PlayerPrefs.GetInt("level") % 5)
            {
                obje = Instantiate(characterView[(int)(PlayerPrefs.GetInt("level")) / 5 + 1], Vector3.zero, Quaternion.identity);
            }
            else
            {
                obje = Instantiate(characterView[(int)(PlayerPrefs.GetInt("level")) / 5], Vector3.zero, Quaternion.identity);
            }

            obje.transform.parent = transform;
            obje.transform.localPosition = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
