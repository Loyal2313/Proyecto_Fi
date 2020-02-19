using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{

	//Velocidad
	public float velocidad = 30.0f;
	private Rigidbody rb;
	public bool huir = false;
    private float tiempo;
	private int vidas = 3;
    private int puntos = 480;

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
    }

    // Es llamado una vez cada fixed frame
    void FixedUpdate()
	{
		//Capto el valor del eje vertical y horizontal
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		//Modifico la velocidad de la raqueta
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);

		//Si los enemigos están huyendo y nos e ha acabado el tiempo, decremento el tiempo
        if (huir && tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            //Lo muestro en consola
            Debug.Log(tiempo);
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

			vidas--;
            //Capturo un array con todos los objetos que tengan la etiqueta enemigo
            //GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");

            /*//Recorro ese array y los destruyo
            foreach (GameObject enemigo in enemigos)
            {
                Destroy(enemigo);
            }*/
        }
		if (other.gameObject.CompareTag("Armamento"))
        {	
			other.gameObject.SetActive(false);
			tiempo = 10;
			huir=true;
		}
		if (other.gameObject.CompareTag("Vida"))
        {	
			other.gameObject.SetActive(false);
			vidas++;
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