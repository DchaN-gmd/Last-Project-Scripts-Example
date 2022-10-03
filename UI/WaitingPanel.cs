using SerializeInterface.Runtime;
using UnityEngine;

public class WaitingPanel : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeReference, Selector] private IPaused _pauseSystem;
    [SerializeField] private GameObject _panel;

    [Header("Parameters")]
    [SerializeField] private KeyCode _key;

    private bool _isActivate = false;

    private void Awake()
    {
        _panel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(_key))
        {
            if (_isActivate) _pauseSystem.Play();
            else _pauseSystem.Pause();

            _isActivate = !_isActivate; 
            _panel.SetActive(!_panel.activeSelf);
        }
    }
}
