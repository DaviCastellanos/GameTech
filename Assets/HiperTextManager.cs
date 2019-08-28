using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiperTextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hiperWord;
    [SerializeField]
    private Transform wordRow;

    private string text = "Los labs de innovación se han convertido en una pieza clave para apalancar la transformación de las organizaciones. " +
                          "Les recomiendo este conversatorio en donde, de la mano de tres de los labs más importantes del país, se hablará el por qué, " +
                          "para qué y cómo de los laboratorios de innovación.";
    
    private string[] textArray;

    void Awake()
    {
        textArray = text.Split(' ');
        //BuildText();
    }

    void BuildText()
    {
        foreach(string word in textArray)
        {
            GameObject newWord = Instantiate(hiperWord, wordRow);

            newWord.GetComponent<Text>().text = word;
        }
    }

}
