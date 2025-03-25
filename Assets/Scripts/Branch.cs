using UnityEngine;
using System.Collections.Generic;
using UnityEngine.VFX;

public class Branch : MonoBehaviour
{
    public List<MonsterObjet> monsterOnBranch = new List<MonsterObjet>();
   // public Transform topPosition;
    public int maxMonstersOnBranch;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color selectedColor = new Color(1f, 0.8f, 0.5f);

    private void Start()
    {
        maxMonstersOnBranch = 3;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null) originalColor = spriteRenderer.color;
        Spawn();
        
    }

    public void RemoveMonster(MonsterObjet monsterObjet)
    {
        monsterOnBranch.Remove(monsterObjet);
    }

    public void AddMonster(MonsterObjet monsterObjet)
    {
        if (monsterOnBranch.Count < maxMonstersOnBranch)
        {
            monsterOnBranch.Add(monsterObjet);
            
        }
    }

    
    //Goi khi ham chac chan khong rong
    public List<MonsterObjet> GetSameTopMonster()
    {
        List<MonsterObjet> sameTopMonster = new List<MonsterObjet>();
        if (monsterOnBranch.Count == 1)
        {
            sameTopMonster.Add(monsterOnBranch[0]);
           // Debug.Log("Same monster: "+sameTopMonster.Count);
            return sameTopMonster;
        } // Nếu chỉ có 1 quái vật, trả về ngay
        
            
        MonsterObjet topMonster = monsterOnBranch[monsterOnBranch.Count - 1];
        sameTopMonster.Add(topMonster);
        for (int i = monsterOnBranch.Count - 2; i >= 0; i--)
        {
            if (topMonster.type == monsterOnBranch[i].type)
            {
                sameTopMonster.Add(monsterOnBranch[i]);
            }
            else
            {
                break;
            }
        }
       // Debug.Log("Same monster: "+sameTopMonster.Count);
        return sameTopMonster;
    }
    //Kiem tra so luong quai o trong nhanh co nho hon so luong toi da khong
    public int HasSpace()
    {
     //   Debug.Log("Không gian còn lại: " + maxMonstersOnBranch +"-" +monsterOnBranch.Count);
        return maxMonstersOnBranch - monsterOnBranch.Count;
    }

    public Vector3 GetPosition()
    {
        return transform.position + new Vector3(monsterOnBranch.Count * 0.75f,0 , 0);
    }
    public void SelectBranch()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = selectedColor;
        }
        //Debug.Log("Chọn nhánh: " + transform.name + "Nhánh có: " +  monsterOnBranch.Count);
    }

    public void DeselectBranch()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
        //Debug.Log("Bỏ chọn nhánh: " + transform.name);
    }
    

    private void Spawn()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            MonsterObjet monster = child.GetComponent<MonsterObjet>();
            if (monster != null)
            {
                Vector3 targetPos = transform.position + new Vector3(index * 0.75f,0, 0); // Sắp xếp theo chiều dọc
                monster.transform.position = targetPos;
                monsterOnBranch.Add(monster);
                index++;
            }
        }
    }
    
}