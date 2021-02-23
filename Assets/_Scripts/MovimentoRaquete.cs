using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    // Add slider on Unity's UI.
    [Range(1, 10)]
    public float speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * speed;
    }
}
