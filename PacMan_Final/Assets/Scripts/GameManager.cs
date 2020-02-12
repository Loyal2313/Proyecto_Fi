using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public GameObject enemigo, coleccionable, trampaH, trampaV;

    public Vector3 posicion;
    public int numeroEnemigos;
    public float esperaInicial;
    public float esperaEntreEnemigos;
    public float esperaEntreOlas, esperaEntreColeccionables;
	public float intervaloTrampas;
	public bool cambio = false;

    void Start()
    {	
        //LLamo a la rutina de crear enemigos
        StartCoroutine(crearEnemigos());
        //LLamo a la rutina de crear coleccionables
        StartCoroutine(crearColeccionables());
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
                Vector3 posicionEnemigo = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
                Quaternion rotacionEnemigo = Quaternion.identity;
                Instantiate(enemigo, posicionEnemigo, rotacionEnemigo);

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreEnemigos);
            }

            //Espero un tiempo entre oleadas de enemigos
            yield return new WaitForSeconds(esperaEntreOlas);
        }
    }

    IEnumerator crearColeccionables()
    {
        yield return new WaitForSeconds(esperaInicial);
        while (true)
        {
            //Instancio el coleccionable en una posición aleatoria del tablero
            Vector3 posicionColeccionable = new Vector3(Random.Range(-posicion.x, posicion.x), posicion.y, Random.Range(-posicion.z, posicion.z));
            Quaternion rotacionColeccionable = Quaternion.identity;
            Instantiate(coleccionable, posicionColeccionable, rotacionColeccionable);

            //Espero un tiempo entre la creación de cada coleccionable
            yield return new WaitForSeconds(esperaEntreColeccionables);
        }
    }

	IEnumerator crearTrampas()
	{	
		GameObject[] trampasH = GameObject.FindGameObjectsWithTag("TrampaH");
		GameObject[] trampasV = GameObject.FindGameObjectsWithTag("TrampaV");

		yield return new WaitForSeconds(esperaInicial);
        while (true)
        {
			if(cambio == false)
			{
				foreach (GameObject trampaV in trampasV)
				{
					trampaV.SetActive (true);
				}
				foreach (GameObject trampaH in trampasH)
				{
					trampaH.SetActive (false);
				}
			}
			if(cambio == true){
				foreach (GameObject TrampaV in trampasV)
				{
					trampaV.SetActive (false);
				}
				foreach (GameObject trampaH in trampasH)
				{
					trampaH.SetActive (true);
				}
			}
			//Espero un tiempo entre el intervalo de trampas.
            yield return new WaitForSeconds(intervaloTrampas);
			if(cambio == false)
			{
				cambio = true;
			}
			if(cambio == true)
			{
				cambio = false;
			}
        }
	}

	public void MainMenu()
    {
        Application.LoadLevel("menu");
    }
    
    public void Play()
    {
        Application.LoadLevel("JuegoFi");
    }

    public void Quit()
    {
        Application.Quit();
    }
}