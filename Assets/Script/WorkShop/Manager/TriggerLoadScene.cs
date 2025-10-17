using UnityEngine;

public class TriggerLoadScene : Item
{
    public AudioClip BackgroundMusic;
    public string LoadSceneName;

    public override void OnCollect(Player player)
    {
        base.OnCollect(player);
        LoadSceneManager.instance.LoadNewScene(LoadSceneName);
        SoundManager.instance.PlayMusic(BackgroundMusic);
    }
}
