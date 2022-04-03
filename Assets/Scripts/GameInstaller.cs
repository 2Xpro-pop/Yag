using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] UIActions actions;
    [SerializeField] Player player;
    [SerializeField] Monster monster;
    [SerializeField] FloorPoints points;
    [SerializeField] QuestUI questUI;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHideSystem>().AsSingle();
        Container.Bind<UIActions>().FromInstance(actions);
        Container.Bind<FloorPoints>().FromInstance(points);
        Container.Bind<QuestUI>().FromInstance(questUI);
        Container.Bind<Player>().FromInstance(player);
        Container.Bind<Monster>().FromInstance(monster);
    }
}