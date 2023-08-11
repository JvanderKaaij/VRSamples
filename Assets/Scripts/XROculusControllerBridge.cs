using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XROculusControllerBridge : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private List<SerializableTuple<InputActionReference, string>> buttons = new();
    
    [SerializeField]
    private InputActionReference joystick;
    
    private void Start()
    {
        foreach (var btn in buttons)
        {
            btn.Item1.action.Enable();
            btn.Item1.action.performed += c => animator.SetFloat(btn.Item2, 1);
            btn.Item1.action.canceled += c => animator.SetFloat(btn.Item2, 0);
        }

        joystick.action.performed += c =>
        {
            animator.SetFloat("Joy X", c.ReadValue<Vector2>().x);
            animator.SetFloat("Joy Y", c.ReadValue<Vector2>().y);
        };
        
        joystick.action.canceled += c =>
        {
            animator.SetFloat("Joy X", c.ReadValue<Vector2>().x);
            animator.SetFloat("Joy Y", c.ReadValue<Vector2>().y);
        };

    }

    public void SetAnimationState(int state)
    {
        
    }
}
