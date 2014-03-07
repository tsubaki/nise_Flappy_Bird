using UnityEngine;
using System.Collections;

public class RotateSprite : MonoBehaviour {

	SpriteRenderer m_sprite;

	void Start()
	{
		m_sprite = GetComponent<SpriteRenderer>();
		DataSet.Attatch("FAILD",Faild);
	}

	void OnDestroy()
	{
		DataSet.Detatch("FAILD", Faild);
	}

	void Update () {

		Vector2 up = (rigidbody2D.velocity.y < 0) ? (rigidbody2D.velocity + Vector2.right) : Vector2.right;
		transform.localRotation = Quaternion.FromToRotation(Vector3.right, up.normalized); 
	
	}

	void Faild(bool isFaild)
	{
		if( isFaild )
		{
			enabled = false;
		}
	}

}
