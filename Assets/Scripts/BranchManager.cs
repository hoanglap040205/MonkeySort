using UnityEngine;
using System.Collections.Generic;

public class BranchManager : MonoBehaviour
{
    public List<GameObject> branches; // Danh sách 3 nhánh cây
    public float topPadding = 1.5f; // Khoảng cách từ trên xuống

    void Start()
    {
        ArrangeBranches();
    }

    void ArrangeBranches()
    {
        if (branches.Count != 3)
        {
            Debug.LogError("Số lượng nhánh phải là 3!");
            return;
        }

        float screenHeight = Camera.main.orthographicSize * 2;
        float spacing = screenHeight * 0.3f; // Khoảng cách giữa các nhánh

        // Lấy vị trí mép trái màn hình
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        float xPos = leftEdge.x; // Dịch một chút để không bị cắt

        // Xác định vị trí của nhánh đầu tiên (trên cùng)
        float startY = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)).y - topPadding;

        for (int i = 0; i < branches.Count; i++)
        {
            float yPos = startY - (i * spacing); // Xếp từ trên xuống
            branches[i].transform.position = new Vector3(xPos, yPos, 0);
        }
    }
}
