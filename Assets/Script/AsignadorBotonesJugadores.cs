using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AsignadorBotonesJugadores : MonoBehaviour
{
    public GameObject[] botonesAtacante;
    public GameObject[] botonesDefensor;
    public Image panelAtacante;
    public Image panelDefensor;

    private void Start()
    {
        List<string> nombres = JugadoresConfigurados.Nombres;
        List<Color> colores = JugadoresConfigurados.Colores;

        Debug.Log("Jugadores cargados: " + nombres.Count);
        for (int i = 0; i < nombres.Count; i++)
        {
            Debug.Log($"Jugador {i}: {nombres[i]} - Color: {colores[i]}");
        }

        for (int i = 0; i < botonesAtacante.Length; i++)
        {
            if (i < nombres.Count)
            {
                int index = i;

                // Color original elegido
                Color colorJugador = colores[index];

                // Color visual del botón (gris claro si es negro)
                Color colorBoton = (colorJugador == Color.black) ? new Color(0.7f, 0.7f, 0.7f) : colorJugador;

                // Color real para el panel (gris claro si negro)
                Color colorPanel = (colorJugador == Color.black) ? new Color(0.7f, 0.7f, 0.7f) : colorJugador;

                // ACTIVAR Y CONFIGURAR botón atacante
                botonesAtacante[i].SetActive(true);
                botonesAtacante[i].GetComponentInChildren<TMP_Text>().text = nombres[i];
                botonesAtacante[i].GetComponent<Image>().color = colorBoton;
                botonesAtacante[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    panelAtacante.color = colorPanel;
                });

                // ACTIVAR Y CONFIGURAR botón defensor
                botonesDefensor[i].SetActive(true);
                botonesDefensor[i].GetComponentInChildren<TMP_Text>().text = nombres[i];
                botonesDefensor[i].GetComponent<Image>().color = colorBoton;
                botonesDefensor[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    panelDefensor.color = colorPanel;
                });
            }
            else
            {
                botonesAtacante[i].SetActive(false);
                botonesDefensor[i].SetActive(false);
            }
        }
    }
}
