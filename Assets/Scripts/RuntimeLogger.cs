using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeLogger : MonoBehaviour
{
    [SerializeField]
    private GameObject logMessage;

    [SerializeField]
    private GameObject content;

    private void Awake()
    {
        Application.logMessageReceived += CreateMessage;
    }

    private void CreateMessage(string logString, string stackTrace, LogType type)
    {
        GameObject newLog = Instantiate(logMessage, content.transform);
        Text textComponent = newLog.GetComponent<Text>();
        textComponent.text = type + " -- " + logString + " -- " + stackTrace;
        textComponent.fontStyle = FontStyle.Normal;
        textComponent.fontSize = 25;
    }
}
