using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public void MakeTurn()
    {
        StartCoroutine(EnemyTurn(GameManagerScript.Instance.EnemyHandCards));//���� ����������
    }
    IEnumerator EnemyTurn(List<CardController> cards)
    {
        for (int count = GameManagerScript.Instance.CurrentGame.Enemy.Mana; count > 0; count--)
        {
            if (GameManagerScript.Instance.EnemyHandCards.Count == 0)
                break;

        }
        yield return new WaitForSeconds(.5f);
    }

    void CastSpell(CardController card)
    {
    }
}

