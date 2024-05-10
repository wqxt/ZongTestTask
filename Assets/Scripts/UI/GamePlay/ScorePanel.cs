public class ScorePanel : AbstractPanel
{
    private void Awake()
    {
        Addpanel("ScorePanel", this);
        HidePanel();
    }

    public override void ShowPanel() => base.ShowPanel();
    public override void HidePanel() => base.HidePanel();
}
