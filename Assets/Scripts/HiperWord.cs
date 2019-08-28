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

    public void Init(string text)
    {
        sizeText.text = text;
        visibleText.text = text;
    }
}
