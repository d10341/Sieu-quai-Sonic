using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private float distance;//khoangr cachs voi nguoi choi
    public float wakerange;//khoang cach tinh
    public float shootinterval;//chu kỳ tấn công
    public float bulletspeed = 5;//tốc độ
    public float bullettimer;

    public bool awake = false;

    public GameObject bullet;
    public Transform target;
    public Transform shootL;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RangeCheck();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && (other.gameObject.GetComponent<Sonic>().isJumpball ||
                                                 other.gameObject.GetComponent<Sonic>().isRolling))
        {
            GameManager.gm.score += 500;
            other.gameObject.GetComponent<Sonic>().destroy();
            Destroy(gameObject);
        }
    }

    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < wakerange)
            awake = true;

        if (distance > wakerange)
            awake = false;
    }

    public void Attack()
    {
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)//time chờ đủ
        {
            Vector2 direction = target.transform.position - transform.position;//trụ-người chơi
            direction.y += 0.9f;
            direction.Normalize();//bình thường hóa


            GameObject bulletclone;
            bulletclone = Instantiate(bullet, shootL.transform.position, shootL.transform.rotation) as GameObject;
            bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

            bullettimer = 0;

        }
    }



}
