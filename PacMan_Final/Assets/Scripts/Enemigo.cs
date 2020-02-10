using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    //Velocidad
    public float velocidad = 20.0f;

    GameObject jugador;

    Vector2 posicion;

    void Start()
    {

        jugador = GameObject.FindGameObjectWithTag("Jugador");

        posicion = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 presa = posicion;

        float distancia = Vector2.Distance(jugador.transform.position, transform.position);
        presa = jugador.transform.position;

        float movimiento = velocidad * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, presa, movimiento);
    }
}