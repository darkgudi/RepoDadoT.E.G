using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ControladorDados : MonoBehaviour
{
    [Header("Referencias UI")]
    public Transform panelAtacante;
    public Transform panelDefensor;

    public GameObject prefabDadoTexto;

    [Header("Botones Atacante")]
    public Button botonAtacante1;
    public Button botonAtacante2;
    public Button botonAtacante3;

    [Header("Botones Defensor")]
    public Button botonDefensor1;
    public Button botonDefensor2;
    public Button botonDefensor3;

    [Header("Ventana de Resultado")]
    [SerializeField] private VentanaResultado ventanaResultado;

    private int cantidadAtacante = 1;
    private int cantidadDefensor = 1;

    private List<GameObject> dadosAtacante = new List<GameObject>();
    private List<GameObject> dadosDefensor = new List<GameObject>();

    private Color colorActivo = new Color(0.6f, 0.6f, 0.6f); // gris claro
    private Color colorNormal = Color.white;

    void Start()
    {
        dadosAtacante = new List<GameObject>();
        dadosDefensor = new List<GameObject>();

        ActualizarSeleccionAtacante(1);
        ActualizarSeleccionDefensor(1);
    }

    public void SeleccionarDadosAtacante(int cantidad)
    {
        ActualizarSeleccionAtacante(cantidad);
    }

    public void SeleccionarDadosDefensor(int cantidad)
    {
        ActualizarSeleccionDefensor(cantidad);
    }

    public void LanzarDados()
    {
        CambiarValores(dadosAtacante);
        CambiarValores(dadosDefensor);

        List<int> valoresAtacante = ObtenerValores(dadosAtacante);
        List<int> valoresDefensor = ObtenerValores(dadosDefensor);

        ventanaResultado.MostrarVentana(valoresAtacante, valoresDefensor);
    }

    void ActualizarSeleccionAtacante(int nuevaCantidad)
    {
        cantidadAtacante = nuevaCantidad;
        ActualizarBotones(botonAtacante1, botonAtacante2, botonAtacante3, nuevaCantidad);
        ActualizarDados(panelAtacante, dadosAtacante, cantidadAtacante);
    }

    void ActualizarSeleccionDefensor(int nuevaCantidad)
    {
        cantidadDefensor = nuevaCantidad;
        ActualizarBotones(botonDefensor1, botonDefensor2, botonDefensor3, nuevaCantidad);
        ActualizarDados(panelDefensor, dadosDefensor, cantidadDefensor);
    }

    void ActualizarBotones(Button b1, Button b2, Button b3, int activo)
    {
        b1.image.color = (activo == 1) ? colorActivo : colorNormal;
        b2.image.color = (activo == 2) ? colorActivo : colorNormal;
        b3.image.color = (activo == 3) ? colorActivo : colorNormal;
    }

    void ActualizarDados(Transform panel, List<GameObject> lista, int cantidad)
    {
        if (panel == null || lista == null || prefabDadoTexto == null)
        {
            Debug.LogError("Referencia nula en ActualizarDados: Panel, Lista o Prefab no están asignados");
            return;
        }

        while (lista.Count < cantidad)
        {
            GameObject dado = Instantiate(prefabDadoTexto, panel);
            RectTransform rt = dado.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, 100 - (lista.Count * 120));
            int numero = Random.Range(1, 7);
            dado.GetComponentInChildren<TextMeshProUGUI>().text = numero.ToString();
            lista.Add(dado);
        }

        while (lista.Count > cantidad)
        {
            GameObject ultimo = lista[lista.Count - 1];
            lista.RemoveAt(lista.Count - 1);
            Destroy(ultimo);
        }
    }

    void CambiarValores(List<GameObject> dados)
    {
        foreach (GameObject dado in dados)
        {
            int nuevo = Random.Range(1, 7);
            dado.GetComponentInChildren<TextMeshProUGUI>().text = nuevo.ToString();
        }
    }

    List<int> ObtenerValores(List<GameObject> dados)
    {
        List<int> valores = new List<int>();
        foreach (GameObject dado in dados)
        {
            if (int.TryParse(dado.GetComponentInChildren<TextMeshProUGUI>().text, out int valor))
            {
                valores.Add(valor);
            }
        }
        return valores;
    }
}
