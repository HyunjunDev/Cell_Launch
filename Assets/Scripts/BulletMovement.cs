using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    PoolObjectType objectType;

    public float speed = 30;
    private Player player;
    Vector2 bulletDirection;
    public GameObject bullet;
    public ExpSystem exp;
    private void Awake()
    {
        player = FindObjectOfType<Player>();

        exp = FindObjectOfType<ExpSystem>();

        bullet = this.gameObject;

        bulletDirection = player.b_Dir.position;
    }
    void Update()
    {
        if (exp.playerLevel >= 6)
        {
            speed = 40;
        }
        if (exp.playerLevel >= 3 && exp.playerLevel<6)
        {
            speed = 27;
        }
        bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, bulletDirection, speed * Time.deltaTime);
        if ((Vector2)bullet.transform.position == bulletDirection)
        {
            if (exp.playerLevel >= 4)
            {
                player.deadEffect = ObjectPool.Instance.GetObject(PoolObjectType.PlayerDeadParticle);
                player.deadEffect.transform.position = transform.position;
            }
            ObjectPool.Instance.ReturnObject(PoolObjectType.Bullet, gameObject);
        }
    }
    private void OnEnable()
    {
        bulletDirection = player.b_Dir.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("MoveEnemy"))
        {
            if(exp.playerLevel>=4)
            {
                player.deadEffect= ObjectPool.Instance.GetObject(PoolObjectType.PlayerDeadParticle);
                player.deadEffect.transform.position = transform.position;
            }
            ObjectPool.Instance.ReturnObject(PoolObjectType.Bullet, gameObject);
        }
    }
}
