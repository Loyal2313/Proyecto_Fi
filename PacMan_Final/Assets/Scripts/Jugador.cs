using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
	//Velocidad
	public float velocidad = 30.0f;

	private Rigidbody rb;

	public bool huir = false;

    public float tiempo = 0;
    public float tiempoHuida = 6;

    public int vidas = 3;
    public float puntos = 0;

    private GameObject extra;

    //Cajas de texto
    public Text temporizador, puntuacion, extra1, extra2, extra3, extra4, extra5;
    //variables para mostrar el tiempo
    private string minutos, segundos, infoPuntos;

    void Start () {
        //Capturo el componente rigidbody del jugador
        rb = GetComponent<Rigidbody>();	
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Paro el tiempo
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            //Paro el tiempo
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reinicio al menu
            SceneManager.LoadScene("menu");
        }

        //Decremento el tiempo de huida
        tiempoHuida -= Time.deltaTime;

        //Incremento el tiempo
        tiempo += Time.deltaTime;

        //Escribo el tiempo
        if (vidas > 0)
        {
            minutosSegundos(tiempo);
            sumaPuntos(puntos);
            if (puntos > 0)
            {
                puntos -= Time.deltaTime;
            }
        }
        else
        {
            minutosSegundos(0);
            puntos = puntos + ((GetComponent<Enemigo>().asesinados) * 100);
            sumaPuntos(puntos);
        }
        GameObject[] extras = GameObject.FindGameObjectsWithTag("Extra");
        //Recorro ese array y los destruyo
        if (tiempo > 5)
        {
            foreach (GameObject extra in extras)
            {
                Destroy(extra);
            }
        }
    }

    void minutosSegundos(float tiempo)
    {
        //Minutos
        if (tiempo > 60)
        {
            minutos = "01";
        }
        else if (tiempo > 120)
        {
            minutos = "02";
        }
        else if (tiempo > 180)
        {
            minutos = "03";
        }
        else if (tiempo > 240)
        {
            minutos = "04";
        }
        else if (tiempo > 240)
        {
            minutos = "05";
        }
        else
        {
            minutos = "00";
        }

        //Segundos
        int numSegundos = Mathf.RoundToInt(tiempo % 60);
        if (numSegundos > 9)
        {
            segundos = numSegundos.ToString();
        }
        else
        {
            segundos = "0" + numSegundos.ToString();
        }
        //Escribo en la caja de texto
        temporizador.text = minutos + ":" + segundos;
    }
    // Es llamado una vez cada fixed frame

    void sumaPuntos(float puntos)
    {   
        int puntosTotales = Mathf.RoundToInt(puntos);
        infoPuntos = puntosTotales.ToString();
        puntuacion.text = "Puntuacion: " + infoPuntos;
    }
    void FixedUpdate()
	{
		//Capto el valor del eje vertical y horizontal
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		//Modifico la velocidad de la raqueta
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);

		//Si los enemigos están huyendo y se nos ha acabado el tiempo, decremento el tiempo
        if (huir && tiempoHuida > 0)
        {
            tiempoHuida -= Time.deltaTime;
            //Lo muestro en consola
            Debug.Log(tiempoHuida);
        }
        else
        {
            huir = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Si atraviesa con el coleccionable
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            //Borro el coleccionable
            other.gameObject.SetActive(false);

            puntos = puntos + 50;
            //Capturo un array con todos los objetos que tengan la etiqueta enemigo
            //GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");

            /*// Recorro ese array y los destruyo
            foreach (GameObject enemigo in enemigos)
            {
                Destroy(enemigo);
            }*/
        }
		if (other.gameObject.CompareTag("Armamento"))
        {	
			other.gameObject.SetActive(false);
			tiempoHuida = 6;
			huir=true;
            puntos = puntos + 200;
        }
		if (other.gameObject.CompareTag("Vida"))
        {	
			other.gameObject.SetActive(false);
			vidas++;
            puntos = puntos + 300;
        }
    }
}