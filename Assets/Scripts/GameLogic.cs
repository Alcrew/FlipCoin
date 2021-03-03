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
    [SerializeField] Button _starButton;
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
        _starButton.onClick.AddListener(OnClickStar);
        _closeButton.onClick.AddListener(OnClickCloseHistory);
    }

    void Update()
    {
        _score.text = "" + scoreValue;
    }

    int randomGenerator()
    {
        var random = UnityEngine.Random.Range(0, 2);
        return random;
    }

    void showCoin(int coinValue)
    {
        print(coinValue);
        switch (coinValue)
        {
            case 0:
                _coinTail.SetActive(true);
                _coinHead.SetActive(false);
                //Assets.HistoryHandler.AddHistory();
                break;
            case 1:
                _coinTail.SetActive(false);
                _coinHead.SetActive(true);
                break;
        }
        
    }

    public void checkTailOrHead(int coinValue, int random)
    {
        //var value = randomGenerator();
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
        //print(value);
        showCoin(random);
        _historyHandler.AddHistory(new ItemScript.ItemData { random = random, coinValue = coinValue });
    }

    public void checkValueTail()
    {
        checkTailOrHead(0, randomGenerator());
    }

    public void checkValueHead()
    {
        checkTailOrHead(1, randomGenerator());
    }

    void OnClickHeadButton()
    {
        checkValueHead();
    }
    void OnClickTailButton()
    {
        checkValueTail();
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