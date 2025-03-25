using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public RectTransform winPanel;
    public RectTransform restartButton;
    public RectTransform quitButton;

    void Start()
    {
        float panelWidth = winPanel.sizeDelta.x;
        float panelHeight = winPanel.sizeDelta.y;


        // Kích thước của nút (60% chiều rộng panel, 15% chiều cao panel)
        Vector2 buttonSize = new Vector2(panelWidth * 0.6f, panelHeight * 0.15f);

        restartButton.sizeDelta = buttonSize;
        quitButton.sizeDelta = buttonSize;

        // Vị trí nút
        float spacing = panelHeight * 0.05f; // Khoảng cách giữa các nút
        restartButton.anchoredPosition = new Vector2(0, -panelHeight * 0.15f);
        quitButton.anchoredPosition = new Vector2(0, -panelHeight * 0.3f);
    }
}
