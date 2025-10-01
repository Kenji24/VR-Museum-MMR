using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.Controls;


public class ControllerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var device in InputSystem.devices)
        {
            // Contoh cek berdasarkan product string
            if (device.description.product == "9999")
            {
                // var xAxis = device.TryGetChildControl<AxisControl>("stick/x");
                // var yAxis = device.TryGetChildControl<AxisControl>("stick/y");

                // float x = xAxis.ReadValue();
                // float y = yAxis.ReadValue();
                
                // Debug.Log($"Stick Position => X: {x}, Y: {y}");
                
                foreach (var control in device.allControls)
                {
                    if (control is ButtonControl button)
                    {
                        if (button.isPressed)
                            Debug.Log($"[JOYSTICK INPUT] Tombol {control.name} ditekan");
                    }
                }

                // if (device is Joystick joystick)
                // {
                //     Debug.Log($"Joystick: {joystick.displayName}");

                //     float x = joystick.stick.x.ReadValue();
                //     float y = joystick.stick.y.ReadValue();

                //     Debug.Log($"Stick Position => X: {x}, Y: {y}");
                // }

                // foreach (var control in device.allControls)
                // {
                //     if (control.name == "x" || control.name == "y")
                //     {
                //         if (control is AxisControl axis)
                //         {
                //             float value = axis.ReadValue();
                //             Debug.Log($"Axis {control.name} = {value}");
                //         }
                //     }
                // }
            }
        }
    }

    // void checkJoystick()
    // {
    //     if (Input.GetKey(KeyCode.JoystickButton10))
    //     {
    //         print("joy 0");
    //     }
    //     else if (Input.GetKey(KeyCode.JoystickButton11))
    //     {
    //         print("joy 11");
    //     }
    //     else if (Input.GetKey(KeyCode.JoystickButton12))
    //     {
    //         print("joy 12");
    //     }
    //     else if (Input.GetKey(KeyCode.JoystickButton13))
    //     {
    //         print("joy 13");
    //     }
    //     else if (Input.GetKey(KeyCode.JoystickButton14))
    //     {
    //         print("joy 14");
    //      }
    // }
}
