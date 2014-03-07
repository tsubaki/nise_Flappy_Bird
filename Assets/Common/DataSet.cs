using UnityEngine;
using System.Collections;

public class DataSet : SingletonMonoBehaviour<DataSet> {

	public ObserverDictionary<bool> notiBool = new ObserverDictionary<bool>();
	public ObserverDictionary<int> notiInt = new ObserverDictionary<int>();

	public static void Attatch(string key, ObserverDictionary<bool>.NotificationAction action)
	{
		Instance.notiBool.AddObserver(key, action);
	}
	public static void Attatch(string key, ObserverDictionary<int>.NotificationAction action)
	{
		Instance.notiInt.AddObserver(key, action);
	}
	public static void Detatch(string key, ObserverDictionary<bool>.NotificationAction action)
	{
		if( Instance != null)
			Instance.notiBool.RemoveObserver(key, action);
	}
	public static void Detatch(string key, ObserverDictionary<int>.NotificationAction action)
	{
		if( Instance != null)
			Instance.notiInt.RemoveObserver(key, action);
	}

	public static int GetInt(string key)
	{
		return Instance.notiInt[key];
	}
	public static bool GetBool(string key)
	{
		return Instance.notiBool[key];
	}

	public static void SetInt(string key, int value)
	{
		Instance.notiInt[key] = value;
	}
	public static void SetBool(string key, bool value)
	{
		Instance.notiBool[key] = value;
	}


	void OnDestroy()
	{
		notiBool.Dispose();
		notiInt.Dispose();
	}
}
