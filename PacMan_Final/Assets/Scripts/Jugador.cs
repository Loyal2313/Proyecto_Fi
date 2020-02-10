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
}