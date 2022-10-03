using LoadSystems;
using SerializeInterface.Runtime;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        #region Inspector Fields
        [Header("Controllers")]
        [SerializeReference, Selector] private IPaused _pauseSystem;
        [SerializeField] private FinalPanel _finalPanel;
        [SerializeField] private ExitMainMenuPanel _mainMenuPanel;
        [SerializeField] private ExitPanel _exitPanel;

        [Header("Parameters")]
        [SerializeField] private KeyCode _stateKey;
        [SerializeField] private GameObject _pausePanel;

        [Header("Buttons")]
        [SerializeField] private Button _resume;
        [SerializeField] private Button _final;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Button _exit;

        [SerializeField] private UnityEvent _showed;
        [SerializeField] private UnityEvent _hidded;
        #endregion

        #region Fields
        private bool _isActivate = false;
        #endregion

        #region Events
        public event UnityAction Showed
        {
            add => _showed?.AddListener(value);
            remove => _showed?.RemoveListener(value);
        }

        public event UnityAction Hidded
        {
            add => _hidded?.AddListener(value);
            remove => _hidded.RemoveListener(value);
        }
        #endregion

        #region Unity Functions
        private void Awake()
        {
            if (!_pausePanel) throw new NullReferenceException("Pause panel has not be assigned");
        }

        private void OnEnable()
        {
            _resume.onClick.AddListener(Resume);
            _final.onClick.AddListener(CallFinishGamePanel);
            _settings.onClick.AddListener(CallSettings);
            _mainMenu.onClick.AddListener(CallMainMenuPanel);
            _exit.onClick.AddListener(CallExitPanel);
        }

        private void OnDisable()
        {
            _resume.onClick.RemoveListener(Resume);
            _final.onClick.RemoveListener(CallFinishGamePanel);
            _settings.onClick.RemoveListener(CallSettings);
            _mainMenu.onClick.RemoveListener(CallMainMenuPanel);
            _exit.onClick.RemoveListener(CallExitPanel);

            _pauseSystem.Play();
        }

        private void Update()
        {
            if(Input.GetKeyDown(_stateKey))
            {
                SetState(!_pausePanel.activeSelf);
            }
        }
        #endregion

        public void SetState(bool state)
        {
            _pausePanel.SetActive(state);

            if (state)
            {
                _showed?.Invoke();
                _pauseSystem.Pause();
            }
            else
            {
                _hidded?.Invoke();
                _pauseSystem.Play();
            }
        }

        #region Buttons Functions
        private void Resume()
        {
            SetState(false);
        }

        private void CallFinishGamePanel()
        {
            _finalPanel.gameObject.SetActive(true);
        }

        private void CallSettings()
        {
            
        }

        private void CallMainMenuPanel()
        {
            _mainMenuPanel.gameObject.SetActive(true);
        }

        private void CallExitPanel()
        {
            _exitPanel.gameObject.SetActive(true);
        }
        #endregion
    }
}
