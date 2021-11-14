using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    PoolObjectType objectType;
    [SerializeField]
    private float speed = 30;
    private Player player;
    Vector2 bulletDirection;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        bulletDirection = player.b_Dir.position;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, bulletDirection, speed * Time.deltaTime);
        if ((Vector2)transform.position == bulletDirection)
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.Bullet, gameObject);
        }
    }
    private void OnEnable()
    {
        bulletDirection = player.b_Dir.position;
    }
}
