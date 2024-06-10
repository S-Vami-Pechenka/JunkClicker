using UnityEngine;
using UnityEngine.UI;

[RequireComponent( typeof( Button ) )]
public class Btn_Click : MonoBehaviour {
    [SerializeField] private Button _btn;

    void Start( ) {
        _btn = GetComponent<Button>( );
    }
    public void OnClick( int value ) {
        EventBus.Instance.TriggerEvent( "AddMoney", value );
    }
}