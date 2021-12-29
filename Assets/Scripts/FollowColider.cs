using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowColider : MonoBehaviour
{
    public MoveEnemy owner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            owner.OnFollow(collision.GetComponent<MoveEnemy>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            owner.OffFollow(collision.GetComponent<MoveEnemy>());
        }
    }
}
