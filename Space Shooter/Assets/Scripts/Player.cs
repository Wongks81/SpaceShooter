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

        transform.Translate(new Vector3(_horizontalInput, _verticalInput, 0) * _speed * Time.deltaTime);
        
        if(transform.position.x > 11f)
        {
            transform.position = new Vector3(-11f,transform.position.y,0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
        else if(transform.position.y > 7.6f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f, 0);
        }
        else if(transform.position.y < -5.5f)
        {
            transform.position = new Vector3(transform.position.x, 7.6f, 0);
        }
    }
}
