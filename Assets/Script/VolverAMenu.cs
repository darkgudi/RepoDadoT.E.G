using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAMenu : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene("PantallaMenu"); // AQUI PONER NOMBRE DE ESCENA PARA VOLVER
    }
}
