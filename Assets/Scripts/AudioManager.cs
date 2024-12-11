using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainMenuBGM;
    public AudioSource seaWaveSFX;

    public AudioSource clickSFX;
    public AudioSource woodcutSFX;
    public AudioSource explorationBGM;
    public AudioSource bossFightBGM;
    public AudioSource warBGM;
    public AudioSource rallyBGM;
    public AudioSource intenseBGM;
    public AudioSource mainSkullIsland;

    public void MainMenuBGMPlay()
    {
        mainMenuBGM.Play();
    }

    public void SeaWaveSFXPlay()
    {
        seaWaveSFX.Play();
    }

    public void ClickSFXPlay()
    {
        clickSFX.Play();
    }

    public void WoodcutSFXPlay()
    {
        woodcutSFX.Play();
    }

    public void ExplorationBGMPlay()
    {
        explorationBGM.Play();
    }

    public void BossFightBGMPlay()
    {
        bossFightBGM.Play();
    }

    public void WarBGMPlay()
    {
        warBGM.Play();
    }

    public void RallyBGMPlay()
    {
        rallyBGM.Play();
    }

    public void IntenseBGMPlay()
    {
        intenseBGM.Play();
    }

    public void SkullIslandBGMPlay()
    {
        mainSkullIsland.Play();
    }

    public void WarBGMStop()
    {
        warBGM.Stop();
    }

    public void SeaWaveSFXStop()
    {
        seaWaveSFX.Stop();
    }

    public void MainMenuBGMStop()
    {
        mainMenuBGM.Stop();
    }

    public void ClickSFXStop()
    {
        clickSFX.Stop();
    }

    public void WoodcutSFXStop()
    {
        woodcutSFX.Stop();
    }

    public void ExplorationBGMStop()
    {
        explorationBGM.Stop();
    }

    public void BossFightBGMStop()
    {
        bossFightBGM.Stop();
    }

    public void RallyBGMStop()
    {
        rallyBGM.Stop();
    }

    public void IntenseBGMStop()
    {
        intenseBGM.Stop();
    }

    public void SkullIslandBGMStop()
    {
        mainSkullIsland.Stop();
    }
}