using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    [Header("Controller")]
    private UIController uIController;

    [Header("GostericiOzellikleri")]
    [SerializeField] private float speedIndicator;

    void Start()
    {
        uIController = GameObject.FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.isContinue)
        {
            uIController.ShowForceIndicator(Mathf.Sin(Time.time * speedIndicator) * 50);
        }
    }

    public void SendForceMessage()
    {
        GameObject.FindObjectOfType<HammerCharacter>().ForceMessage(Mathf.Abs(Mathf.Cos(Time.time * speedIndicator)));
    }
}
