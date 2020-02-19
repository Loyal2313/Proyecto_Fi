using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MostrarUsu : MonoBehaviour
{
    [SerializeField] private Text ErrorUsu, ErrorCont;
    [SerializeField] private string inputFieldUsuario;
    [SerializeField] private string inputFieldContraseña;
    private Usuario usuario;
    private string url = "http://18.184.61.233/Unity/public/unity.php";
    public float velocidad = 100;


    void ComprobarUsuarioYContraseña()
    {
        //Recupero el usuario del input
        if (inputFieldUsuario == "")
        {
            ErrorUsu.text = "Debes introducir un usuario.";
        }

        if (inputFieldContraseña == "")
        {
            ErrorCont.text = "Debes escribir una contraseña";
        }
        else if (inputFieldUsuario != "" && inputFieldContraseña != "")
        {
            ErrorUsu.text = "";
            ErrorCont.text = "";
            usuario = new Usuario(inputFieldUsuario, inputFieldContraseña);
            StartCoroutine(ApiMostrar(url, usuario));
        }

    }

    IEnumerator ApiMostrar(string url, Usuario usuario)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario.usuario);
        form.AddField("contraseña", usuario.contraseña);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                ErrorUsu.text = webRequest.error;

            }
            else if (webRequest.downloadHandler.text == "no")
            {
                ErrorUsu.text = "Usuario no autorizado";
            }
            else
            {
                

            }
        }


    }
}

