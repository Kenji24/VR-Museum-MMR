using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    CharacterControl controls;
    Vector2 move;
    public float speed = 5f;

    void Awake()
    {
        if (controls == null)
        {
            controls = new CharacterControl();

            controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;   
        }
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        Vector3 m = new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
        transform.Translate(m, Space.World);
    }
}
