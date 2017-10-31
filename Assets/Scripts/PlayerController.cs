using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private bool _grounded;
    private string JUMP_ANIMATION = "Jump";

    public static float Score;

    public Transform FallingPoint;

    public LayerMask GroundLayer;
    public float JumpPower;
    public float RunSpeed;

    public float RunMultiplier;
    public float MultiplierSeconds;
    private float _timeAccum;

    private float _startX;

    public Text ScoreText;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _startX = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < FallingPoint.transform.position.y)
            EndGame();

        _timeAccum += Time.deltaTime;

        UpdateScore();

        if (_timeAccum >= MultiplierSeconds)
        {
            RunSpeed *= RunMultiplier;
            _timeAccum = 0;
        }

        _grounded = Physics2D.IsTouchingLayers(_collider, GroundLayer);
        gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0, gameObject.transform.rotation.w); 

        _rigidbody.velocity = new Vector2(RunSpeed, _rigidbody.velocity.y);

        if (Input.GetKey(KeyCode.Space) && _grounded)
        {
            Jump();
        }
	}

    private void Jump()
    {
        GetComponent<AudioSource>().Play();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpPower);
        _animator.Play(JUMP_ANIMATION);
    }

    private void UpdateScore()
    {
        var score = transform.position.x - _startX;
        Score = score;
        ScoreText.text = String.Format("Score: {0:0.00}mts", score);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("gameover");
    }
}
