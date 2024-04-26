using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component

    void Awake()
    {
        animator = GetComponent<Animator>(); // Get Animator on Awake for potential scene load animation
    }

    void Start()
    {
        // Play fade-in animation if scene is loaded for the first time
        if (SceneManager.sceneCountInBuildSettings == SceneManager.sceneCount)
        {
            PlayAnimation();
        }
    }

    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.Play("FadeIn");
        }
    }
}
