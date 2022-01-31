using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] float _playerSpeed = 7f;
    [SerializeField] float _gravity = 0.8f;
    [SerializeField] float _jumpHeight = 30;
    float _yVelocity;
    int _playerCoin = 0;
    int _lives = 3;
    bool _hasDoubleJump = false;
    UiManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        _uiManager.UpdaterLivesText(_lives);

        if (_controller == null)
        {
            Debug.LogError("Player: _controller is null");
        }

        if (_uiManager == null)
        {
            Debug.LogError("Player: _uiManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 velocity = direction * _playerSpeed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _hasDoubleJump = true;
                _yVelocity = _jumpHeight;
            }
        }
        else
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && _hasDoubleJump)
            {
                Debug.Log("Double jump");
                _hasDoubleJump = false;
                _yVelocity += _jumpHeight * 2;
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void incrementCoin()
    {
        _playerCoin++;
        _uiManager.UpdtadeCoinBoard(_playerCoin);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController cc;

       if (other.tag == "DeadZone")
        {
            Vector3 respawnPos = GameObject.Find("Respawn").transform.position;

            cc = GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                this.transform.position = respawnPos;
                cc.enabled = true;
            }

            _lives--;
            _uiManager.UpdaterLivesText(_lives);

            if (_lives < 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
