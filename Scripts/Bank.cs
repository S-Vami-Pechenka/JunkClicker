using System;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour {
    [SerializeField] private int _money;
    [SerializeField] private int _totalSource;

    [SerializeField] private Dictionary<string, int> _moneySource = new Dictionary<string, int>( );

    private void Start( ) {
        EventBus.Instance.StartListening( "AddMoney", MoneyChange );
        EventBus.Instance.StartListening( "UpdateSource", AddSource );
        EventBus.Instance.StartListening( "AddMoneyPerSecond", AddMoneyPerSecond );
    }

    private void MoneyChange( object[ ] arg0 ) {
        int value = ( int ) arg0[ 0 ];
        MoneyChange( value );
    }

    private void AddMoneyPerSecond( object[ ] arg0 ) {
        MoneyChange( _totalSource );
    }

    private void MoneyChange( int value ) {
        var temp = _money + value;
        if ( temp < 0 ) {
            Debug.Log( "����� �� �������" );
            return;
        }
        _money = temp;
        EventBus.Instance.TriggerEvent( "MoneyChanged", _money );
    }

    private void AddSource( object[ ] objects ) {
        string name = ( string ) objects[ 0 ];
        int profit = ( int ) objects[ 1 ];
        if ( _moneySource.TryGetValue( name, out int value ) ) {
            if ( value == profit ) return;
            Debug.Log( $"��������: {name}\n����� ��: {value}, �����:{profit}" );
            _moneySource[ name ] = profit;
        }
        else {
            Debug.Log( $"�������� ��������: {name}\n����� ����������: {profit}" );
            _moneySource.Add( name, profit );
        }
        int temp = 0;
        foreach ( var item in _moneySource ) {
            temp += item.Value;
        }

        _totalSource = temp;

        Debug.Log( $"����� ����������: {_moneySource.Count}\n����� �� ���� ����������: {_totalSource}" );
    }
}