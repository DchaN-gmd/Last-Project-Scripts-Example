using AudioSystem;
using TimeSystems;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class MusicFadeController : MonoBehaviour
{
    [SerializeField] private bool _activateOnStart;

    [Header("Controllers")]
    [SerializeField] private Fade _firstFade;
    [SerializeField] private Fade _secondFade;
    [SerializeField] private MusicContainerDanceBattle _musicContainer;

    [Header("Parameters")]
    [SerializeField] private float _secondsForFade;

    private Fade _currentFade;
    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void OnEnable()
    {
        _timer.Stopped += ChangeMusic;
    }

    private void OnDisable()
    {
        _timer.Stopped -= ChangeMusic;
    }

    private void Start()
    {
        if (_activateOnStart) ChangeMusic();
    }

    [ContextMenu("PlayMusic")]
    public void PlayMusic()
    {
        if (_currentFade != null) _currentFade.GetComponent<AudioSource>().Play();
    }

    public void PauseMusic()
    {
        if (_currentFade != null) _currentFade.GetComponent<AudioSource>().Stop();
    }

    private void ChangeMusic()
    {
        if (!_currentFade)
        {
            _currentFade = _secondFade;
        }

        _currentFade.FadeDown(_secondsForFade);
        SwapFade();

        var clip = _musicContainer.GetValue();
        _timer.Play(clip.length - _secondsForFade);

        var audioSource = _currentFade.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        _currentFade.FadeUp(_secondsForFade);
    }

    private void SwapFade()
    {
        if (_currentFade == _firstFade) _currentFade = _secondFade;
        else if (_currentFade == _secondFade) _currentFade = _firstFade;
    }
}
