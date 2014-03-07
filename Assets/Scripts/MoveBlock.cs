using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	Rigidbody2D _rigidbody2d;

	[SerializeField]
	float rate = 1;

	void Start()
	{
		_rigidbody2d = rigidbody2D;
	}

	void FixedUpdate()
	{
		_rigidbody2d.velocity = Vector3.left * LevelManager.Instance.speed * rate;
	}
}
