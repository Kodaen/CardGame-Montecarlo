using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorGroup : MonoBehaviour
{
    private Animator[] _animators;

    private void Awake()
    {
        _animators = GetComponentsInChildren<Animator>();
    }

    public void SetTrigger(string name)
    {
        foreach (var animator in _animators)
        {
            animator.SetTrigger(name);
        }
    }

    public void SetBool(string name, bool value)
    {
        foreach (var animator in _animators)
        {
            animator.SetBool(name, value);
        }
    }

    public void SetInt(string name, int value)
    {
        foreach (var animator in _animators)
        {
            animator.SetInteger(name, value);
        }
    }

    public void SetFloat(string name, float value)
    {
        foreach (var animator in _animators)
        {
            animator.SetFloat(name, value);
        }
    }
}
