using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingColider : MonoBehaviour
{
    public MoveEnemy owner;

    public Vector2 bulletT;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Bullet")
        {
            bulletT = collision.transform.position;
            owner.OnMoving(collision.GetComponent<MoveEnemy>());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {

            bulletT = collision.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            owner.OffMoving(collision.GetComponent<MoveEnemy>());
        }
    }
}
