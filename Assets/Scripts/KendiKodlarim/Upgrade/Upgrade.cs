using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpgradeSystem
{
    public class Upgrade : MonoBehaviour
    {
        private UIController _UIController;

        [Header("Gelistirmeler")]
        private ActiveHammer activeHammer;          // hammer aktif etmek icin gereklidir
        private HammerCharacter hammerCharacter;    //Tokmak vuran karakter icin gereklidir
        private ActiveCharacter[] activeCharacter;

        public Upgrade(UIController uIController)
        {
            _UIController = uIController;
            //PlayerPrefs.SetInt("totalScore", 1000000);
        }

        public void Purchase(string name, float amount)
        {
            activeHammer = GameObject.FindObjectOfType<ActiveHammer>();
            activeCharacter = GameObject.FindObjectsOfType<ActiveCharacter>(); // ("ActiveCharacter").transform.GetComponent<ActiveCharacter>();
            hammerCharacter = GameObject.FindObjectOfType<HammerCharacter>();

            if ((PlayerPrefs.GetFloat(name) + 1) < 99)
            {
                if (PlayerPrefs.GetInt("totalScore") >= PlayerPrefs.GetFloat(name) * PlayerPrefs.GetFloat(name) * 25 + (50 * (PlayerPrefs.GetFloat(name) + 1)))
                {
                    PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - ((int)PlayerPrefs.GetFloat(name) * (int)PlayerPrefs.GetFloat(name) * 25 + (50 * ((int)PlayerPrefs.GetFloat(name) + 1))));

                    PlayerPrefs.SetFloat(name, PlayerPrefs.GetFloat(name) + 1);

                    activeHammer.Upload();
                    hammerCharacter.Upload();
                    for (int i = 0; i < activeCharacter.Length; i++)
                    {
                        activeCharacter[i].Upload();
                    }
                }
            }
            else
            {

            }

        }

        public float ShowPrice(string name)
        {
            return (PlayerPrefs.GetFloat(name) * PlayerPrefs.GetFloat(name) * 25 + (50 * (PlayerPrefs.GetFloat(name) + 1)));
        }
    }
}

