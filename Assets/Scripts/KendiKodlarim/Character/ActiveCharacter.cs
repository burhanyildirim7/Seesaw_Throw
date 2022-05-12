using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacter : MonoBehaviour
{
    [Header("Karakterler")]
    [SerializeField] private GameObject[] characterView;
    int childCount;
    private GameObject obje;

    private bool isOurCharacter;

    void Start()
    {
        if (isOurCharacter)
        {
            ActiveOurCharacter();
        }
        else
        {
            ActiveLaunchingCharacter();
        }
    }

    private void ActiveOurCharacter()
    {
        GameObject obje = Instantiate(characterView[(int)(PlayerPrefs.GetFloat("Strength") / 3)], transform.position, Quaternion.identity);
       // Debug.Log((int)(PlayerPrefs.GetFloat("Strength") / 3));

        obje.transform.parent = transform;
        obje.transform.localPosition = Vector3.zero;
    }

    private void ActiveLaunchingCharacter()
    {
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (transform.gameObject == transform.parent.transform.GetChild(i).transform.gameObject)
            {
                childCount = i;
                break;
            }
        }

        int levelNumber;
        if (PlayerPrefs.GetInt("level") == 0)
        {
            levelNumber = PlayerPrefs.GetInt("level") + 1;
        }
        else
        {
            levelNumber = PlayerPrefs.GetInt("level");
        }
        levelNumber = 5; //Bunu pasif yapman gerekli



        if (levelNumber > childCount)
        {
            if (levelNumber % 5 > childCount)
            {
                obje = Instantiate(characterView[(int)levelNumber / 5], Vector3.zero, Quaternion.identity);
            }
            else
            {
                obje = Instantiate(characterView[(int)levelNumber / 5 - 1], Vector3.zero, Quaternion.identity);
            }

            obje.transform.parent = transform;
            obje.transform.localPosition = Vector3.zero;
        }
    }
}
