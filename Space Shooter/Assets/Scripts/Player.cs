using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private float _fireRate = 0.3f;
    [SerializeField]
    private float _canFire = 0f;
    [SerializeField]
    private int _playerLife = 3;

    [SerializeField]
    private GameObject _LaserPrefab = null;

    private SpawnManager _spawnManager;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if(_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_LaserPrefab, new Vector3(transform.position.x,transform.position.y + 0.8f,0), Quaternion.identity);
        }
    }

    void PlayerMovement()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        float _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(_horizontalInput, _verticalInput, 0) * _speed * Time.deltaTime);

        if (transform.position.x > 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, 0);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, 0);
        }
        else if (transform.position.y > 5.7f)
        {
            transform.position = new Vector3(transform.position.x, 5.7f, 0);
        }
        else if (transform.position.y < -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
    }

    public void damagePlayer()
    {
        _playerLife--;

        if(_playerLife <= 0)
        {
            //comunicate with spawn manager
            //let them to stop spawn when dead
            _spawnManager.PlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
