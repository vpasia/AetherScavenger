using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class WorldTranslator : Singleton<WorldTranslator>
{
    [SerializeField]
    private Transform ship;

    public delegate void ShipLeaned(Vector3 direction);
    public event ShipLeaned OnShipLeaned;


    // Update is called once per frame
    void Update()
    {
        OnShipLeaned(ship.localRotation.eulerAngles);
    }
}
