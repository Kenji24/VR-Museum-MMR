using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


public class VRBoxKeyboardInput : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.zKey.isPressed)
                Debug.Log("Tombol Z ditekan (mungkin tombol A)");
            if (Keyboard.current.xKey.isPressed)
                Debug.Log("Tombol X ditekan (mungkin tombol B)");
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                Debug.Log("Tombol SPACE ditekan (mungkin C/D)");
        }

        if (Mouse.current != null)
        {
            Vector2 mouse = Mouse.current.delta.ReadValue();
            if (mouse != Vector2.zero)
                Debug.Log("Stick mungkin terdeteksi sebagai mouse movement: " + mouse);
        }

        foreach (KeyControl key in Keyboard.current.allKeys)
        {
            if (key.wasPressedThisFrame)
            {
                Debug.Log($"Tombol {key.name} ditekan");
            }
        }

        if (Gamepad.current != null)
        {
            if (Gamepad.current.leftStick.ReadValue() != Vector2.zero)
                Debug.Log("Left Stick: " + Gamepad.current.leftStick.ReadValue());

            if (Gamepad.current.buttonSouth.wasPressedThisFrame)
                Debug.Log("Button A ditekan (buttonSouth)");
        }
        
        // if (Input.GetKeyDown(KeyCode.J))
        // Debug.Log("Tombol J ditekan");

        // if (Input.GetAxis("Horizontal") != 0)
        //     Debug.Log("Ada gerakan horizontal: " + Input.GetAxis("Horizontal"));
        
    }
}
