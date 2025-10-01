using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour
{

    [SerializeField] Transform cam;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, cam.rotation.eulerAngles.y, transform.rotation.z);
    }
}
