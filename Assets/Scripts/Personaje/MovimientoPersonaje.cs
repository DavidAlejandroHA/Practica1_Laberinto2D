using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MovimientoPersonaje : MonoBehaviour
{
    public float movX, movY;
    Rigidbody2D rb;
    public float fuerzaSalto;
    bool parado = false;
    float segundos = 2;
    //public TMP_Text textoDerrota;
    // Start is called before the first frame update
    void Start()
    {
        //fuerzaSalto = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!parado)
        {
            movX = Input.GetAxis("Horizontal");
            movY = Input.GetAxis("Vertical");
        }
        else
        {
            movX = 0f;
            movY = 0f;
            segundos -= Time.deltaTime;

            if (segundos <= 0)
            {
                parado = false;
                segundos = 2;
            }
            // https://www.youtube.com/watch?v=dgMImeoZG5w
        }
    }

    void FixedUpdate()
    {
        // Velocidad lateral y vertical del personaje
        Vector2 vector = new Vector2(movX * 7, movY * 7);
        rb.velocity = vector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //estaEnElSuelo = true;
        //

        //SceneManager.LoadScene(1);
        //TMP_Text texto = GameObject.Find("TextoDerrota").GetComponent<TMP_Text>();
        //TextoPerdido.texto.text = "Test";

        if (collision.gameObject.tag == "Pared")
        {
            parado = true;
            Debug.Log("A");
        }
    }
}
