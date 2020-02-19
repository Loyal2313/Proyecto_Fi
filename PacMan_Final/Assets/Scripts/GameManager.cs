using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemigo, trampaH, trampaV;
    public Vector2 posicion;
    public int numeroEnemigos;
    public float esperaInicial;
    public float esperaEntreEnemigos;
	public float intervaloTrampas;

    //AudioSource fuenteDeAudio;
    //public AudioClip AudioEnemigo, AudioTrampas;
    void Start()
    {	
        //LLamo a la rutina de crear enemigos
        StartCoroutine(crearEnemigos());
		//LLamo a la rutina de Intervalo de trampas
        StartCoroutine(crearTrampas());
    }
    IEnumerator crearEnemigos()
    {
        //Espero un tiempo antes de crear enemigos
        yield return new WaitForSeconds(esperaInicial);

        //Bucle durante toda la vida del juego
        while (true)
        {
            //Bucle de número de enemigos
            for (int i = 0; i < numeroEnemigos; i++)
            {
                //Instancio el enemigo en una posición aleatoria del tablero
                Vector2 posicionEnemigo = new Vector2(Random.Range(-posicion.x, posicion.x), Random.Range(-posicion.y, posicion.y));
                Quaternion rotacionEnemigo = Quaternion.identity;
                Instantiate(enemigo, posicionEnemigo, rotacionEnemigo);

                //fuenteDeAudio.clip = AudioEnemigo;
                //fuenteDeAudio.Play();

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreEnemigos);
            }
        }
    }
	IEnumerator crearTrampas()
	{	
		GameObject[] trampasH = GameObject.FindGameObjectsWithTag("TrampaH");
		GameObject[] trampasV = GameObject.FindGameObjectsWithTag("TrampaV");

		yield return new WaitForSeconds(esperaInicial);
        while (true)
        {	
			foreach (GameObject trampaV in trampasV)
			{
				trampaV.SetActive (true);
			}
			foreach (GameObject trampaH in trampasH)
			{
				trampaH.SetActive (false);
			}
            //fuenteDeAudio.clip = AudioTrampas;
            //fuenteDeAudio.PlayDelayed(5);
            //Espero un tiempo entre el intervalo de trampas.			
            yield return new WaitForSeconds(intervaloTrampas);
				foreach (GameObject TrampaV in trampasV)
				{
					trampaV.SetActive (false);
				}
				foreach (GameObject trampaH in trampasH)
				{
					trampaH.SetActive (true);
				}
			//Espero un tiempo entre el intervalo de trampas.
            yield return new WaitForSeconds(intervaloTrampas);
        }
	}
    //COnfiguraciones de los botones

    public void Play()
    {
        SceneManager.LoadScene("JuegoFi");
    }

    public void Registro()
    {
        Application.OpenURL("");//Enlace de la web HUGO
    }

    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }

	public void credi()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Quit()
    {
        Application.Quit();
    }
}