using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformGenerator : MonoBehaviour
{
    private static System.Random Random = new System.Random();

    public Transform GenerationPoint;
    public GameObject[] Platforms;

    public GameObject LastPlatform;
    private float _lastWidth;

    public float MinPlatformDistance;
    public float MaxPlatformDistance;

    public Transform MinHeightPoint;
    public Transform MaxHeightPoint;
    public float MaxHeightChange;

    // Use this for initialization
    void Start () {
        _lastWidth = GetPlatformLength(LastPlatform);
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < GenerationPoint.position.x)
        {
            var platform = GetNextPlatform();
            var width = GetPlatformLength(platform);

            var platformOffset = (width + _lastWidth) / 2;
            var distance = UnityEngine.Random.Range(MinPlatformDistance, MaxPlatformDistance);
            var newX = transform.position.x + platformOffset + distance;

            var heightDelta = (Random.NextDouble()*2-1)*MaxHeightChange;
            var newY = (float)(transform.position.y + heightDelta);
            if (newY > MaxHeightPoint.position.y)
            {
                newY = MaxHeightPoint.position.y;
            } else if (newY < MinHeightPoint.position.y)
            {
                newY = MinHeightPoint.position.y;
            }

            transform.position = new Vector3(newX, newY, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);

            LastPlatform = platform;
            _lastWidth = width;
        }
	}

    private GameObject GetNextPlatform()
    {
        var index = Random.Next(Platforms.Length);
        return Platforms[index];
    }

    private float GetPlatformLength(GameObject platform)
    {
        return platform.GetComponent<BoxCollider2D>().size.x;
    }
}
