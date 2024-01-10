using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    [SerializeField] private Animator anm;
    [SerializeField] private bool isDie;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cham");
        velocity = new Vector3(0, 0, 0);
        if (!isDie)
        {
            isDie = true;
            anm.Play("gun");
            Invoke("_des", 0.2f);
        }

    }
    void _des()
    {

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
