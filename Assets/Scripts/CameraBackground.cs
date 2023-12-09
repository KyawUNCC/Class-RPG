using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackground : MonoBehaviour
{
    [SerializeField] Color aboveColor;
    [SerializeField] Color belowColor;

    bool isAbove = true;

    Camera cameraComponent;

    private void Start()
    {
        cameraComponent = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            if (!isAbove)
            {
                isAbove = true;
                cameraComponent.backgroundColor = aboveColor;
            }
        }
        else
        {
            if (isAbove)
            {
                isAbove = false;
                cameraComponent.backgroundColor = belowColor;
            }
        }
    }
}
