using System;
using DungeonDivers.Arena;
using DungeonDivers.Units;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private ArenaDataSO arenaDataSO;
    [SerializeField] private Slider healthSlider;
    private AbstractHealthController healthController;

    public void SetHealthController(AbstractHealthController _healthController)
    {

        healthController = _healthController;
        healthController.OnEntityCurrentHealthChange += HandleHealthChange;
        healthSlider.value = healthController.CurrentHealth / healthController.MaxHealth;
    }

    private void HandleHealthChange(object sender, float e)
    {
        if (sender is not AbstractHealthController) return;
        healthSlider.value = healthController.CurrentHealth / healthController.MaxHealth;
    }

    void OnDisable()
    {
        healthController.OnEntityCurrentHealthChange -= HandleHealthChange;
    }
}
