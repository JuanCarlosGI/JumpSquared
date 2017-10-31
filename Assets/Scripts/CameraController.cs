using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerController _player;
    private float _playerPosition;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<PlayerController>();
        _playerPosition = _player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        var delta = _player.transform.position.x - _playerPosition;
        transform.position = new Vector3(transform.position.x + delta, transform.position.y, transform.position.z);
        _playerPosition = _player.transform.position.x;
	}
}
