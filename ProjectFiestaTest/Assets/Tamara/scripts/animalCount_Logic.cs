using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class animalCount_Logic : MonoBehaviour
{
    [SerializeField] int animalesCount, misContados;
    [SerializeField] float intervalo, timer;
    [SerializeField] bool isSpawning;
    [SerializeField] GameObject []spawnPos;
    [SerializeField] GameObject []goalPos;
    [SerializeField] GameObject animalPref, panel;
    [SerializeField] TMP_Text textotiempo, contador;

    private void Start()
    {
        textotiempo.text = timer.ToString();
        contador.text = misContados.ToString();
        StartCoroutine(Initialize());
    }

    public void contar()
    {
        misContados++;
        contador.text = misContados.ToString();
    }

    IEnumerator Initialize() 
    {
        //agregar ui contando y sonidos.
        yield return new WaitForSeconds(1);
        isSpawning = true;
        Debug.Log("iniciando");
       
        while (isSpawning)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                Debug.Log("instanciando vuelta " + i);
                var animal = Instantiate(animalPref, spawnPos[i].transform);
                animal.GetComponent<animal>().Initialize();
                animalesCount++;
                Debug.Log("objetos instanciados " + animalesCount);
                intervalo = Random.Range(.3f, .9f);
                Debug.Log("Voy a esperarme " + intervalo + " segundos");
                yield return new WaitForSeconds(intervalo);
               
            }
        }
        Debug.Log("ya terminé de instanciar");

    }

    IEnumerator Resultados() 
    {
        yield return new WaitForSeconds(3);
        if (animalesCount == misContados)
        {
            Debug.Log("cambiar a verde");
            panel.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("cambiar a rojo");
            panel.GetComponent<Image>().color = Color.red;
        }
    }

    private void Update()
    {
        if (isSpawning)
        {
            
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            isSpawning = false;
            StartCoroutine(Resultados());
        }
        textotiempo.text = timer.ToString(format:"00");
    }

}
