using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyMenu : MonoBehaviour
{
    [SerializeField] private Button _easyButton;
    [SerializeField] private Button _normalButton;
    [SerializeField] private Button _hardButton;

    [SerializeField] private Button _backButton;

    public event Action OnEasy;
    public event Action OnNormal;
    public event Action OnHard;

    private void Awake()
    {
        _easyButton.onClick.AddListener(() => OnEasy?.Invoke());
        _normalButton.onClick.AddListener(() => OnNormal?.Invoke());
        _hardButton.onClick.AddListener(() => OnHard?.Invoke());

        _backButton.onClick.AddListener(Hide);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        OnEasy = null;
        OnNormal = null;
        OnHard = null;
        gameObject.SetActive(false);
    }
}
