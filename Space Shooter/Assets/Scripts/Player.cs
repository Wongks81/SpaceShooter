using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");
       
        transform.Translate(Vector3.right *_horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * _verticalInput * _speed * Time.deltaTime);

        
    }
}
