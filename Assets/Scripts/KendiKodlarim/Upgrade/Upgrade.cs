using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpgradeSystem
{
    public class Upgrade : MonoBehaviour
    {
        private UIController _UIController;

        [Header("Gelistirmeler")]
        private ActiveHammer activeHammer;
        private ActiveCharacter[] activeCharacter;

        public Upgrade(UIController uIController)
        {
            _UIController = uIController;
        }

        public void Purchase(string name, float amount)
        {
            activeHammer = GameObject.FindObjectOfType<ActiveHammer>();
            activeCharacter = GameObject.FindObjectsOfType<ActiveCharacter>(); // ("ActiveCharacter").transform.GetComponent<ActiveCharacter>();


            if (PlayerPrefs.GetInt("totalScore") >= (PlayerPrefs.GetFloat(name) + 1) * 10)
            {
                PlayerPrefs.SetFloat(name, PlayerPrefs.GetFloat(name) + 1);

                activeHammer.Upload();
                for (int i = 0; i < activeCharacter.Length; i++)
                {
                    activeCharacter[i].Upload();
                }

                PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - (int)PlayerPrefs.GetFloat(name) * 10);
            }
        }

        public float ShowPrice(string name)
        {
            return (PlayerPrefs.GetFloat(name) * 10 + 10);
        }
    }
}

