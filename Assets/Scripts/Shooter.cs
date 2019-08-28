using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private Text x;

    [SerializeField]
    private Button fire;

    private void Awake()
    {
        fire.onClick.AddListener(Fire);
    }

    void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            Orc orc = hit.transform.GetComponent<Orc>();

            if(orc != null)
            {
                orc.Kill();
            }
        } 
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            x.color = Color.red;
        }
        else
        {
            x.color = Color.white;
        }
    }
}
