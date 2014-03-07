using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {


	[SerializeField]
	private float power = 3;

	Rigidbody2D _rigidbody2d;


	void Start () {
		_rigidbody2d = rigidbody2D;

		DataSet.Attatch("FAILD", Faild);

		ChangeState(DataSet.GetInt("GAMESTATE"));
		DataSet.Attatch("GAMESTATE", ChangeState);
	}

	void OnDestroy()
	{
		DataSet.Detatch("FAILD", Faild);
		DataSet.Detatch("GAMESTATE", ChangeState);
	}
	


	void Update () {

		if( Input.GetMouseButtonDown(0))
		{
			_rigidbody2d.velocity = Vector3.up * power;
		}
	}

	void ChangeState(int state)
	{
		switch((TrblGUI.State)state)
		{
		case TrblGUI.State.Title:
			_rigidbody2d.isKinematic = true;
			enabled = false;
			break;
		case TrblGUI.State.Play:
			_rigidbody2d.isKinematic = false;
			enabled = true;
			break;
		}
	}

	void Faild(bool isFaild)
	{
		if( isFaild )
			_rigidbody2d.velocity = Vector3.zero;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		enabled = false;
		DataSet.SetBool("FAILD", true);
		DataSet.SetInt("GAMESTATE", (int) TrblGUI.State.GameOver);
	}
}
