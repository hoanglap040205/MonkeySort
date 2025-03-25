using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    void Start()
    {
        FitBackground();
    }

    void FitBackground()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("Không tìm thấy SpriteRenderer trên GameObject này!");
            return;
        }

        // Lấy kích thước camera
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * Screen.width / Screen.height;

        // Lấy kích thước sprite gốc
        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

        // Điều chỉnh scale để vừa với màn hình
        transform.localScale = new Vector3(screenWidth / spriteWidth, screenHeight / spriteHeight, 1);
    }
}

