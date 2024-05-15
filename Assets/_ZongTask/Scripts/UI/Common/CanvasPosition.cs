using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPosition : MonoBehaviour
{
    public Camera Camera;
    void Start()
    {
        this.transform.position = Camera.transform.position + new Vector3(0,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
