using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-10f, 10f), 8.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -5.5f)
        {
            transform.position = new Vector3(Random.Range(-10f, 10f), 8.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Player")
        {

            //other = input gameobject
            //transform = root of the gameobject
            //GetComponent<Component name> = Get component of the gameobject, <> is the name of the component
            //i.e the below is getting the Player component which is the script.
            //damagePlayer = function in player script.
            Player _player = other.transform.GetComponent<Player>();
            if(_player != null)
            {
                _player.damagePlayer();
            }
            Destroy(this.gameObject);
        }
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);  //destroy laser
            Destroy(this.gameObject); 
        }
    }
}
