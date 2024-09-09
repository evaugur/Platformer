using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private float startLocation;
    private float endLocation;
    [SerializeField] float distance;
    private Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position.x;
        endLocation = startLocation + distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Invisible Wall")
        {
            if (transform.position.x == endLocation)
            {
                direction = Vector3.left;
            }
            if (transform.position.x == startLocation)
            {
                direction = Vector3.right;
            }
        }
    }
}
