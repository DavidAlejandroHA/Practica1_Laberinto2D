using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedRotatoria : MonoBehaviour
{
    public float velocidad = 80f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * velocidad);
    }
}
