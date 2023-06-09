using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Clothes Data", menuName ="Clothes Data/New Clothes Data")]
public class ClothesData : ScriptableObject
{
    [SerializeField] ClothesPosition _clothesUp;
    [SerializeField] ClothesPosition _clothesDown;
    [SerializeField] ClothesPosition _clothesLeft;
    [SerializeField] ClothesPosition _clothesRight;

    public List<Sprite> GetBody()
    {
        return new List<Sprite> { _clothesUp.Body,
            _clothesDown.Body,
            _clothesLeft.Body,
            _clothesRight.Body
        };        
    }
    public List<Sprite> GetHat()
    {
        return new List<Sprite> { _clothesUp.Hat,
            _clothesDown.Hat,
            _clothesLeft.Hat,
            _clothesRight.Hat
        };
    }
    public List<Sprite> GetLeftBoots()
    {
        return new List<Sprite> { _clothesUp.LeftBoot,
            _clothesDown.LeftBoot,
            _clothesLeft.LeftBoot,
            _clothesRight.LeftBoot,
        };
    }
    public List<Sprite> GetRightBoots()
    {
        return new List<Sprite> { _clothesUp.RightBoot,
            _clothesDown.RightBoot,
            _clothesLeft.RightBoot,
            _clothesRight.RightBoot
        };
    }
}
