using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiperWord : MonoBehaviour
{
    [SerializeField]
    private Text sizeText;
    [SerializeField]
    private Text visibleText;
    [SerializeField]
    private Button button;

    public Action<string> OnWordClicked;

    public void Init(string text, bool isTitle = false)
    {
        sizeText.text = text;
        visibleText.text = text;

        button.onClick.AddListener(WordClicked);

        if (isTitle)
        {
            sizeText.fontSize += 3;
            sizeText.fontStyle = FontStyle.Bold;

            visibleText.fontSize += 3;
            visibleText.fontStyle = FontStyle.Bold;
        }
    }

    private void WordClicked()
    {
        if (OnWordClicked != null)
            OnWordClicked(visibleText.text);
    }
}
