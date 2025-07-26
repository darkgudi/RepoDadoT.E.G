using UnityEngine;
using UnityEngine.UI;

public class ControladorInstrucciones : MonoBehaviour
{
    public Image imagenInstrucciones;
    public Sprite[] paginas;
    private int paginaActual = 0;

    public void MostrarAnterior()
    {
        paginaActual--;
        if (paginaActual < 0) paginaActual = paginas.Length - 1;
        ActualizarImagen();
    }

    public void MostrarSiguiente()
    {
        paginaActual++;
        if (paginaActual >= paginas.Length) paginaActual = 0;
        ActualizarImagen();
    }

    private void Start()
    {
        ActualizarImagen();
    }

    private void ActualizarImagen()
    {
        if (paginas.Length > 0 && imagenInstrucciones != null)
        {
            imagenInstrucciones.sprite = paginas[paginaActual];
        }
    }
}
