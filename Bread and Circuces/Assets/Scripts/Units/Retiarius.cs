using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retiarius : UnitInfo
{
    protected override void Start()
    {
        damage = 3;

        health = 15;
        defence = 0;
        attackReachDistance = 2;
        moveDistance = 3;
        withShield = false;

        base.Start();

        UnitDeck.Add(new SpellCard("������ ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Attacking, SpellCard.FirstCardEffect.Damage, 0, SpellCard.SecondCardEffect.Status, 0, SpellCard.TargetType.Enemy));// ������ �� ������������
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Defensive, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Defensive, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Attacking, SpellCard.FirstCardEffect.Damage, 4, SpellCard.SecondCardEffect.ResetCard, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Attacking, SpellCard.FirstCardEffect.Damage, 4, SpellCard.SecondCardEffect.ResetCard, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Defensive, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));//������������� ������������
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Defensive, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));//������������� ������������
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));//����� �������� ������������
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));//����� �������� ������������
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.Enemy));//����� �������� ������������
        UnitDeck.Add(new SpellCard("��� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Defensive, SpellCard.FirstCardEffect.Defense, 1, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));//������ �� ������������
        UnitDeck.Add(new SpellCard("��� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Defensive, SpellCard.FirstCardEffect.Defense, 1, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));//������ �� ������������
    }

    public override void OnAttackEnd(UnitInfo target)
    {
        base.OnAttackEnd(target);
    }

    public override void OnAttackStart(UnitInfo target)
    {

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
        if (motionType == MotionType.StraightType)
            ; // Draw Card
    }
}
