using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoPerdido : MonoBehaviour
{
    public static TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TMP_Text>();
        //texto.text = MovimientoPersonaje.mensaje;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
