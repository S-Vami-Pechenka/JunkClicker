using UnityEngine.Events;
using System.Collections.Generic;
using System;

public class EventBus {
    private Dictionary<string, UnityEvent<object[ ]>> eventDictionary = new Dictionary<string, UnityEvent<object[ ]>>( );

    private static EventBus eventBus;

    public static EventBus Instance {
        get {
            if ( eventBus == null )
                eventBus = new EventBus( );
            return eventBus;
        }
    }

    public void StartListening( string eventName, UnityAction<object[ ]> listener ) {
        UnityEvent<object[ ]> thisEvent = null;
        if ( Instance.eventDictionary.TryGetValue( eventName, out thisEvent ) ) {
            thisEvent.AddListener( listener );
            return;
        }
        thisEvent = new UnityEvent<object[ ]>( );
        thisEvent.AddListener( listener );
        Instance.eventDictionary.Add( eventName, thisEvent );
    }

    public void StopListening( string eventName, UnityAction<object[ ]> listener ) {
        if ( eventBus == null ) return;
        UnityEvent<object[ ]> thisEvent = null;
        if ( Instance.eventDictionary.TryGetValue( eventName, out thisEvent ) ) {
            thisEvent.RemoveListener( listener );
        }
    }

    public void TriggerEvent( string eventName, params object[ ] parameters ) {
        UnityEvent<object[ ]> thisEvent = null;
        if ( Instance.eventDictionary.TryGetValue( eventName, out thisEvent ) ) {
            thisEvent.Invoke( parameters );
        }
    }
}
