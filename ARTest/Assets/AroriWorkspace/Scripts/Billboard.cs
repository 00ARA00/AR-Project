using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform healthBarTransform;
    [NonSerialized] public Transform camera;

    private void LateUpdate()
    {
        healthBarTransform.LookAt(healthBarTransform.position + camera.forward);
    }

}
