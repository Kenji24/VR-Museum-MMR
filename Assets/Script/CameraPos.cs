using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] Transform trPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = trPos.position;
    }
}
