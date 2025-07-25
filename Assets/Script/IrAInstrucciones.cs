using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAInstrucciones : MonoBehaviour
{
    public void Ir()
    {
        SceneManager.LoadScene("Instrucciones"); // AQUI PONER NOMBRE DE ESCENA PARA VOLVER
    }
}
