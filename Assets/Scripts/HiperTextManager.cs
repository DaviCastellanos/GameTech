using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiperTextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hiperWord;
    [SerializeField]
    private GameObject wordRow;
    [SerializeField]
    private int rowLength;
    [SerializeField]
    private WordPopup wordPopup;

    private string text = "Los labs de innovación se han convertido en una pieza clave para apalancar la transformación de las organizaciones. " +
                          "Les recomiendo este conversatorio en donde, de la mano de tres de los labs más importantes del país, se hablará el por qué, " +
                          "para qué y cómo de los laboratorios de innovación. <EP> " +
                          "Los labs de innovación se han convertido en una pieza clave para apalancar la transformación de las organizaciones. " +
                          "Les recomiendo este conversatorio en donde, de la mano de tres de los labs más importantes del país, se hablará el por qué, " +
                          "para qué y cómo de los laboratorios de innovación. <EP> " +
                          "Los labs de innovación se han convertido en una pieza clave para apalancar la transformación de las organizaciones. " +
                          "Les recomiendo este conversatorio en donde, de la mano de tres de los labs más importantes del país, se hablará el por qué, " +
                          "para qué y cómo de los laboratorios de innovación. <EP> " +
                          "Los labs de innovación se han convertido en una pieza clave para apalancar la transformación de las organizaciones. " +
                          "Les recomiendo este conversatorio en donde, de la mano de tres de los labs más importantes del país, se hablará el por qué, " +
                          "para qué y cómo de los laboratorios de innovación.";

    private string title = "Sobre Laboratorios de Innovación";
    private string[] textArray;
    private string[] titleArray;
    private int currentRowLength;
    private GameObject currentRow;

    void Start()
    {
        textArray = text.Split(' ');
        titleArray = title.Split(' ');
        BuildTitle();
        BuildText();
    }

    void DisplayWordPopup(string word)
    {
        wordPopup.DisplayPopup(word);
    }

    void BuildTitle()
    {
        currentRow = Instantiate(wordRow, transform);
        foreach (string word in titleArray)
        {
            currentRowLength += word.Length + 1;

            if (currentRowLength > rowLength)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)currentRow.transform);
                currentRow = Instantiate(wordRow, transform);
                currentRowLength = 0;
            }

            GameObject newWord = Instantiate(hiperWord, currentRow.transform);

            newWord.GetComponent<HiperWord>().Init(word, isTitle: true);
            newWord.GetComponent<HiperWord>().OnWordClicked = DisplayWordPopup;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)currentRow.transform);

        currentRowLength = rowLength;
    }

    void BuildText()
    {
        currentRow = Instantiate(wordRow, transform);
        foreach(string word in textArray)
        {
            if(word.Equals("<EP>"))
            {
                Instantiate(wordRow, transform);
                currentRowLength = rowLength;
                continue;
            }

            currentRowLength += word.Length + 1;

            if(currentRowLength > rowLength)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)currentRow.transform);
                currentRow = Instantiate(wordRow, transform);
                currentRowLength = 0;
            }

            GameObject newWord = Instantiate(hiperWord, currentRow.transform);

            newWord.GetComponent<HiperWord>().Init(word);
            newWord.GetComponent<HiperWord>().OnWordClicked = DisplayWordPopup;
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)currentRow.transform);

        //firstRow.GetComponent<HorizontalLayoutGroup>().enabled = true;
    }

}
