using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private GameObject meshHolder;

    public Action<int> Died;
    private bool isCorrect;

    public void Init(bool isCorrect)
    {
        this.isCorrect = isCorrect;
        Invoke("Transcend", 10);
    }

    public void Kill()
    {
        animator.SetTrigger("Kill");

        int score = isCorrect ? -1 : 1;

        if (Died != null)
            Died(score);

        Invoke("Destroy", 1);
    }

    private void Transcend()
    {
        int score = isCorrect ? 1 : -1;

        if (Died != null)
            Died(score);

        particles.Play();
        Invoke("TurnOffMesh", 1);
        Invoke("Destroy", 4);
    }

    private void TurnOffMesh()
    {
        meshHolder.SetActive(false);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
