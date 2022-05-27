using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IndicatorSystem
{
    public class Indicator
    {
        private Transform _transform;
        private Transform _camera;

        public Indicator(Transform transform)
        {
            _transform = transform;
            _camera = GameObject.FindObjectOfType<CameraMovement>().transform;
        }


        public void CreateIndicator(GameObject olusanObje)
        {
            GameObject obje = olusanObje;//Instantiate(olusacakObje, Vector3.up * _transform.position.y + Vector3.forward * 3 + Vector3.right * _camera.position.x, Quaternion.identity);
            obje.transform.parent = GameObject.FindWithTag("Object").transform;

            Text text = obje.transform.GetChild(1).transform.GetChild(1).transform.GetComponent<Text>();
            text.text = ((int)_transform.position.y).ToString();

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            Debug.Log("Oyun Sonu Titreşim Çalıştı");
        }


    }
}
