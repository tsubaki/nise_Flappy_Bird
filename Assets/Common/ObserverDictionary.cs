using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObserverDictionary<T> : IDisposable   where T : System.IComparable
{

	public delegate void NotificationAction (T t);
	
	private Dictionary<string, NotificationClass> dic = new Dictionary<string, NotificationClass> ();

	public T this [string key] {
		get {
			return 	CheckKey (key).data;
		}
		set {
			NotificationClass param = CheckKey (key);
			if (param.data.CompareTo (value) != 0) {
				param.data = value;
				param.Play ();
			}
		}
	}

	public int Count {
		get {
			return dic.Count;
		}
	}
	
	public void AddObserver (string key, NotificationAction action)
	{
		NotificationClass param = CheckKey (key);
		param.Add (action);
	}

	public void RemoveObserver (string key, NotificationAction action)
	{
		NotificationClass param = CheckKey (key);
		param.Remove (action);
	}

	public void Dispose ()
	{
		foreach (var item in dic.Values) {
			item.Clear ();
		}
		dic.Clear ();
	}

	protected NotificationClass CheckKey (string key)
	{
		if (dic.ContainsKey (key)) {
			return dic [key];
		} else {
			NotificationClass param = new NotificationClass ();
			dic [key] = param;
			return param;
		}
	}

	protected class NotificationClass
	{
		public T data;

		public event NotificationAction action;

		public void Play ()
		{
			if (action != null)
				action (data);
		}

		public void Clear ()
		{
			action = null;
		}

		public void Add (NotificationAction act)
		{
			action += act;
		}

		public void Remove (NotificationAction act)
		{
			action -= act;
		}
	}
}
