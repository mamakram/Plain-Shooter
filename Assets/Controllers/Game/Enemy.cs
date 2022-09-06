using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score = 100;
    public int health = 1;
    public Color defaultColor;
    public SpriteRenderer sr;
    public Animator animator;
    public Movement[] movements;
    public Shooter[] shooters;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (-GameController.maxX))
        {
            Object.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AllyProjectile"))
        {
            health -= 1;
            if (health <= 0)
            {
                Debug.Log("ouch");
                Died();
            }
            else
            {
                StartCoroutine("SwitchColor");
            }
        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = new Color(1f, 0.5f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        sr.color = defaultColor;
    }

    protected virtual void Died()
    {
        animator.SetBool("dead", true);
        StopMoving();
        StopShooting();
        GetComponent<Collider2D>().enabled = false;
        GetComponent<DeathBehaviour>().Died();
        Object.Destroy(gameObject, 0.5f);
        Score.AddScore(score);
    }

    private void StopMoving()
    {
        foreach(Movement movement in movements)
        {
            movement.StopMoving();
        }
    }

    private void StopShooting()
    {
        foreach (Shooter shooter in shooters)
        {
            shooter.StopShooting();
        }
    }
}
