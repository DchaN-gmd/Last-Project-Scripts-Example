using UnityEngine;

public class SprctrumEmission : MonoBehaviour
{
    private readonly int Emission = Shader.PropertyToID("_EmissivePower");

    [SerializeField] private Material _material;
    [SerializeField] private float _emissionSizeUp;
    [SerializeField] private float _defaultEmission;
    [SerializeField] private float _audioSensibility = 0.15f;
    [SerializeField] private int _audioChannel = 4;
    [SerializeField] private float _lerpTime = 5.0f;

    private float _emission;

    private void Awake()
    {
        _material.SetFloat(Emission, _defaultEmission);
    }

    private void Update()
    {
        if (SpectrumKernel.spects[_audioChannel] * SpectrumKernel.threshold >= _audioSensibility)
        {
            _material.SetFloat(Emission, _emissionSizeUp);
        }
        else
        {
            _emission = Mathf.Lerp(_emissionSizeUp, _defaultEmission, _lerpTime);

            _material.SetFloat(Emission, _emission);
        }
    }
}
