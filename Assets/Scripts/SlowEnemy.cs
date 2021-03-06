using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : MonoBehaviour
{
    private Vector3 vl;
    private Vector3 vr;

    public bool right;

    public int state;
    
    // Start is called before the first frame update
    void Start()
    {
        vl = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        vr = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        StartCoroutine(dest());
        //gameObject.GetComponent<Animator>().SetBool("Move", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            if (!right)
            {
                transform.position = Vector3.MoveTowards(transform.position, vl, 1 * Time.deltaTime);
                if (Vector3.Distance(transform.position, vl) < 0.0001f)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    right = true;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, vr, 1 * Time.deltaTime);
                if (Vector3.Distance(transform.position, vr) < 0.00001f)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    right = false;
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && (other.gameObject.GetComponent<Sonic>().isJumpball ||
                                                 other.gameObject.GetComponent<Sonic>().isRolling))
        {
            if (state == 0)
            {
                GameManager.gm.score += 500;
                other.gameObject.GetComponent<Sonic>().destroy(); 
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<Sonic>().getHit();
            }
        }
        else if (other.gameObject.tag == "Player" && (!other.gameObject.GetComponent<Sonic>().isJumpball ||
                                                 !other.gameObject.GetComponent<Sonic>().isRolling))
        {
            if (state == 1)
            {
                other.gameObject.GetComponent<Sonic>().getHit();
            }    
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && (other.gameObject.GetComponent<Sonic>().isJumpball ||
                                                 other.gameObject.GetComponent<Sonic>().isRolling))
        {
            if (state == 0)
            {
                GameManager.gm.score += 500;
                other.gameObject.GetComponent<Sonic>().destroy();
                Destroy(gameObject);
            }
            else
            {
                other.gameObject.GetComponent<Sonic>().getHit();
            }
        }
        else if (other.gameObject.tag == "Player" && (!other.gameObject.GetComponent<Sonic>().isJumpball ||
                                                 !other.gameObject.GetComponent<Sonic>().isRolling))
        {
            if (state == 1)
            {
                other.gameObject.GetComponent<Sonic>().getHit();
            }
        }
    }

    public IEnumerator dest()
    {
        yield return new WaitForSeconds(3);
        if (state == 0)
        {
            state = 1;
            gameObject.GetComponent<Animator>().SetBool("Move", false);
            gameObject.tag = "Spike";
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Move", true);
            state = 0;
            gameObject.tag = "Untagged";
        }
        StartCoroutine(dest());
    }
}
