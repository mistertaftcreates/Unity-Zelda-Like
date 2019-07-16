using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{

    public Slider magicSlider;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        magicSlider.maxValue = playerInventory.maxMagic;
        magicSlider.value = playerInventory.maxMagic;
        playerInventory.currentMagic = playerInventory.maxMagic;
    }

    public void AddMagic()
    {
        //magicSlider.value += 1;

        //playerInventory.currentMagic += 1;
        magicSlider.value = playerInventory.currentMagic;
        if (magicSlider.value > magicSlider.maxValue)
        {
            magicSlider.value = magicSlider.maxValue;
            playerInventory.currentMagic = playerInventory.maxMagic;
        }
    }

    public void DecreaseMagic()
    {
        //magicSlider.value -= 1;
        //playerInventory.currentMagic -= 1;
        magicSlider.value = playerInventory.currentMagic;
        if(magicSlider.value < 0)
        {
            magicSlider.value = 0;
            playerInventory.currentMagic = 0;
        }
    }

}
