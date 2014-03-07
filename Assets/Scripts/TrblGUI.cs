using UnityEngine;
using System.Collections;

public class TrblGUI : MonoBehaviour {

	public enum State
	{
		Title,
		Play,
		GameOver
	}

	State currentState;
	int currentScore;


	void Awake()
	{
		DataSet.Attatch("GAMESTATE", ChangeState);
		DataSet.Attatch("SCORE", GetScore);

		DataSet.SetInt("GAMESTATE", (int)State.Title);
	}

	void OnDestroy()
	{
		DataSet.Detatch("GAMESTATE", ChangeState);
		DataSet.Detatch("SCORE", GetScore);
	}


	void GetScore(int score)
	{
		currentScore = score;
	}

	void ChangeState(int state)
	{
		currentState = (State)state;
	}


	
	void OnGUI()
	{
		switch(currentState )
		{
		case State.Title:
			Title();
			break;
		case State.Play:
			Play();
			break;
		case State.GameOver:
			GameOver();
			break;
		}
	}

	void Title ()
	{
		if( GUILayout.Button("start") )
		{
			DataSet.SetInt("GAMESTATE", (int)State.Play);
		}
	}
	
	void GameOver ()
	{
		GUILayout.Label( string.Format( "{0}: {1}", "SCORE", currentScore));
		if( GUILayout.Button("Restart"))
		{
			Application.LoadLevel(0);
		}
	}

	void Play()
	{
		GUILayout.Label( string.Format( "{0}: {1}", "FAILD", DataSet.GetBool("FAILD")));
		GUILayout.Label( string.Format( "{0}: {1}", "SCORE", currentScore));
	}
}
