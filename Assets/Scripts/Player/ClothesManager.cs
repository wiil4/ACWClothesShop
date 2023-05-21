using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    [Header("Sprites Positions")]
    [SerializeField] SpriteRenderer[] _bodyPartsUp;
    [SerializeField] SpriteRenderer[] _bodyPartsDown;
    [SerializeField] SpriteRenderer[] _bodyPartsLeft;
    [SerializeField] SpriteRenderer[] _bodyPartsRight;

    [Header("Clothes Data")]
    [SerializeField] ClothesData _clothesLeatherData;
    [SerializeField] ClothesData _clothesSpecialData;

    private void Update()
    {
        
    }

    public void SetClothes(BodyPart bodyIdentifier, ItemClass itemType)
    {
        Dictionary<(BodyPart, ItemClass), Action> clothesMap = new Dictionary<(BodyPart, ItemClass), Action>()
        {
             { (BodyPart.Head, ItemClass.Leather), SetLeatherHead },
            { (BodyPart.Head, ItemClass.Special), SetSpecialHead },
            { (BodyPart.Body, ItemClass.Leather), SetLeatherBody },
            { (BodyPart.Body, ItemClass.Special), SetSpecialBody },
            { (BodyPart.Boots, ItemClass.Leather), SetLeatherBoots },
            { (BodyPart.Boots, ItemClass.Special), SetSpecialBoots }
        };

        if (clothesMap.TryGetValue((bodyIdentifier, itemType), out Action setClothesAction))
        {
            setClothesAction.Invoke();
        }
        else
        {
            // Handle unknown combination
        }
    }

    private void SetSpecialBoots()
    {
        _bodyPartsUp[2].sprite = _clothesSpecialData.GetLeftBoots()[0];
        _bodyPartsUp[3].sprite = _clothesSpecialData.GetRightBoots()[0];

        _bodyPartsDown[2].sprite = _clothesSpecialData.GetLeftBoots()[1];
        _bodyPartsDown[3].sprite = _clothesSpecialData.GetRightBoots()[1];

        _bodyPartsLeft[2].sprite = _clothesSpecialData.GetLeftBoots()[2];
        _bodyPartsLeft[3].sprite = _clothesSpecialData.GetRightBoots()[2];

        _bodyPartsRight[2].sprite = _clothesSpecialData.GetLeftBoots()[3];
        _bodyPartsRight[3].sprite = _clothesSpecialData.GetRightBoots()[3];
    }

    private void SetLeatherBoots()
    {      
        _bodyPartsUp[2].sprite = _clothesLeatherData.GetLeftBoots()[0];
        _bodyPartsUp[3].sprite = _clothesLeatherData.GetRightBoots()[0];

        _bodyPartsDown[2].sprite = _clothesLeatherData.GetLeftBoots()[1];
        _bodyPartsDown[3].sprite = _clothesLeatherData.GetRightBoots()[1];

        _bodyPartsLeft[2].sprite = _clothesLeatherData.GetLeftBoots()[2];
        _bodyPartsLeft[3].sprite = _clothesLeatherData.GetRightBoots()[2];

        _bodyPartsRight[2].sprite = _clothesLeatherData.GetLeftBoots()[3];
        _bodyPartsRight[3].sprite = _clothesLeatherData.GetRightBoots()[3];
    }

    private void SetSpecialBody()
    {
        _bodyPartsUp[1].sprite = _clothesSpecialData.GetBody()[0];
        _bodyPartsDown[1].sprite = _clothesSpecialData.GetBody()[1];
        _bodyPartsLeft[1].sprite = _clothesSpecialData.GetBody()[2];
        _bodyPartsRight[1].sprite = _clothesSpecialData.GetBody()[3];
    }

    private void SetLeatherBody()
    {
        _bodyPartsUp[1].sprite = _clothesLeatherData.GetBody()[0];
        _bodyPartsDown[1].sprite = _clothesLeatherData.GetBody()[1];
        _bodyPartsLeft[1].sprite = _clothesLeatherData.GetBody()[2];
        _bodyPartsRight[1].sprite = _clothesLeatherData.GetBody()[3];
    }

    private void SetSpecialHead()
    {
        _bodyPartsUp[0].sprite = _clothesSpecialData.GetHat()[0];
        _bodyPartsDown[0].sprite = _clothesSpecialData.GetHat()[1];
        _bodyPartsLeft[0].sprite = _clothesSpecialData.GetHat()[2];
        _bodyPartsRight[0].sprite = _clothesSpecialData.GetHat()[3];
    }

    private void SetLeatherHead()
    {
        _bodyPartsUp[0].sprite = _clothesLeatherData.GetHat()[0];
        _bodyPartsDown[0].sprite = _clothesLeatherData.GetHat()[1];
        _bodyPartsLeft[0].sprite = _clothesLeatherData.GetHat()[2];
        _bodyPartsRight[0].sprite = _clothesLeatherData.GetHat()[3];
    }
}
