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
    public GameObject bullet;
    private void Awake()
    {
        player = FindObjectOfType<Player>();

        bullet = this.gameObject;

        bulletDirection = player.b_Dir.position;
    }
    void Update()
    {
        bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, bulletDirection, speed * Time.deltaTime);
        if ((Vector2)bullet.transform.position == bulletDirection)
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.Bullet, gameObject);
        }
    }
    private void OnEnable()
    {
        bulletDirection = player.b_Dir.position;
    }
}
