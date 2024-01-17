using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationAtRandomFrame : MonoBehaviour
{
    public Animator animator;
    public string stateName;

    void Start()
    {
        animator.Play(stateName, -1, Random.Range(0.0f, 1.0f));
    }
}
