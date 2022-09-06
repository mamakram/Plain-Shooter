using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 5.0f;
    public float shootRate = 1.0f;
    private float shootTimer =0.0f;
    public int maxHealth = 3;
    public int maxShield = 10;
    private int currentHealth;
    private int shield = 0;
    public GameObject shieldCircle;
    public Transform gunPoint;
    public Animator animator;

    public SpriteRenderer playerSr;
    public Color defaultColor;
    public Color defaultShieldColor;
    public TextMeshProUGUI text;
    public HealthBar healthBar;
    public HealthBar shieldBar;

    private bool tripleShot = false;
    private float shootUpgrade = 1f;
    private float distanceUpgrade = 0f;
    private bool isHit = false;
    //private InputMaster controls;

    [SerializeField]
    private InputActionReference movement, shoot;

    //private Vector2 move;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxHealth(maxShield);
        shieldBar.SetHealth(shield);
    }

    void Update(){
        shootTimer -= Time.deltaTime * shootRate * shootUpgrade ;
        Move(movement.action.ReadValue<Vector2>());
        if (shoot.action.IsPressed()) { Shoot(); }
    }


    public void Move(Vector2 move) {
        animator.SetFloat("x", move.x);
        animator.SetFloat("y", move.y);
        float newY = transform.position.y + move.y;
        float newX = transform.position.x + move.x;
        Vector3 newPosition = transform.position;

        //can't move outside of terrain bounds
        if (newY <=GameController.maxY && newY >= -GameController.maxY)
        {
            newPosition.y += move.y * speed * Time.deltaTime; 
        }
        if (newX <= GameController.maxX && newX >= -GameController.maxX)
        {
            newPosition.x += move.x * speed * Time.deltaTime;
        }
        transform.position = newPosition;
    }
    
    public void Shoot(){
        if(shootTimer<=0){
            float angle = 0f;
            Instantiate(bulletPrefab, gunPoint.position, Quaternion.Euler(0,0,angle));
            if (tripleShot)
            {
                Instantiate(bulletPrefab, gunPoint.position, Quaternion.Euler(0, 0, angle+35f));
                Instantiate(bulletPrefab, gunPoint.position, Quaternion.Euler(0, 0, angle-35f));
            }
            shootTimer=1;
        }
    }

    public void Upgrade(GameObject powerUp)
    {
        PowerUp upgrade = powerUp.GetComponent<PowerUp>();
        StartCoroutine("showUpgrade", upgrade.type);
        switch (upgrade.type) {
            case PowerUpType.Speed:
                shootUpgrade += 1;
                break;
            case PowerUpType.TripleShot:
                tripleShot= true;
                break;
            case PowerUpType.Distance:
                distanceUpgrade += 50f;
                bulletPrefab.GetComponent<Bullet>().decayUpgrade = distanceUpgrade;
                break;
            case PowerUpType.Health:
                currentHealth = Mathf.Clamp(currentHealth + 5, 0, maxHealth);
                healthBar.SetHealth(currentHealth);
                break;
            case PowerUpType.Shield:
                shield = maxShield;
                shieldCircle.SetActive(true);
                shieldBar.SetHealth(shield);
                break;
            default:break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PowerUp"))
        {
            Debug.Log("nice");
            Upgrade(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("EnemyProjectile")) && !isHit)
        {
            Debug.Log("ouch");
            isHit = true;
            StartCoroutine("SwitchColor", shield > 0);
            if (shield > 0) { shield -= 1; }
            else { currentHealth -= 1; }
            if (shield == 0) { shieldCircle.SetActive(false); }
            healthBar.SetHealth(currentHealth);
            shieldBar.SetHealth(shield);
            Debug.Log(currentHealth+" "+shield);
        }
    }

    public bool Dead()
    {
        return currentHealth <= 0;
    }

    IEnumerator SwitchColor(bool colorShield)
    {
        if (colorShield) { shieldCircle.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f,.5f); }
        else { playerSr.color = new Color(1f, 0.5f, 0.5f); }

        yield return new WaitForSeconds(0.5f);
        if (colorShield) { shieldCircle.GetComponent<SpriteRenderer>().color = defaultShieldColor; }
        else { playerSr.color = defaultColor; }
        isHit = false;
    }


    IEnumerator showUpgrade(PowerUpType powerUpType)
    {
        text.text = "+ "+powerUpType.ToString();
        yield return new WaitForSeconds(2f);
        text.text = "";
    }
}
