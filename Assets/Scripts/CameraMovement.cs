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
    [SerializeField] private Transform target;

    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 50);
    }

}
