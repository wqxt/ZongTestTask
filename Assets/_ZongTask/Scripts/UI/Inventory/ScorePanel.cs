using TMPro;
using UnityEngine;

public class ScorePanel : AbstractPanel
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Inventory _inventory;
    private int _scoreValue = 0;


    private void OnEnable()
    {
        _inventory.ItemAdded += UpdateScore;
    }

    private void OnDestroy()
    {
        _inventory.ItemAdded -= UpdateScore;
    }

    private void Awake()
    {
        Addpanel("ScorePanel", this);
        HidePanel();
    }

    private void UpdateScore()
    {
        _scoreValue++;
        _scoreText.text = _scoreValue.ToString();
    }

    public override void ShowPanel() => base.ShowPanel();

    public override void HidePanel() => base.HidePanel();
}
