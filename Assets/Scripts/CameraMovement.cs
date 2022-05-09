using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("KameraPos")]
    [SerializeField] private Vector3 offset;
    public Transform target;
    public bool isMoving;

    Vector3 velocity;
    public float tergetSpeedCam;
    private float speedCam;


    [Header("HedefBelirlemeIcinKullanilanlar")]
    private List<CharacterControl> characterControllers = new List<CharacterControl>();
    private CharacterControl characterControl;

    void Start()
    {
        StartCoroutine(KarakterBul());
    }

    public void StartingEvents()
    {
        speedCam = 0;
        characterControllers.Clear();
        isMoving = false;

        GameObject[] obje = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < obje.Length; i++)
        {
            characterControllers.Add(obje[i].transform.GetComponent<CharacterControl>());
        }
    }

    IEnumerator KarakterBul()
    {
        while (true)
        {
            if (GameController.instance.isContinue && target == null)
            {
                float enYakinKuvvet = -50;
                CharacterControl control;

                for (int i = 0; i < characterControllers.Count; i++)
                {
                    if(characterControllers[i].kuvvet >= enYakinKuvvet)
                    {
                        target = characterControllers[i].transform;
                        characterControl = characterControllers[i];
                    }
                }
            }
            else if(!GameController.instance.isContinue)
            {
                target = null;
            }

            yield return new WaitForSeconds(.5f);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null && isMoving)
        {
            if(characterControl.kuvvet >= 0)
            {
                //transform.position = Vector3.SmoothDamp(transform.position, target.position + Vector3.forward * -target.position.z + Vector3.right * -target.position.x + offset,ref velocity, kameraHizi - Vector3.Distance(transform.position, target.position) / 30);
                speedCam = Mathf.Lerp(speedCam, tergetSpeedCam, 1 * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, target.position + Vector3.forward * -target.position.z + Vector3.right * -target.position.x + offset, speedCam);
            }
            else
            {
                Debug.Log("oyun bitti");
                UIController.instance.ActivateWinScreen();
                isMoving = false;
            }
        }
    }

}
