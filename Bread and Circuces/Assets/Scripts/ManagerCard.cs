using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum CardEffect
    {
        Damage,
        Defense,
        Survived,
        Movement,
        CardDrow,
        ResetCard,
        Status,
        ManaAdd,
        Type,
        Mechanics,
        No
    }
    public enum TargetType
    {
        NoTarget,
        This,
        Enemy,
        Ally
    }
    public enum Stance
    {
        Defensive,
        Advance,
        Attacking,
        Raging
    }

    public CardEffect FirstCardEff, FirstCardEffTwo;
    public Stance StartStance, EndStance;
    public TargetType SpellTarget;

    public string Name;
    public Sprite Logo;
    public int Manacost, SpellValue, SecondSpellValue;
    public bool IsPlaced;

    public Card(string name, string logoPath, int manacost, Stance startStance = 0, Stance endStance = 0,
        CardEffect firstCardEffect = 0, int spellValue = 0, CardEffect firstCardEffectTwo = 0, int secondSpellValue = 0,
        TargetType targetType = 0)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Manacost = manacost;
        IsPlaced = false;

        FirstCardEff = firstCardEffect;
        FirstCardEffTwo = firstCardEffectTwo;
        StartStance = startStance;
        EndStance = endStance;

        SpellTarget = targetType;
        SpellValue = spellValue;
        SecondSpellValue = secondSpellValue;

    }

    public Card(Card card)
    {
        Name = card.Name;
        Logo = card.Logo;
        Manacost = card.Manacost;
        IsPlaced = false;

        FirstCardEff = card.FirstCardEff;
        FirstCardEffTwo = card.FirstCardEffTwo;
        StartStance = card.StartStance;
        EndStance = card.EndStance;

        SpellTarget = card.SpellTarget;
        SpellValue = card.SpellValue;
        SecondSpellValue = card.SecondSpellValue;

    }
    
    public Card GetCopy()
    {
        return new Card(this);
    }

}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class ManagerCard : MonoBehaviour
{
    public void Awake()
    {
        //"��������"

        CardManager.AllCards.Add(new Card("������ ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Attacking, Card.CardEffect.Damage, 0, Card.CardEffect.Status, 0, Card.TargetType.Enemy));// ������ �� ������������
        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("����� � ������������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Defensive, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����� � ������������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Defensive, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 4, Card.CardEffect.ResetCard, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 4, Card.CardEffect.ResetCard, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Defensive, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));//������������� ������������
        CardManager.AllCards.Add(new Card("���������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Defensive, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));//������������� ������������
        CardManager.AllCards.Add(new Card("����� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Movement, 1, Card.CardEffect.Damage, 2, Card.TargetType.Enemy));//����� �������� ������������
        CardManager.AllCards.Add(new Card("����� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Movement, 1, Card.CardEffect.Damage, 2, Card.TargetType.Enemy));//����� �������� ������������
        CardManager.AllCards.Add(new Card("����� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Movement, 1, Card.CardEffect.Damage, 2, Card.TargetType.Enemy));//����� �������� ������������
        CardManager.AllCards.Add(new Card("��� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Defensive, Card.CardEffect.Defense, 1, Card.CardEffect.Movement, 1, Card.TargetType.This));//������ �� ������������
        CardManager.AllCards.Add(new Card("��� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Defensive, Card.CardEffect.Defense, 1, Card.CardEffect.Movement, 1, Card.TargetType.This));//������ �� ������������

        //������������� � ���� "�������"

        CardManager.AllCards.Add(new Card("�������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Raging, Card.CardEffect.Damage, 4, Card.CardEffect.Movement, 0, Card.TargetType.Enemy));//������ �� ������������
        CardManager.AllCards.Add(new Card("�������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Raging, Card.CardEffect.Damage, 4, Card.CardEffect.Movement, 0, Card.TargetType.Enemy));//������ �� ������������
        CardManager.AllCards.Add(new Card("�������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Raging, Card.CardEffect.Damage, 4, Card.CardEffect.Movement, 0, Card.TargetType.Enemy));//������ �� ������������
        CardManager.AllCards.Add(new Card("��������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("��������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("��������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("Rip and tear", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Raging, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.ResetCard, 2, Card.TargetType.Enemy));//������ �� ������������
        CardManager.AllCards.Add(new Card("�������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Raging, Card.Stance.Raging, Card.CardEffect.Damage, 2, Card.CardEffect.ManaAdd, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("�������� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Raging, Card.CardEffect.Defense, 0, Card.CardEffect.CardDrow, 2, Card.TargetType.This));// + ��������
        CardManager.AllCards.Add(new Card("�������� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Raging, Card.CardEffect.Defense, 0, Card.CardEffect.CardDrow, 2, Card.TargetType.This));// + ��������
        CardManager.AllCards.Add(new Card("����������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Advance, Card.CardEffect.Damage, 4, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Advance, Card.CardEffect.Damage, 4, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���� �������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.No, 0, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���� �������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.No, 0, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���� �������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.No, 0, Card.TargetType.Enemy));


        //������������� � ���� "���������"

        CardManager.AllCards.Add(new Card("��������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Attacking, Card.CardEffect.Damage, 0, Card.CardEffect.ResetCard, 2, Card.TargetType.Enemy));//+��������
        CardManager.AllCards.Add(new Card("��������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Attacking, Card.CardEffect.Damage, 0, Card.CardEffect.ResetCard, 2, Card.TargetType.Enemy));//+��������
        CardManager.AllCards.Add(new Card("����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Defensive, Card.CardEffect.Defense, 2, Card.CardEffect.Type, 1, Card.TargetType.This));//������ � ������ ����
        CardManager.AllCards.Add(new Card("����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Defensive, Card.CardEffect.Defense, 2, Card.CardEffect.Type, 1, Card.TargetType.This));//������ � ������ ����
        CardManager.AllCards.Add(new Card("����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Defensive, Card.CardEffect.Defense, 2, Card.CardEffect.Type, 1, Card.TargetType.This));//������ � ������ ����
        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("����������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Advance, Card.CardEffect.Damage, 2, Card.CardEffect.Mechanics, 1, Card.TargetType.Enemy));//������ �� ������������ �����
        CardManager.AllCards.Add(new Card("����������� �����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Advance, Card.CardEffect.Damage, 2, Card.CardEffect.Mechanics, 1, Card.TargetType.Enemy));//������ �� ������������ �����
        CardManager.AllCards.Add(new Card("���� �������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.No, 0, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���� �������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.No, 0, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Defensive, Card.CardEffect.Defense, 1, Card.CardEffect.CardDrow, 1, Card.TargetType.This));// ������ �� ������������ �����
        CardManager.AllCards.Add(new Card("����������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Defensive, Card.CardEffect.Defense, 1, Card.CardEffect.CardDrow, 1, Card.TargetType.This));// ������ �� ������������ �����
        CardManager.AllCards.Add(new Card("��������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("��������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));


        //������������� � ���� "��������"

        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Advance, Card.CardEffect.Defense, 3, Card.CardEffect.Movement, 1, Card.TargetType.This));
        CardManager.AllCards.Add(new Card("����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Defensive, Card.CardEffect.Defense, 2, Card.CardEffect.Type, 1, Card.TargetType.This));//������ � ������ ����
        CardManager.AllCards.Add(new Card("����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Defensive, Card.CardEffect.Defense, 2, Card.CardEffect.Type, 1, Card.TargetType.This));//������ � ������ ����
        CardManager.AllCards.Add(new Card("���� ��-�� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("���� ��-�� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Defensive, Card.Stance.Attacking, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����� ������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Attacking, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));
        CardManager.AllCards.Add(new Card("����������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Defensive, Card.CardEffect.Defense, 1, Card.CardEffect.CardDrow, 1, Card.TargetType.This));// ������ �� ������������ �����
        CardManager.AllCards.Add(new Card("����������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Advance, Card.Stance.Defensive, Card.CardEffect.Defense, 1, Card.CardEffect.CardDrow, 1, Card.TargetType.This));// ������ �� ������������ �����
        CardManager.AllCards.Add(new Card("����� � ������������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Defensive, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));// ������ � �������������
        CardManager.AllCards.Add(new Card("����� � ������������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Defensive, Card.CardEffect.Damage, 2, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));// ������ � �������������
        CardManager.AllCards.Add(new Card("���������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Advance, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));//������ �� ������������ �����
        CardManager.AllCards.Add(new Card("���������� ����", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Advance, Card.CardEffect.Damage, 3, Card.CardEffect.CardDrow, 1, Card.TargetType.Enemy));//������ �� ������������ �����
        CardManager.AllCards.Add(new Card("�������������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 4, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));//������������
        CardManager.AllCards.Add(new Card("�������������", "Sprites/LogoCards/CHto-to", 1, Card.Stance.Attacking, Card.Stance.Attacking, Card.CardEffect.Damage, 4, Card.CardEffect.Movement, 1, Card.TargetType.Enemy));//������������

    }
}
