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

        UnitDeck.Add(new SpellCard("������ ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive, SpellCard.Stance.Attacking, SpellCard.CardEffect.Damage, 0, SpellCard.CardEffect.Status, 0, SpellCard.TargetType.Enemy));// ������ �� ������������
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive, SpellCard.Stance.Advance, SpellCard.CardEffect.Defense, 3, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive, SpellCard.Stance.Advance, SpellCard.CardEffect.Defense, 3, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive, SpellCard.Stance.Advance, SpellCard.CardEffect.Defense, 3, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive, SpellCard.Stance.Advance, SpellCard.CardEffect.Defense, 3, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking, SpellCard.Stance.Defensive, SpellCard.CardEffect.Damage, 2, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����� � ������������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking, SpellCard.Stance.Defensive, SpellCard.CardEffect.Damage, 2, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking, SpellCard.Stance.Attacking, SpellCard.CardEffect.Damage, 4, SpellCard.CardEffect.ResetCard, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking, SpellCard.Stance.Attacking, SpellCard.CardEffect.Damage, 4, SpellCard.CardEffect.ResetCard, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking, SpellCard.Stance.Defensive, SpellCard.CardEffect.Damage, 3, SpellCard.CardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));//������������� ������������
        UnitDeck.Add(new SpellCard("���������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking, SpellCard.Stance.Defensive, SpellCard.CardEffect.Damage, 3, SpellCard.CardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));//������������� ������������
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance, SpellCard.Stance.Attacking, SpellCard.CardEffect.Movement, 1, SpellCard.CardEffect.Damage, 2, SpellCard.TargetType.Enemy));//����� �������� ������������
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance, SpellCard.Stance.Attacking, SpellCard.CardEffect.Movement, 1, SpellCard.CardEffect.Damage, 2, SpellCard.TargetType.Enemy));//����� �������� ������������
        UnitDeck.Add(new SpellCard("����� ������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance, SpellCard.Stance.Attacking, SpellCard.CardEffect.Movement, 1, SpellCard.CardEffect.Damage, 2, SpellCard.TargetType.Enemy));//����� �������� ������������
        UnitDeck.Add(new SpellCard("��� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance, SpellCard.Stance.Defensive, SpellCard.CardEffect.Defense, 1, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.This));//������ �� ������������
        UnitDeck.Add(new SpellCard("��� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance, SpellCard.Stance.Defensive, SpellCard.CardEffect.Defense, 1, SpellCard.CardEffect.Movement, 1, SpellCard.TargetType.This));//������ �� ������������
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
