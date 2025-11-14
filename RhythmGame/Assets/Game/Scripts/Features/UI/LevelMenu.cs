using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Binding[] _bindings;
    [SerializeField] private DifficultyMenu difficaltyMenu;

    [Inject] private SongManager _songManager;

    private void Awake()
    {
        foreach (var binding in _bindings)
        {
            binding.button.onClick.AddListener(() =>
            {
                difficaltyMenu.Show();
                difficaltyMenu.OnEasy += () => {
                    _songManager.CurrentSong = binding.easySong;
                    SceneManager.LoadScene("Game");
                };
                difficaltyMenu.OnNormal += () => {
                    _songManager.CurrentSong = binding.normalSong;
                    SceneManager.LoadScene("Game");
                };
                difficaltyMenu.OnHard += () => {
                    _songManager.CurrentSong = binding.hardSong;
                    SceneManager.LoadScene("Game");
                };
            });
        }
    }

    [System.Serializable]
    public class Binding
    {
        public Button button;
        public SongInfo easySong;
        public SongInfo normalSong;
        public SongInfo hardSong;
    }
}
