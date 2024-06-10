using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private void Start( ) {
        StartCoroutine( TimerCoroutine( ) );
    }

    private IEnumerator TimerCoroutine( ) {
        while ( true ) {
            EventBus.Instance.TriggerEvent( "AddMoneyPerSecond" );
            yield return new WaitForSeconds( 1 );
        }
    }
}
