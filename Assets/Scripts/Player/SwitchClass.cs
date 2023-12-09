using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchClass : MonoBehaviour
{
    [SerializeField] private Transform cinemachine;
    int currentClass;

    private void Start()
    {
        currentClass = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("8"))
        {
            switchClass();
        }
    }

    public void switchClass()
    {
        GameObject previousChild = transform.GetChild(currentClass).gameObject;

        currentClass++;
        if (currentClass > 2)
            currentClass = 0;
        
        GameObject currentChild = transform.GetChild(currentClass).gameObject;

        currentChild.SetActive(true);
        currentChild.GetComponent<Rigidbody2D>().velocity = previousChild.GetComponent<Rigidbody2D>().velocity;
        previousChild.SetActive(false);
        currentChild.transform.position = previousChild.transform.position;
        currentChild.transform.rotation = previousChild.transform.rotation;
        cinemachine.GetComponent<CinemachineVirtualCamera>().Follow = transform.GetChild(currentClass);
    }
}
