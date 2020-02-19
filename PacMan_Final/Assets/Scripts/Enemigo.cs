using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    //Velocidad
    public float velocidad = 20.0f;

    GameObject jugador;

	GameObject enemigo;

    Vector2 posicion;

    public int asesinados = 0;
    void Start()
    {	

        jugador = GameObject.FindGameObjectWithTag("Jugador");

		enemigo = GameObject.FindGameObjectWithTag("Enemigo");

        posicion = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 presa = posicion;

        float distancia = Vector2.Distance(jugador.transform.position, transform.position);
        presa = jugador.transform.position;

        float movimiento = velocidad * Time.deltaTime;     

		//Muevo el enemigo hacia el jugador (si no lo han matado aún)
        if (jugador != null)
        {
            if (jugador.GetComponent<Jugador>().huir)
            {
                //Huye del jugador
                transform.position = Vector2.MoveTowards(transform.position, -presa, movimiento);
                //Color temporal
                GetComponent<Renderer>().material.color = Color.blue;
            }
			else
			{
				transform.position = Vector2.MoveTowards(transform.position, presa, movimiento);
                GetComponent<Renderer>().material.color = Color.green;
            }
		}
    }

	public void OnCollisionEnter2D(Collision2D other)
    {
        //Si se choca con el jugador
        if (other.gameObject.CompareTag("Jugador"))
        {
			if (jugador.GetComponent<Jugador>().huir)
			{
				Destroy(gameObject);
                asesinados++;
            }
			else
			{
				//Destruyo al jugador
				Destroy(other.gameObject);
				//Paro el tiempo del juego para que no se creen más enemigos
				Time.timeScale = 0;
			}
        }
    }
}