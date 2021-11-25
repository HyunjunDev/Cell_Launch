using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    //private Transform player;

    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("").transform;
    //}
    private void Update()
    {
        if(Vector2.Distance(transform.position,Camera.main.transform.position)>stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Camera.main.transform.position) < stoppingDistance && Vector2.Distance(transform.position, Camera.main.transform.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, Camera.main.transform.position) <retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.transform.position, -speed * Time.deltaTime);
        }
    }
}
