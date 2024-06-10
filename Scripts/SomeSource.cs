using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SomeSource : MonoBehaviour {
    [SerializeField] private string _name;
    [SerializeField] private int _profit;
    [SerializeField] private Button _btn;

    private void Start( ) {
        _name = transform.name;
        _btn = GetComponentInChildren<Button>( );
        _btn.GetComponentInChildren<TMP_Text>().text = $"+{_profit}";
    }

    public void OnClick( ) {
        EventBus.Instance.TriggerEvent( "UpdateSource", _name, _profit );
    }


}
