using UnityEngine;

public class SalirAplicacion : MonoBehaviour
{
    public void Salir()
    {
        // Esto muestra un mensaje en el editor
        Debug.Log("Saliendo de la aplicaci�n...");

        // Cierra la aplicaci�n cuando est� compilada
        Application.Quit();
    }
}
