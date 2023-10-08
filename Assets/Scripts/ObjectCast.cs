using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectCast : MonoBehaviour
{
    [Header("Interactable Object")]
    [Tooltip("Event invoked when the object is interacted with.")]
    public UnityEvent interactEvent;

    public void Interact()
    {
        interactEvent.Invoke();
    }
}
