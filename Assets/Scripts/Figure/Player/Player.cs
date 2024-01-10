using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int idPlayer;
    [SerializeField] private int _typePlayer;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator anm;
    [SerializeField] private bool isDie;
    [SerializeField] private GameObject _bullet1, _bullet3, _light1, _light3, headGun;
    int move;
    float horizontalInput;
    float verticalInput;
    
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 velocity = new Vector2(horizontalInput, verticalInput);
        if (velocity.x == 0f || velocity.y == 0f)
            _rb.velocity = velocity * speed;
        if (verticalInput == 0f)
        {
            if (horizontalInput == -1f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90f);
                move = 4;
            }   
            else if (horizontalInput == 1f)
            {

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90f);
                move = 6;
            }    
        }
        if (horizontalInput == 0f)
        {
            if (verticalInput == 1f)
            {

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
                move = 8;
            }
            else if (verticalInput == -1f)
            {

                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -180f);
                move = 2;
            }
        }
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    velocity = new Vector2(0, 3f);
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
        //    move = 8;
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{

        //    velocity = new Vector2(0, -3f);
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -180f);
        //    move = 2;
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{

        //    velocity = new Vector2(-3f, 0);
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90f);
        //    move = 4;
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    velocity = new Vector2(3f, 0);
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90f);
        //    move = 6;
        //}
        //if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    velocity = new Vector2(0, 0);
        //}
        //_rb.velocity = velocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet;
            if (_typePlayer == 1)
            {
                newBullet = Instantiate(_bullet1, transform.position, _bullet1.transform.rotation);
                _light1.SetActive(true);
                Invoke("resetLight1", 0.3f);
            }
            else
            {
                newBullet = Instantiate(_bullet3, transform.position, _bullet3.transform.rotation);
                _light3.SetActive(true);
                Invoke("resetLight3", 0.3f);
            }

            if (move == 2)
            {
                newBullet.GetComponent<Bullet>().velocity = new Vector3(0, -0.03f, 0);
                newBullet.transform.position = new Vector3(transform.position.x, transform.position.y, newBullet.transform.position.z);
                newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, -180f);
            }
            else if (move == 8)
            {
                newBullet.GetComponent<Bullet>().velocity = new Vector3(0, 0.03f, 0);
                newBullet.transform.position = new Vector3(transform.position.x, transform.position.y, newBullet.transform.position.z);
                newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, 0f);
            }
            else if (move == 4)
            {
                newBullet.GetComponent<Bullet>().velocity = new Vector3(-0.03f, 0, 0);
                newBullet.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, newBullet.transform.position.z);
                newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, 90f);
            }
            else
            {
                newBullet.GetComponent<Bullet>().velocity = new Vector3(0.03f, 0, 0);
                newBullet.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, newBullet.transform.position.z);
                newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, -90f);
            }
            newBullet.GetComponent<Bullet>().setVelocity();
        }
    }
    void resetLight1()
    {
        _light1.SetActive(false);
    }
    void resetLight3()
    {
        _light3.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!isDie)
        //{
        //    anm.Play("die");
        //    headGun.SetActive(false);
        //    Invoke("_des", 1f);
        //    isDie = true;
        //}
        
    }
    void _des()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
