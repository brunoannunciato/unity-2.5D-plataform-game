using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField] Text _coinBoard, _livesText;
    // Start is called before the first frame update
    void Start()
    {
        _coinBoard.text = "Coins: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdtadeCoinBoard(int newValue)
    {
        _coinBoard.text = $"Coins: {newValue}";
    }

    public void UpdaterLivesText(int newValue)
    {
        _livesText.text = $"Lives: {newValue}";
    }
}
