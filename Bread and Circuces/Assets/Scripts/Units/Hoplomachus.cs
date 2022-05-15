using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoplomachus : UnitInfo
{
    private DistanceFinder distanceFinder;
    protected override void Start()
    
    {
        damage = 3;

        health = 15;
        defence = 0;
        attackReachDistance = 2;
        moveDistance = 3;
        withShield = true;

        distanceFinder = FindObjectOfType<DistanceFinder>();

        base.Start();

        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Defensive, SpellCard.FirstCardEffect.Defense, 2, SpellCard.SecondCardEffect.Type, 1, SpellCard.TargetType.This));//������ � ������ ����
        UnitDeck.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Defensive, SpellCard.FirstCardEffect.Defense, 2, SpellCard.SecondCardEffect.Type, 1, SpellCard.TargetType.This));//������ � ������ ����
        UnitDeck.Add(new SpellCard("���� ��-�� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Attacking, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���� ��-�� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Attacking, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Defensive, SpellCard.FirstCardEffect.Defense, 1, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.This));// ������ �� ������������ �����
        UnitDeck.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Defensive, SpellCard.FirstCardEffect.Defense, 1, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.This));// ������ �� ������������ �����
        UnitDeck.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Defensive, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));// ������ � �������������
        UnitDeck.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Defensive, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));// ������ � �������������
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Advance, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));//������ �� ������������ �����
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Advance, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));//������ �� ������������ �����
        UnitDeck.Add(new SpellCard("�������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Attacking, SpellCard.FirstCardEffect.Damage, 4, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));//������������
        UnitDeck.Add(new SpellCard("�������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Attacking, SpellCard.FirstCardEffect.Damage, 4, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));//������������
    }

    public override void OnAttackEnd(UnitInfo target)
    {
        base.OnAttackEnd(target);
    }

    public override void OnAttackStart(UnitInfo target)
    {
        var occupiedHex = transform.parent.GetComponent<HexTile>();
        var targetHex = target.transform.parent.GetComponent<HexTile>();
        var distance = distanceFinder.GetDistanceBetweenHexes(occupiedHex, targetHex);
        if (distance == 1 && currentStance == Stance.Attacking)
            damage += 1;
    }

    public override void OnDefenceStart()
    {

    }

    public override void OnDefenceEnd()
    {
        base.OnDefenceEnd();
    }

    public override void OnMove()
    {

    }
}
