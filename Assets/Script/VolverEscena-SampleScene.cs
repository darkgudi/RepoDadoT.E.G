using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAEscena : MonoBehaviour
{
    [SerializeField]
    private string nombreEscena = "SampleScene"; // AQUI PONER NOMBRE DE ESCENA PARA VOLVER

    public void Volver()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
