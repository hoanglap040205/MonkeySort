using System;
using UnityEngine;
using UnityEngine.EventSystems;



public class MonsterObjet : MonoBehaviour
{

    public MonsterType type;

    public event Action movedTobranch;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private static readonly Color SelectedColor = new Color(0.8f, 1f, 0.5f); // Màu khi được chọn


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Lưu màu ban đầu
        }
    }

    public void SelectMonster()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = SelectedColor;
        }
    }

    public void DeselectMonster()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
}