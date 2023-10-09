using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoTiempo : MonoBehaviour
{
    public static TMP_Text texto;
    public static float timer = 60;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TMP_Text>();
        //texto = GetComponentInChildren<TextMeshPro>();
        //Debug.Log(texto);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
