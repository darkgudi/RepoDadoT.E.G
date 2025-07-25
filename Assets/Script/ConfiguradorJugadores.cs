using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ConfiguradorJugadores : MonoBehaviour
{
    private List<string> nombresJugadores = new List<string>();
    private List<string> coloresJugadores = new List<string>();
    [System.Serializable]
    public class JugadorUI
    {
        public TMP_InputField inputNombre;
        public TMP_Dropdown dropdownColor;
    }

    public List<JugadorUI> jugadoresUI;
    public Button botonComenzar;

    private List<string> coloresDisponibles = new List<string> { "Negro", "Rojo", "Verde", "Azul", "Amarillo", "Rosa" };
    private Dictionary<string, Color> mapaColores = new Dictionary<string, Color>
    {
        {"Negro", Color.black},
        {"Rojo", Color.red},
        {"Verde", Color.green},
        {"Azul", Color.blue},
        {"Amarillo", Color.yellow},
        {"Rosa", new Color(1f, 0.5f, 0.8f) }
    };

    void Start()
    {
        botonComenzar.interactable = false;
        for (int i = 0; i < jugadoresUI.Count; i++)
        {
            int index = i;
            jugadoresUI[i].inputNombre.onValueChanged.AddListener((_) => VerificarEstado(index));
            jugadoresUI[i].dropdownColor.onValueChanged.AddListener((_) => VerificarEstado(index));

            jugadoresUI[i].dropdownColor.ClearOptions();
            jugadoresUI[i].dropdownColor.AddOptions(new List<string>(coloresDisponibles));

            if (i > 0)
            {
                jugadoresUI[i].inputNombre.interactable = false;
                jugadoresUI[i].dropdownColor.interactable = false;
            }
        }
    }
    public void ComenzarJuego()
    {
        int jugadoresValidos = nombresJugadores.Count;

        if (jugadoresValidos >= 2)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.LogWarning("Debes ingresar al menos 2 jugadores.");
        }
    }

    void VerificarEstado(int index)
    {
        var nombre = jugadoresUI[index].inputNombre.text;
        var color = jugadoresUI[index].dropdownColor.options[jugadoresUI[index].dropdownColor.value].text;

        if (!string.IsNullOrEmpty(nombre) && color != "")
        {
            if (index + 1 < jugadoresUI.Count)
            {
                jugadoresUI[index + 1].inputNombre.interactable = true;
                jugadoresUI[index + 1].dropdownColor.interactable = true;
                jugadoresUI[index + 1].dropdownColor.ClearOptions();
                var coloresRestantes = new List<string>(coloresDisponibles);
                for (int j = 0; j <= index; j++)
                {
                    string usado = jugadoresUI[j].dropdownColor.options[jugadoresUI[j].dropdownColor.value].text;
                    coloresRestantes.Remove(usado);
                }
                jugadoresUI[index + 1].dropdownColor.AddOptions(coloresRestantes);
            }
        }

        // Verificar si hay mínimo 2 jugadores válidos
        int validos = 0;
        for (int i = 0; i < jugadoresUI.Count; i++)
        {
            var nom = jugadoresUI[i].inputNombre.text;
            if (!string.IsNullOrEmpty(nom)) validos++;
        }
        botonComenzar.interactable = (validos >= 2);
    }

    public void AlPresionarComenzar()
    {
        List<string> nombres = new List<string>();
        List<Color> colores = new List<Color>();

        for (int i = 0; i < jugadoresUI.Count; i++)
        {
            string nombre = jugadoresUI[i].inputNombre.text;
            if (!string.IsNullOrEmpty(nombre))
            {
                string colorTexto = jugadoresUI[i].dropdownColor.options[jugadoresUI[i].dropdownColor.value].text;
                nombres.Add(nombre);
                colores.Add(mapaColores[colorTexto]);
            }
        }

        JugadoresConfigurados.Nombres = nombres;
        JugadoresConfigurados.Colores = colores;

        SceneManager.LoadScene("SampleScene");
    }
}
