using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnBoyOranKoruma : MonoBehaviour
{
    [SerializeField] Canvas ekrancanvasi;
    //YUKSEKLIGI _ GENISLIGE GORE DEGISTIRMEK ICIN YAZILDI
    [SerializeField] GameObject ImageObjesi;
    // Start is called before the first frame update
    void Start()
    {
        ImageObjesi.transform.localPosition = new Vector2(0f, ((float)(ekrancanvasi.GetComponent<RectTransform>().sizeDelta.y)/(float)(-7.56)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
