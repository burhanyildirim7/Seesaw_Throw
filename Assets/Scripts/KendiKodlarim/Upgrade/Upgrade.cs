using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpgradeSystem
{
    public class Upgrade
    {
        private UIController _UIController;

        public Upgrade(UIController uIController)
        {
            _UIController = uIController;
        }

        public void Purchase(string name, float amount)
        {
            if(!PlayerPrefs.HasKey(name))
            {
                PlayerPrefs.SetFloat(name, 1);
            }
            else
            {
                if (PlayerPrefs.GetInt("totalScore") >= PlayerPrefs.GetInt(name) * 500)
                {
                    Debug.Log(PlayerPrefs.GetInt(name));
                    PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + 1);
                    PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - PlayerPrefs.GetInt(name) * 500);
                }
            }


         //   Debug.Log("isim = " + name + " amount = " + amount.ToString());
        }

        public float ShowPrice(string name)
        {
            return (PlayerPrefs.GetFloat(name) * 500 + 500);
        }
    }
}

