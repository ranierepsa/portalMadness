using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

/*
Unity C# Event manager using UnityEvents and a Hashtable for loosely typed params with event.
This EventManager expands the usefulness of UnityEvents by allowing values of any type to be passed as a
parameter in the Event eg: int, string, Vector3 etc.

Usage:

// Add Listener for Event
EventManager.StartListening ("MY_EVENT", MyEventHandlerMethodName);

// Trigger Event:
EventManager.TriggerEvent ("MY_EVENT", new Hashtable(){{"MY_EVENT_KEY", "valueOfAnyType"}});

// Pass null instead of a Hashtable if no params
EventManager.TriggerEvent ("MY_EVENT", null);

// Handler
private void HandleTeleportEvent (Hashtable eventParams){
	if (eventParams.ContainsKey("MY_EVENT")){
		// DO SOMETHING
	}
}

*/

public class ThisEvent : UnityEvent<Hashtable> { }

public class UnityEventManager : MonoBehaviour
{

	private Dictionary<string, ThisEvent> eventDictionary;

	private static UnityEventManager eventManager;

	//	SINGLETON
	public static UnityEventManager Instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType(typeof(UnityEventManager)) as UnityEventManager;

				if (!eventManager)
				{
					Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init();
				}
			}

			return eventManager;
		}
	}

	void Init()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, ThisEvent>();
		}
	}

	public static void StartListening(string eventName, UnityAction<Hashtable> listener)
	{
		if (Instance.eventDictionary.TryGetValue(eventName, out ThisEvent thisEvent))
		{
			thisEvent.AddListener(listener);
		}
		else
		{
			thisEvent = new ThisEvent();
			thisEvent.AddListener(listener);
			Instance.eventDictionary.Add(eventName, thisEvent);
		}
	}

	public static void StopListening(string eventName, UnityAction<Hashtable> listener)
	{
		if (eventManager == null) return;
        if (Instance.eventDictionary.TryGetValue(eventName, out ThisEvent thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

	//public static void TriggerEvent(string eventName, Hashtable eventParams = default(Hashtable))
	public static void TriggerEvent(string eventName, Hashtable eventParams = default)
	{
		if (Instance.eventDictionary.TryGetValue(eventName, out ThisEvent thisEvent))
		{
			thisEvent.Invoke(eventParams);
		}
	}

	public static void TriggerEvent(string eventName)
	{
		TriggerEvent(eventName, null);
	}
}