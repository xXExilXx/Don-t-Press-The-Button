using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnEscape : MonoBehaviour
{
    private bool wasPressed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!wasPressed)
            {
                wasPressed = true;
                gameObject.SetActive(!gameObject.activeSelf);
            }
            else
            {
                wasPressed = false;
            }
        }
    }
}
