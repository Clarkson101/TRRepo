using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayAnimation : MonoBehaviour
{
    private Animator animator;
    public string stateName;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        animator.Play(stateName);
    }
}
