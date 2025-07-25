using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class VentanaResultado : MonoBehaviour
{
    [Header("Panel Principal")]
    public GameObject panelResultado;

    [Header("Comparaciones")]
    public List<TextMeshProUGUI> titulosComparaciones;
    public List<TextMeshProUGUI> valoresAtacante;
    public List<TextMeshProUGUI> valoresDefensor;

    [Header("Resumen Final")]
    public TextMeshProUGUI textoResultadoAtacante;
    public TextMeshProUGUI textoResultadoDefensor;

    [Header("Botón")]
    public Button botonContinuar;

    void Start()
    {
        panelResultado.SetActive(false);
        botonContinuar.onClick.AddListener(CerrarPanel);
    }

    public void MostrarVentana(List<int> dadosAtacante, List<int> dadosDefensor)
    {
        panelResultado.SetActive(true);

        // Orden descendente
        dadosAtacante.Sort((a, b) => b.CompareTo(a));
        dadosDefensor.Sort((a, b) => b.CompareTo(a));

        int comparaciones = Mathf.Min(dadosAtacante.Count, dadosDefensor.Count);
        int bajasAtacante = 0;
        int bajasDefensor = 0;

        for (int i = 0; i < 3; i++)
        {
            if (i < comparaciones)
            {
                int atacante = dadosAtacante[i];
                int defensor = dadosDefensor[i];

                valoresAtacante[i].text = atacante.ToString();
                valoresDefensor[i].text = defensor.ToString();

                if (atacante > defensor)
                {
                    titulosComparaciones[i].text = "GANADOR ATACANTE";
                    bajasDefensor++;
                }
                else
                {
                    titulosComparaciones[i].text = "GANADOR DEFENSOR";
                    bajasAtacante++;
                }

                titulosComparaciones[i].gameObject.SetActive(true);
                valoresAtacante[i].gameObject.SetActive(true);
                valoresDefensor[i].gameObject.SetActive(true);
            }
            else
            {
                titulosComparaciones[i].gameObject.SetActive(false);
                valoresAtacante[i].gameObject.SetActive(false);
                valoresDefensor[i].gameObject.SetActive(false);
            }
        }

        textoResultadoAtacante.text = bajasAtacante == 0 ? "NO SACA TROPAS" : $"RETIRA {bajasAtacante} TROPA{(bajasAtacante > 1 ? "S" : "")}";
        textoResultadoDefensor.text = bajasDefensor == 0 ? "NO SACA TROPAS" : $"RETIRA {bajasDefensor} TROPA{(bajasDefensor > 1 ? "S" : "")}";
    }

    public void CerrarPanel()
    {
        panelResultado.SetActive(false);
    }
}
