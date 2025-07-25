using UnityEngine;

public class SalirAplicacion : MonoBehaviour
{
    public void Salir()
    {
        // Esto muestra un mensaje en el editor
        Debug.Log("Saliendo de la aplicación...");

        // Cierra la aplicación cuando está compilada
        Application.Quit();
    }
}
