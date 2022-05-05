using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    /* private GameObject Player;

     Vector3 aradakiFark;


     void Start()
     {
         Player = GameObject.FindGameObjectWithTag("Player");
         aradakiFark = transform.position - Player.transform.position;
     }


     void Update()
     {

         transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);

     }*/

    [Header("KameraPos")]
    [SerializeField] private Vector3 offset;
    public Transform target;
    public bool isMoving;

    Vector3 velocity;
    public float kameraHizi;

    void Start()
    {
        StartCoroutine(KarakterBul());
    }

    public void StartingEvents()
    {
        isMoving = false;
    }

    IEnumerator KarakterBul()
    {
        while (true)
        {
            if (GameController.instance.isContinue)
            {
                target = GameObject.FindWithTag("Head").transform;
            }

            yield return new WaitForSeconds(.5f);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null && isMoving)
        {
           //transform.position = Vector3.SmoothDamp(transform.position, target.position + Vector3.forward * -target.position.z + Vector3.right * -target.position.x + offset,ref velocity, kameraHizi - Vector3.Distance(transform.position, target.position) / 30);
            transform.position = Vector3.Lerp(transform.position, target.position + Vector3.forward * -target.position.z + Vector3.right * -target.position.x + offset, .01f);
        }
    }

}
