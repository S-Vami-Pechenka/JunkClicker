using System;
using TMPro;
using UnityEngine;

[RequireComponent( typeof( TMP_Text ) )]
public class Text_Visual : MonoBehaviour {
    private TMP_Text _text;
    private const string _preText = "Монеток: ";
    private void Start( ) {
        _text = GetComponent<TMP_Text>( );
        EventBus.Instance.StartListening( "MoneyChanged", UpdateText );
    }

    private void UpdateText( object[ ] arg0 ) {
        int value = ( int ) arg0[ 0 ];
        _text.text = $"{_preText}{value}";
    }

}
