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

    private List<GameObject> characters = new List<GameObject>();

    void Start()
    {
        if (isOurCharacter)
        {
            ActiveOurCharacter();
        }
        else
        {
            Upload();
        }
    }

    private void ActiveOurCharacter()
    {
        if ((int)(PlayerPrefs.GetFloat("Strength") / 3) < 19)
        {
            GameObject obje = Instantiate(characterView[(int)(PlayerPrefs.GetFloat("Strength") / 3)], transform.position, Quaternion.identity);

            obje.transform.parent = transform;
            obje.transform.localPosition = Vector3.zero;
        }
        else
        {
            GameObject obje = Instantiate(characterView[19], transform.position, Quaternion.identity);

            obje.transform.parent = transform;
            obje.transform.localPosition = Vector3.zero;
        }

    }

    public void Upload()
    {
        if ((int)((PlayerPrefs.GetFloat("Strength")) / 5) < 19)
        {
            //Silme islemleri
            childCount = 0;

            for (int i = 0; i < characters.Count; i++)
            {
                Destroy(characters[i]);
            }
            characters.Clear();
            //Sonraki islemler

            for (int i = 0; i < transform.parent.transform.childCount; i++)
            {
                if (transform.gameObject == transform.parent.transform.GetChild(i).transform.gameObject)
                {
                    childCount = i;
                    break;
                }
            }

            float levelNumber;
            if (PlayerPrefs.GetFloat("Strength") == 0)
            {
                levelNumber = PlayerPrefs.GetFloat("Strength") + 1;
            }
            else
            {
                levelNumber = PlayerPrefs.GetFloat("Strength") + 1;
            }
            //Debug.Log(levelNumber);
            //levelNumber = 5; //Bunu pasif yapman gerekli

            levelNumber *= .125f;

            if (levelNumber > childCount)
            {
                if (levelNumber % 5 > childCount)
                {
                    obje = Instantiate(characterView[(int)(levelNumber / 5)], Vector3.zero, Quaternion.Euler(Vector3.up * 180));
                }
                else
                {
                    obje = Instantiate(characterView[(int)(levelNumber / 5 - 1)], Vector3.zero, Quaternion.Euler(Vector3.up * 180));
                }

                characters.Add(obje);
                obje.transform.parent = transform;
                obje.transform.localPosition = Vector3.zero;
            }
        }
        else
        {

        }

    }
}
