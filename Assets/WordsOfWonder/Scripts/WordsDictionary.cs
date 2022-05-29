using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class WordsDictionary : MonoBehaviour
{
    [SerializeField] private Word[] _words;
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private Score _score;

    private string[] _wordsValue;
    private List<string> _guessedWords;

    public System.Action GameOver;

    public Word[] Words => _words;

    private void Start()
    {
        _wordsValue = _words.Select((w) => w.Value).ToArray();
        _guessedWords = new List<string>();
    }

    public void ShowTip()
    {
        var notGuessedWords = _words.Where((w) 
            => _guessedWords.Contains(w.Value) == false);

        throw new System.NotImplementedException("�������� ���������� �����");
        if (notGuessedWords.Any() == false)
        {
            _message.color = Color.red;
            _message.text = "��� ����� ��� ��������";
            return;
        }

        Word word = notGuessedWords.OrderBy((x) => Random.value).First();
        _score.UsedTip();
    }

    public void TryGuess(string word)
    {
        if (_wordsValue.Contains(word) == false)
        {
            _message.color = Color.red;
            _message.text = "��� ������ �����";
            return;
        }
        if (_guessedWords.Contains(word))
        {
            _message.color = Color.red;
            _message.text = "�� ��� �������� ��� �����";
            return;
        }

        _guessedWords.Add(word);
        int index = System.Array.IndexOf(_wordsValue, word);
        _words[index].OpenWord();
        _message.text = string.Empty;
        _score.Guess();

        if (_words.Length == _guessedWords.Count)
        {
            GameOver?.Invoke();

            int score = _score.TotalScore;
            int time = _score.ElapsedTime;
            GameOverParams.Set(score, time);
            SceneLoader.LoadGameOverScene();
        }
    }

    public void ResetDictionary()
    {
        _guessedWords.Clear();
        for (int i = 0; i < _words.Length; i++)
        {
            _words[i].CloseWord();
        }
    }
}
