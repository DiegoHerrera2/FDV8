using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float thrust = 30.0f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text scoreText;
    private int _lastMoveX;
    private State _state = State.Idle;
    private Rigidbody2D rb;
    
    private bool _isGrounded;
    private bool _jumpPressed;
    private int score = 0;
    
    public Action OnCollectibleCollected;
    
    private enum State
    {
        Idle,
        Walk
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        OnCollectibleCollected += () =>
        {
            thrust += 10;
            score += 1;
            scoreText.text = score.ToString();
        };
    }

    // Update is called once per frame
    private void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        
        animator.SetFloat("Horizontal", x);
        switch (_state)
        {
            case State.Idle:
                animator.SetBool("isWalking", false);
                if (x != 0)
                {
                    _state = State.Walk;
                }
                break;    
            case State.Walk:
                animator.SetBool("isWalking", true);
                spriteRenderer.flipX = _lastMoveX > 0;
                _lastMoveX = x > 0 ? 1 : -1;
                if (x == 0)
                {
                    _state = State.Idle;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpPressed = true;
        }
    }
    
    

    private void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");

        var velocity = new Vector2(x * speed * Time.fixedDeltaTime, rb.velocity.y);

        rb.velocity = velocity;
        
        CheckGrounded();
        
        if (_jumpPressed && _isGrounded)
        {
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
            _isGrounded = false;
            _jumpPressed = false;
        }
    }
    
    private void CheckGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        _isGrounded = hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(other.transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }
}
