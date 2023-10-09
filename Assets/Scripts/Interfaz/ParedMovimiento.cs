using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedMovimiento : MonoBehaviour
{
    bool haciaDerecha = false;
    float random;
    float velocidad = 2f;
    public static bool pausado = false;
    public static float timer = 2f;
    float auxTimer = timer;
    // Start is called before the first frame update
    void Start()
    {
        // 50% de probabilidades de que la plataforma se empieze moviendo de derecha a izquierda y viceversa
        random = Random.value;
        if (random >= 0.5)
        {
            haciaDerecha = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!pausado)
        {
            mover();
            transform.Translate((haciaDerecha ? Vector2.right : Vector2.left) * Time.deltaTime * velocidad);
        }
    }

    void mover()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = auxTimer;
            haciaDerecha = !haciaDerecha;
        }
    }

}
