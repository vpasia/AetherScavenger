using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTranslator : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0f, -50f) * Time.fixedDeltaTime;
    }
}
