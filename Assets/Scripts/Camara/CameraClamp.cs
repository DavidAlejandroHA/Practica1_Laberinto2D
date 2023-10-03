using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public Transform target;
    float bordePrincipioX = -2.6f;
    float bordeFinalX = 25.5f;
    float bordePrincipioY = 0f;
    float bordeFinalY = 14.08f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameObject.Find("Fondo paisaje").GetComponent<BoxCollider2D>().size.x);
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, bordePrincipioX, bordeFinalX),
            Mathf.Clamp(target.position.y, bordePrincipioY, bordeFinalY),
            transform.position.z);
        //https://www.youtube.com/watch?v=ula1o_ZsMU0
    }
}
