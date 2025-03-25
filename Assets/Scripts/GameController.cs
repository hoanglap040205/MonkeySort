using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    [CanBeNull] private Branch branchSelected = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main == null) return;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider == null) return;

            if (hit.collider.CompareTag("Object"))
            {
                Branch branch = hit.collider.GetComponent<Branch>();
                if (branch == null) return;

                if (branchSelected == null)
                {
                    if (branch.monsterOnBranch.Count == 0) return;
                    branchSelected = branch;
                    branchSelected.SelectBranch();
                }
                else
                {
                    if (branchSelected == branch)
                    {
                        branchSelected.DeselectBranch();
                        return;
                    }

                    MoveToBranch(branchSelected, branch);
                    branchSelected.DeselectBranch();
                    branchSelected = null;
                }
            }
        }
    }

    

    private void MoveToBranch(Branch fromBranch, Branch toBranch)
    {
     
        List<MonsterObjet> sameTopMonster = fromBranch.GetSameTopMonster();
        foreach (var monster in sameTopMonster)
        {
            if (toBranch.HasSpace() > 0)
            {
                if (toBranch.monsterOnBranch.Count == 0 || monster.type == toBranch.monsterOnBranch[toBranch.monsterOnBranch.Count - 1].type)
                {
                    fromBranch.RemoveMonster(monster);
                    Vector3 targetPos = toBranch.GetPosition();
                    toBranch.AddMonster(monster);
                    StartCoroutine(MoveMonster(monster, targetPos));
                }
                else
                {
                    return;
                }
            }
        }

        StartCoroutine(CheckWinCondition());
        // Debug.Log($"Quái vật đã di chuyển từ {fromBranch.name} tới {toBranch.name}");




    }


    IEnumerator MoveMonster(MonsterObjet monsterObjet, Vector3 target)
    {
        yield return new WaitForSeconds(0.3f);
        monsterObjet.transform.DOMove(target, 1).SetEase(Ease.OutQuad);

    }

    IEnumerator CheckWinCondition()
    {
        yield return new WaitForSeconds(3f);
        GameManager.Instance.CheckWinCondition();
        Time.timeScale = 1;
    }
    
        


}
