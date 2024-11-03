using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ShipControls : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float rotationSpeed = 50f;

    private float currentXRot = 0f;
    private float currentZRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float gyroZRot = Input.gyro.rotationRateUnbiased.z * Time.deltaTime * rotationSpeed;
        currentZRot = Mathf.Clamp(currentZRot + gyroZRot, -30f, 30f);

        float gyroXRot = Input.gyro.rotationRateUnbiased.x * Time.deltaTime * rotationSpeed;
        currentXRot = Mathf.Clamp(currentXRot + gyroXRot, -20f, 20f);

        rb.transform.localRotation = Quaternion.Euler(-currentXRot, 0f, currentZRot);
    }
}
