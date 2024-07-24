using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D _rigRigidbody2D;
    private PlayerDialogue _playerDialogue;
    private float _xVelocity = 0f;
    private float _yVelocity = 0f;
    public float speed = 3;
    public float xMultiplier = 2;

    public SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigRigidbody2D = GetComponent<Rigidbody2D>();
        _playerDialogue = GetComponent<PlayerDialogue>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerDialogue.IsSpeaking())
        {
            _xVelocity = 0;
            _yVelocity = 0;
        }
        else
        {
            _xVelocity = Input.GetAxis(Structs.Input.horizontal);
            _yVelocity = Input.GetAxis(Structs.Input.vertical);
        }

        
        _rigRigidbody2D.velocity = new Vector2(_xVelocity, _yVelocity) * speed;

        float xMovement = Input.GetAxis("Horizontal");

        // Flips the sprite if movement is 0 or more, keep it flipped if it's less than 0
        if (xMovement >= 0) { _spriteRenderer.flipX = true; }
        else { _spriteRenderer.flipX = false; }

        // Give the speed to the rigidbody
        _rigRigidbody2D.velocity = new Vector2(xMultiplier * xMovement, _rigRigidbody2D.velocity.y);


    }
}
