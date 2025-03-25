using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Branch> branches; // Danh sách tất cả các nhánh trong game
    public GameObject winPanel; // UI hiển thị khi thắng

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CheckWinCondition()
    {
        foreach (Branch branch in branches)
        {
            if (!IsBranchValid(branch))
                return; // Nếu có ít nhất 1 nhánh không hợp lệ, chưa thắng
        }
        WinGame();
    }

    private bool IsBranchValid(Branch branch)
    {
        if (branch.monsterOnBranch.Count == 0)
            return true; // Nhánh trống hợp lệ

        // Nếu nhánh chưa đủ số lượng chim tối đa, không hợp lệ
        if (branch.monsterOnBranch.Count < branch.maxMonstersOnBranch)
            return false;

        // Kiểm tra tất cả chim trong nhánh có cùng loại không
        MonsterObjet firstMonster = branch.monsterOnBranch[0];
        foreach (MonsterObjet monster in branch.monsterOnBranch)
        {
            if (monster.type != firstMonster.type)
                return false; // Nhánh có chim khác loại
        }
        return true; // Nhánh hợp lệ nếu đủ chim và cùng loại
    }

    private void WinGame()
    {
        Debug.Log("Chúc mừng! Bạn đã thắng!");
        winPanel.SetActive(true); // Hiển thị UI chiến thắng
    }
    
    public void RestartGame() 
    {
        Debug.Log(" Đang tải lại màn chơi...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
        Debug.Log("Thoát game!");
        Application.Quit(); 
    }
}
