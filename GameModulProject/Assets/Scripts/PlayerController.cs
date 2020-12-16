using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public Sprite[] sprites;
    public Sprite[] spritesWithSpeed;
    public Sprite[] spritesWithShield;
    public Sprite[] spritesWithBoth;
    public bool PlayerFollowMouse = true;
    public bool PlayerCanGetHit = true;
    public AudioClip AudioGetHit;

    private const int ShieldUpgradeModifier = 2;
    public float puRemoveObjectsRadius = 10f;
    public int maxHealth = 5;
    public float puInvulTime = 4f;
    private const float hitImmuneTime = 1f;


    private GameManager game;
    private Vector2 bounds;

    private float invulTimer = 0f;
    private float rotationSpeed = -0.5f;
    private bool PlayerIsInvul = false;

    private const int spriteArraySize = 4;
    private const float cameraShakeDuration = 0.18f;
    private int nRandomSpriteColor = 0;
    private SpriteRenderer spriteRenderer;

    public int Health { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
        bounds = game.PlayerBounds;
        
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        spriteRenderer = GetComponent<SpriteRenderer>();
        Health = maxHealth;
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerFollowMouse)
        {
            movePlayerToMouse();
        }
        if(invulTimer > 0)
        {
            invulTimer -= Time.deltaTime;
        }
        if(invulTimer > 0 || !PlayerCanGetHit)
        {
            if (!PlayerIsInvul)
            {
                PlayerIsInvul = true;
            }
            
            transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
        else
        {
            if(PlayerIsInvul)
            {
                PlayerIsInvul = false;
            }
        }

    }

    public void GetHit()
    {
        if (!PlayerIsInvul)
        {
            invulTimer += hitImmuneTime;
            Health--;
            AudioManager.Instance.PlaySound(AudioGetHit);
            Camera.main.GetComponent<CameraShake>().shakeDuration = cameraShakeDuration;
        }
        if(Health <= 0)
        {
            game.CurrentStage.SetStageResult(StageResult.Loss);
        }
    }

    public void RefillHealth()
    {
        Health = maxHealth;
    }

    public void PowerUpShield()
    {
        invulTimer += puInvulTime;
    }

    public void PowerUpHeart()
    {
        if(Health < maxHealth)
        {
            Health++;
        }
    }

    public void PowerUpRemoveObjects()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, puRemoveObjectsRadius,LayerMask.GetMask("Obstacle"));
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider.gameObject);
        }
    }

    public void PowerUpBossDamage()
    {

    }


    public void Death()
    {

    }


    public void Respawn()
    {
        nRandomSpriteColor = Random.Range(0, spriteArraySize);
        spriteRenderer.sprite = sprites[nRandomSpriteColor];
    }

    public void ApplyShieldUpgrade()
    {
        if(game.HasSpeedUpgrade())
        {
            spriteRenderer.sprite = spritesWithBoth[nRandomSpriteColor];
        }
        else
        {
            spriteRenderer.sprite = spritesWithShield[nRandomSpriteColor];
        }

        maxHealth *= ShieldUpgradeModifier;
        Health = maxHealth;
    }

    public void ApplySpeedUpgrade()
    {
        if (game.HasShieldUpgrade())
        {
            spriteRenderer.sprite = spritesWithBoth[nRandomSpriteColor];
        }
        else
        {
            spriteRenderer.sprite = spritesWithSpeed[nRandomSpriteColor];
        }
    }



    private void movePlayerToMouse()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 newPosition = new Vector2();


        if(mouse.x > -bounds.x && mouse.x < bounds.x)
        {
            newPosition.x = mouse.x;
        }
        else if(mouse.x <= -bounds.x)
        {
            newPosition.x = -bounds.x;
        }
        else if(mouse.x >= bounds.x)
        {
            newPosition.x = bounds.x;
        }
        if (mouse.y > -bounds.y && mouse.y < bounds.y)
        {
            newPosition.y = mouse.y;
        }
        else if (mouse.y <= -bounds.y)
        {
            newPosition.y = -bounds.y;
        }
        else if (mouse.y >= bounds.y)
        {
            newPosition.y = bounds.y;
        }

        transform.position = newPosition;

        //Debug.Log(newPosition.ToString());

    }
}
