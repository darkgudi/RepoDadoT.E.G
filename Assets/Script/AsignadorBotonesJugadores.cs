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

                // Activar y configurar botón atacante
                botonesAtacante[i].SetActive(true);
                botonesAtacante[i].GetComponentInChildren<TMP_Text>().text = nombres[i];
                botonesAtacante[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    // Dentro del AddListener para atacante
                    {
                        Color colorPanel = colores[index];
                        if (colorPanel == Color.black)
                        {
                            colorPanel = new Color(0.8f, 0.8f, 0.8f); // Gris claro
                        }
                        panelAtacante.color = colorPanel;
                    }

                });

                // Activar y configurar botón defensor
                botonesDefensor[i].SetActive(true);
                botonesDefensor[i].GetComponentInChildren<TMP_Text>().text = nombres[i];
                botonesDefensor[i].GetComponent<Button>().onClick.AddListener(() =>
                {
                    {
                        Color colorPanel = colores[index];
                        if (colorPanel == Color.black)
                        {
                            colorPanel = new Color(0.8f, 0.8f, 0.8f);
                        }
                        panelDefensor.color = colorPanel;
                    }

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
