using UnityEngine;
using System.Collections;

public class LevelManager : SingletonMonoBehaviour<LevelManager> {


	void Start()
	{
		DataSet.SetBool("FAILD", false);
		DataSet.Attatch("FAILD", Clear);

		ChangeState(DataSet.GetInt("GAMESTATE"));
		DataSet.Attatch("GAMESTATE", ChangeState);
	}


	void ChangeState(int state)
	{
		TrblGUI.State s = (TrblGUI.State)state;

		switch(s)
		{
		case TrblGUI.State.Title:
			speed = 0;
			break;
		case TrblGUI.State.Play:
			speed = 0.8f;
			break;
		case TrblGUI.State.GameOver:
			speed = 0;
			break;
		}
	}

	void OnDestroy()
	{
		DataSet.Detatch("GAMESTATE", ChangeState);
		DataSet.Detatch("FAILD", Clear);
	}

	public float speed = 1;

	void Clear(bool isFaild)
	{
		if( isFaild )
			speed = 0;
	}

}
