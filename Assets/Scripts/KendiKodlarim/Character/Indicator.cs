using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IndicatorSystem
{
    public class Indicator : MonoBehaviour
    {
        private Transform _transform;

        public Indicator(Transform transform)
        {
            _transform = transform;
        }


        public void CreateIndicator(GameObject olusacakObje)
        {
            GameObject obje = Instantiate(olusacakObje, Vector3.up * _transform.position.y + Vector3.forward * 3, Quaternion.identity);
            obje.transform.parent = GameObject.FindWithTag("Object").transform;

            Text text = obje.transform.GetChild(1).transform.GetComponent<Text>();
            text.text = ((int)_transform.position.y).ToString();
        }


    }
}
