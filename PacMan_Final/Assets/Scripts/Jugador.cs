using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{

	//Velocidad
	public float velocidad = 30.0f;


	// Es llamado una vez cada fixed frame
	void FixedUpdate()
	{

		//Capto el valor del eje vertical y horizontal de la raqueta
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		//Modifico la velocidad de la raqueta
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);

	}

    void OnTriggerEnter(Collider other)
    {

        //Si atraviesa con el coleccionable
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            //Borro el coleccionable
            other.gameObject.SetActive(false);

            //Capturo un array con todos los objetos que tengan la etiqueta enemigo
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");

            /*//Recorro ese array y los destruyo
            foreach (GameObject enemigo in enemigos)
            {
                Destroy(enemigo);
            }*/
        }

    }
}

/*public class ScriptDeltaTime : MonoBehaviour
{
    public GUIText guitext;

    int number = 0;

    float secondsCounter = 0;
    float secondsToCount = 1;

    void Update()
    {
        secondsCounter += Time.deltaTime;
        if (secondsCounter >= secondsToCount)
        {
            secondsCounter = 0;
            number++;
        }
        guitext.text = number.ToString();
    }*/