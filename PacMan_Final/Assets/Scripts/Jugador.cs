using System;
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

    public float tiempo;
    public float tiempoHuida;

    public int vidas = 3;
    public float puntos = 0;

    public int coleccionables = 21;

    private GameObject extra;

    public GameObject vida1, vida2, vida3, vida4, vida5, vida6;

    //Cajas de texto
    public Text temporizador, puntuacion;
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

        GameObject[] extras = GameObject.FindGameObjectsWithTag("Extra");
        //Recorro ese array y los destruyo
        if (tiempo > 5)
        {
            foreach (GameObject extra in extras)
            {
                Destroy(extra);
            }
        }
        //Vidas
        //Escribo el tiempo
        if (vidas > 0)
        {
            minutosSegundos(tiempo);
            sumaPuntos(puntos);
            if (puntos > 0)
            {
                puntos -= Time.deltaTime;
            }
            if(coleccionables < 1){
                SceneManager.LoadScene("Creditos");
            }
        }
        if (vidas == 1)
        {
            vida1.SetActive (true);
            vida2.SetActive(false);
        }
        if (vidas == 2)
        {
            vida2.SetActive(true);
            vida3.SetActive(false);
        }
        if (vidas == 3)
        {
            vida1.SetActive(true);
            vida2.SetActive(true);
            vida3.SetActive(true);
            vida4.SetActive(false);
            vida5.SetActive(false);
            vida6.SetActive(false);
        }
        if (vidas == 4)
        {
            vida4.SetActive(true);
            vida5.SetActive(false);
        }
        if (vidas == 5)
        {
            vida5.SetActive(true);
            vida6.SetActive(false);
        }
        if (vidas == 6)
        {
            vida6.SetActive(true);
        }
        if(vidas<1)
        {
            minutosSegundos(0);
            sumaPuntos(puntos);
            SceneManager.LoadScene("Creditos");
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
            coleccionables--;
        }
		if (other.gameObject.CompareTag("Armamento"))
        {	
			other.gameObject.SetActive(false);
			tiempoHuida = 6;
			huir=true;
            puntos = puntos + 200;
            coleccionables--;
        }
		if (other.gameObject.CompareTag("Vida"))
        {	
			other.gameObject.SetActive(false);
			vidas++;
            puntos = puntos + 300;
            coleccionables--;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //Si se choca con el jugador
        if (other.gameObject.CompareTag("Enemigo"))
        {
            if (huir)
            {
                puntos = puntos + 100;
            }
            else
            {
                this.transform.position = Vector2.zero;
                vidas--;
            }
        }

        if (other.gameObject.CompareTag("TrampaH") || other.gameObject.CompareTag("TrampaV"))
        {
            if (!huir)
            {
                this.transform.position = Vector2.zero;
                vidas--;
            }
        }
    }
}