using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject _coinHead;
    [SerializeField] GameObject _coinTail;
    [SerializeField] TextMeshProUGUI _resultText;
    [SerializeField] TMP_Text _score;
    [SerializeField] GameObject _historyPanel;
    [SerializeField] GameObject _gamePanel;
    [SerializeField] Button _headButton;
    [SerializeField] Button _tailButton;
    [SerializeField] Button _historyButton;
    [SerializeField] Button _closeButton;
    [SerializeField] HistoryHandler _historyHandler;
    public static int scoreValue = 0;

    void Start()
    {
        _coinHead.SetActive(false);
        _coinTail.SetActive(false);
        _historyPanel.SetActive(false);
        _tailButton.onClick.AddListener(OnClickTailButton);
        _headButton.onClick.AddListener(OnClickHeadButton);
        _historyButton.onClick.AddListener(OnClickStar);
        _closeButton.onClick.AddListener(OnClickCloseHistory);
    }

    void Update()
    {
        _score.text = "" + scoreValue;
    }

    int RandomGenerator()
    {
        var random = UnityEngine.Random.Range(0, 2);
        return random;
    }

    void ShowCoin(int coinValue)
    {
        switch (coinValue)
        {
            case 0:
                _coinTail.SetActive(true);
                _coinHead.SetActive(false);
                break;
            case 1:
                _coinTail.SetActive(false);
                _coinHead.SetActive(true);
                break;
        }
        
    }

    public void CheckTailOrHead(int coinValue, int random)
    {
        if (coinValue == random)
        {
            _resultText.SetText("100 points to Griffindor!");
            scoreValue += 100;
        }
        else
        {
            _resultText.SetText("-100 points to Griffindor");
            scoreValue -= 100;
        }
        ShowCoin(random);
        _historyHandler.AddHistory(new ItemScript.ItemData { random = random, coinValue = coinValue });
    }

    public void CheckValueTail()
    {
        CheckTailOrHead(0, RandomGenerator());
    }

    public void CheckValueHead()
    {
        CheckTailOrHead(1, RandomGenerator());
    }

    void OnClickHeadButton()
    {
        CheckValueHead();
    }
    void OnClickTailButton()
    {
        CheckValueTail();
    }

    public void OnClickStar()
    {
        _gamePanel.SetActive(false);
        _historyPanel.SetActive(true);
        _historyHandler.Show();
    }

    public void OnClickCloseHistory()
    {
        _gamePanel.SetActive(true);
        _historyPanel.SetActive(false);
    }
}