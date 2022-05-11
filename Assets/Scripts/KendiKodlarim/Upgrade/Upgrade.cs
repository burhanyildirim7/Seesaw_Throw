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
            if (PlayerPrefs.GetInt("totalScore") >= (PlayerPrefs.GetFloat(name) + 1) * 500)
            {
                PlayerPrefs.SetFloat(name, PlayerPrefs.GetFloat(name) + 1);

                PlayerPrefs.SetInt("totalScore", PlayerPrefs.GetInt("totalScore") - (int)PlayerPrefs.GetFloat(name) * 500);
            }
        }

        public float ShowPrice(string name)
        {
            return (PlayerPrefs.GetFloat(name) * 500 + 500);
        }
    }
}

