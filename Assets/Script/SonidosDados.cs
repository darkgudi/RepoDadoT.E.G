using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoDados : MonoBehaviour
{
    public AudioClip[] sonidosDados; // asignar 3 sonidos en el inspector
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Método público que puede ser llamado desde ControladorDados
    public void ReproducirSecuenciaDados(int cantidadAtacante, int cantidadDefensor)
    {
        StartCoroutine(ReproducirSecuencia(cantidadAtacante, cantidadDefensor));
    }

    IEnumerator ReproducirSecuencia(int atacante, int defensor)
    {
        int i = 0;
        int j = 0;

        while (i < atacante || j < defensor)
        {
            if (i < atacante)
            {
                ReproducirSonidoRandom();
                i++;
                yield return new WaitForSeconds(0.5f);
            }

            if (j < defensor)
            {
                ReproducirSonidoRandom();
                j++;
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    void ReproducirSonidoRandom()
    {
        if (sonidosDados.Length == 0 || audioSource == null) return;
        int index = Random.Range(0, sonidosDados.Length);
        audioSource.PlayOneShot(sonidosDados[index]);
    }
}
