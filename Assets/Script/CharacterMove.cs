using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.Controls;

public class CharacterMove : MonoBehaviour
{

    [SerializeField] float MovSpeed = 5f;
    [SerializeField] Transform trOrientation;
    Vector2 inputVector;
    Vector3 moveDirection;
    Rigidbody rb;
    CharacterControl controls;
    Vector2 joystickDirection = Vector2.zero;

    Dictionary<string, bool> joystickHeldState = new Dictionary<string, bool>
    {
        {"up", false},
        {"down", false},
        {"left", false},
        {"right", false}
    };

    Dictionary<string, float> joystickLastPressed = new Dictionary<string, float>
    {
        {"up", 0f},
        {"down", 0f},
        {"left", 0f},
        {"right", 0f}
    };

    float pressBufferTime = 0.4f;

    void Awake()
    {
        controls = new CharacterControl();

        controls.Gameplay.Move.performed += ctx => inputVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => inputVector = Vector2.zero;   
    }
    
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        playerMove();
        SpeedControl();
    }

    void playerMove()
    {
        Vector2 currentInput = inputVector;

        if (currentInput == Vector2.zero)
        {
            currentInput = joystickDirection;
        }

        moveDirection = new Vector3(currentInput.x, 0, currentInput.y) * MovSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);
    }

    void UpdateJoystickDirection()
    {
        Debug.Log("[CHECK] UpdateJoystickDirection jalan");
        foreach (var device in InputSystem.devices)
        {

            // Debug.Log($"[DEVICE] Found: {device.displayName}, Product: {device.description.product}");
            if (device.description.product.ToLower().Contains("vr box"))
            {
                Debug.Log("[JOYSTICK] Ditemukan joystick 9999");
                Debug.Log("VR BOX");

                foreach (var control in device.allControls)
                {
                    if (control is ButtonControl button)
                    {
                        string name = control.name.ToLower();
                        Debug.Log($"[VR BOX INPUT] {name}");

                        if (joystickHeldState.ContainsKey(name))
                        {
                            if (button.wasPressedThisFrame || button.ReadValue() > 0.5f)
                            {
                                joystickHeldState[name] = true;
                                joystickLastPressed[name] = Time.time;
                            }
                        }
                    }
                }
                break;
            }
        }

        List<string> keys = new List<string>(joystickHeldState.Keys);
        foreach (string key in keys)
        {
            if (Time.time - joystickLastPressed[key] > pressBufferTime)
            {
                joystickHeldState[key] = false;
            }
        }
        
        float x = 0;
        float y = 0;

        if (joystickHeldState["up"]) y += 1;
        if (joystickHeldState["down"]) y -= 1;
        if (joystickHeldState["left"]) x -= 1;
        if (joystickHeldState["right"]) x += 1;

        joystickDirection = new Vector2(x, y).normalized;
    }

    void Update()
    {
        UpdateJoystickDirection();
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > MovSpeed)
        {
            Vector3 limitVel = flatVel.normalized * MovSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

}
