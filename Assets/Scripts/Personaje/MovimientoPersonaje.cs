using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using TMPro;

public class MovimientoPersonaje : MonoBehaviour
{
    public float movX, movY;
    Rigidbody2D rb;
    public float fuerzaSalto;
    bool parado = false;
    public float segundos = 2;
    public static string mensaje = "";
    public GameObject panelPerder;
    public GameObject panelGanar;
    public float puntos = 0;
    public float estrellasConseguidas = 0;
    string textoPuntuacionAlPerderOriginal;
    string textoPuntuacionAlGanarOriginal;
    string textoEstrellasConseguidas;
    string textoTiempoRestante;
    string textoVidas;
    bool pausado = false;

    
    //string textoMensajeAlGanar;
    public int vidas = 3;
    //public TMP_Text textoDerrota;
    // Start is called before the first frame update
    void Start()
    {
        //fuerzaSalto = 5f;
        rb = GetComponent<Rigidbody2D>();
        panelPerder = GameObject.Find("PanelPerder");
        panelGanar = GameObject.Find("PanelGanar");
        Debug.Log(panelPerder);
        panelPerder.SetActive(false);
        panelGanar.SetActive(false);
        textoPuntuacionAlPerderOriginal = TextoPuntuacionPerder.texto.text;
        textoPuntuacionAlGanarOriginal = TextoPuntuacionGanar.texto.text;
        textoEstrellasConseguidas = TextoEstrellas.texto.text;
        TextoEstrellas.texto.text = textoEstrellasConseguidas + estrellasConseguidas;
        textoTiempoRestante = TextoTiempo.texto.text;
        TextoTiempo.texto.text = TextoTiempo.texto.text + TextoTiempo.timer + "s";
        textoVidas = VidasTexto.texto.text;
        VidasTexto.texto.text = textoVidas + vidas;
        //Debug.Log(TextoTiempo.texto.text); 
        //textoTiempoRestante = TextoTiempo.texto.text;
        //textoMensajeAlGanar = TextoMensaje.texto.text;
    }

    // Update is called once per frame
    void Update()
    {
        actualizarTiempo();
        moverPersonaje();
        perderSiSeAcabaElTiempo();
    }

    void FixedUpdate()
    {
        // Velocidad lateral y vertical del personaje
        Vector2 vector = new Vector2(movX * 7, movY * 7);
        rb.velocity = vector;
    }

    void perderSiSeAcabaElTiempo()
    {
        if (!pausado)
        {
            if (TextoTiempo.timer <= 0)
            {
                pausado = true;
                panelPerder.SetActive(true);
                TextoPuntuacionPerder.texto.text = TextoPuntuacionPerder.texto.text + puntos;
                PauseGame();
            }
        }
    }

    void aumentarEstrellasConseguidas()
    {
        estrellasConseguidas++;
        TextoEstrellas.texto.text = textoEstrellasConseguidas + estrellasConseguidas;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TMP_Text texto = GameObject.Find("TextoDerrota").GetComponent<TMP_Text>();

        if (collision.gameObject.tag == "Pared")
        {
            vidas--;
            VidasTexto.texto.text = textoVidas + vidas;
            if (vidas > 0)
            {
                // Reducir actualizar el texto de las vidas
            }
            else
            {
                // Pantalla de perder
                panelPerder.SetActive(true);
                TextoPuntuacionPerder.texto.text = TextoPuntuacionPerder.texto.text + puntos;
                PauseGame();
            }
            
            //SceneManager.LoadScene(1);
            parado = true;
            
            //Debug.Log("A");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EstrellaColeccionable")
        {
            puntos++;
            aumentarEstrellasConseguidas();
            Destroy(collision.gameObject);
            TextoPuntuacionGanar.texto.text = textoPuntuacionAlGanarOriginal + puntos;
        } else if (collision.gameObject.tag == "EstrellaFinal")
        {
            puntos += 10;
            TextoPuntuacionGanar.texto.text = textoPuntuacionAlGanarOriginal + puntos;
            TextoMensaje.texto.text = "Has conseguido " + estrellasConseguidas + " de las " + EstrellaColeccionable.numEstrellasColeccionables + 
                " estrellas del mapa ";

            string mensajeExtra = "";
            if (estrellasConseguidas == 0)
            {
                mensajeExtra = "):";
            } else if (estrellasConseguidas > 0 && estrellasConseguidas < EstrellaColeccionable.numEstrellasColeccionables)
            {
                mensajeExtra = ":)";
            } else if(estrellasConseguidas == EstrellaColeccionable.numEstrellasColeccionables)
            {
                mensajeExtra = ":D";
            }
            TextoMensaje.texto.text += mensajeExtra;

            panelGanar.SetActive(true);
            pausado = true;
            PauseGame();
        }
    }

    void moverPersonaje()
    {
        if (!parado)
        {
            movX = Input.GetAxis("Horizontal");
            movY = Input.GetAxis("Vertical");
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            movX = 0f;
            movY = 0f;
            segundos -= Time.deltaTime;

            if (segundos <= 0)
            {
                parado = false;
                GetComponent<SpriteRenderer>().color = Color.white;
                segundos = 2;
            }
            // https://www.youtube.com/watch?v=dgMImeoZG5w
        }
    }

    void actualizarTiempo()
    {
        if (!pausado)
        {
            TextoTiempo.timer -= Time.deltaTime;
            if (TextoTiempo.timer > 0)
            {
                TextoTiempo.texto.text = textoTiempoRestante + TextoTiempo.timer.ToString("f1") + "s";
            }
            else
            {
                TextoTiempo.texto.text = textoTiempoRestante + "0";
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
