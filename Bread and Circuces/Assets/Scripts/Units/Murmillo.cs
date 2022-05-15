using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murmillo : UnitInfo
{
    protected override void Start()
    {
        damage = 3;

        health = 15;
        defence = 0;
        attackReachDistance = 1;
        moveDistance = 3;
        withShield = true;

        base.Start();

        UnitDeck.Add(new SpellCard("��������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Attacking, SpellCard.FirstCardEffect.Damage, 0, SpellCard.SecondCardEffect.ResetCard, 2, SpellCard.TargetType.Enemy));//+��������
        UnitDeck.Add(new SpellCard("��������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Attacking, SpellCard.FirstCardEffect.Damage, 0, SpellCard.SecondCardEffect.ResetCard, 2, SpellCard.TargetType.Enemy));//+��������
        UnitDeck.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Defensive, SpellCard.FirstCardEffect.Defense, 2, SpellCard.SecondCardEffect.Type, 1, SpellCard.TargetType.This));//������ � ������ ����
        UnitDeck.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Defensive, SpellCard.FirstCardEffect.Defense, 2, SpellCard.SecondCardEffect.Type, 1, SpellCard.TargetType.This));//������ � ������ ����
        UnitDeck.Add(new SpellCard("����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Defensive, SpellCard.FirstCardEffect.Defense, 2, SpellCard.SecondCardEffect.Type, 1, SpellCard.TargetType.This));//������ � ������ ����
        UnitDeck.Add(new SpellCard("������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Defensive_Advance, SpellCard.FirstCardEffect.Defense, 3, SpellCard.SecondCardEffect.Movement, 1, SpellCard.TargetType.This));
        UnitDeck.Add(new SpellCard("����������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Advance, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Mechanics, 1, SpellCard.TargetType.Enemy));//������ �� ������������ �����
        UnitDeck.Add(new SpellCard("����������� �����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Advance, SpellCard.FirstCardEffect.Damage, 2, SpellCard.SecondCardEffect.Mechanics, 1, SpellCard.TargetType.Enemy));//������ �� ������������ �����
        UnitDeck.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Attacking, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.No, 0, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("���� �������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Attacking_Attacking, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.No, 0, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Defensive, SpellCard.FirstCardEffect.Defense, 1, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.This));// ������ �� ������������ �����
        UnitDeck.Add(new SpellCard("����������", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Defensive, SpellCard.FirstCardEffect.Defense, 1, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.This));// ������ �� ������������ �����
        UnitDeck.Add(new SpellCard("��������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));
        UnitDeck.Add(new SpellCard("��������� ����", "Sprites/LogoCards/CHto-to", 1, SpellCard.Stance.Advance_Attacking, SpellCard.FirstCardEffect.Damage, 3, SpellCard.SecondCardEffect.CardDrow, 1, SpellCard.TargetType.Enemy));
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
        defence++;
    }

    public override void OnDefenceEnd()
    {
        base.OnDefenceEnd();
    }

    public override void OnMove()
    {

    }
}
