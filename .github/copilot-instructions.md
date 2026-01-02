# Copilot Instructions for Wheel of Fate (Unity Game)

## Project Overview
A wave-based top-down shooter game built with Unity (URP). Player defeats enemies in progressively difficult waves with weapon switching, health management, and procedural enemy spawning.

## Architecture & Key Components

### Game Loop Flow
1. **Enemy Spawning** → [GeneratingEnemies.cs](../Assets/Scripts/GeneratingEnemies.cs): Controls wave progression and enemy spawn rates
   - Waves increase difficulty: max enemy count multiplies by WaveCount, spawn interval decreases
   - Controlled by `enemyCount`, `maxEnemyCount`, `interval` properties
   
2. **Player Systems** → [playermovement.cs](../Assets/Scripts/playermovement.cs), [playerLookAtEnemySC2.cs](../Assets/Scripts/playerLookAtEnemySC2.cs)
   - Movement: Rigidbody-based physics with sprint multiplier, ground detection via raycast
   - Rotation: Camera-relative aiming toward nearest/targeted enemy
   
3. **Combat** → [RayCastGun.cs](../Assets/Scripts/RayCastGun.cs), weapon switching via [weaponchange.cs](../Assets/Scripts/weaponchange.cs)
   - Line renderer visualizes laser; raycast detects hits at `gunRange`
   - Weapons controlled by input system (Unity 1.14.2)
   
4. **Health & Damage** → [Health.cs](../Assets/Scripts/Health.cs) (player), [entity.cs](../Assets/Scripts/entity.cs) (enemies)
   - Health property triggers bar update via `HPScript.UpdateHealthBar()`
   - Destruction on `health <= 0`

### Subsystems

- **UI/HUD**: [HPScript.cs](../Assets/Scripts/HPScript.cs) updates health bars; [Scores.cs](../Assets/Scripts/Scores.cs) tracks score
- **Scene Management**: [ChangeScene.cs](../Assets/Scripts/ChangeScene.cs), [Scenem.cs](../Assets/Scripts/Scenem.cs), [resetScene.cs](../Assets/Scripts/resetScene.cs)
- **Pickups**: [PickupController.cs](../Assets/Scripts/PickupController.cs) manages weapon equipping/dropping
- **Enemy AI**: [enemylookingplayer.cs](../Assets/Scripts/enemylookingplayer.cs), [MoveScript.cs](../Assets/Scripts/MoveScript.cs)

## Coding Patterns & Conventions

### MonoBehaviour Organization
- **SerializeField**: Used for inspector-exposed properties (e.g., `speed`, `sprintMultiplier` in playermovement.cs)
- **OnEnable/Awake/Start**: Initialization order: Awake for components, Start for runtime setup
- **Update for input**, coroutines for timed events (e.g., `Invoke("EnemyCoroutine", 2f)`)

### Health & Damage System Pattern
```csharp
// entity.cs example: Property-based health with automatic destruction
public float Health {
    get { return health; }
    set {
        health = value;
        _healthbar.UpdateHealthBar(StartingHealth, health);
        if (health <= 0f) Destroy(gameObject);
    }
}
```
**Apply this pattern** when modifying damage systems: health as property with side effects, not direct field mutation.

### Input Handling
- Unity InputSystem 1.14.2 required (Packages/manifest.json)
- Raw `Input.GetMouseButton()`, `Input.GetKey()` used alongside InputSystem
- Recommend standardizing on InputSystem for new features

### GameObject References
- Direct public field assignment in inspector common (e.g., `public GameObject enemy`, `public Transform spawnedEnemys`)
- Prefer `GetComponent<>()` in Awake/Start over relying on manual assignment

## Development Workflow

### Building/Running
- **Solution files**: Game.sln (primary), Wheel of fate.sln (legacy)
- **Play in Editor**: Use Play button; reset handled by [Reset.cs](../Assets/Scripts/Reset.cs) toggle
- **Scenes**: Located in Assets/Scenes/; scene transitions via SceneManager

### Debugging Common Issues
- **Rigidbody physics**: Check constraints (frozen rotation) and collision detection mode in [playermovement.cs](../Assets/Scripts/playermovement.cs) Start()
- **Enemy spawn timing**: Debug.Log statements in [GeneratingEnemies.cs](../Assets/Scripts/GeneratingEnemies.cs) Update() show wave progression
- **Weapon not firing**: Verify `resetd.activeSelf` check in [RayCastGun.cs](../Assets/Scripts/RayCastGun.cs) (disables gun during UI states)

### File Naming Conventions
- **lowercase with camelCase or underscore** for action scripts (playermovement.cs, enemylookingplayer.cs)
- **PascalCase for UI/system classes** (Health.cs, PickupController.cs, GeneratingEnemies.cs)
- Inconsistent; prioritize clarity for new scripts

## Dependencies & External Integration

### Unity Packages (Packages/manifest.json)
- **InputSystem** 1.14.2: Input handling
- **TextMesh Pro**: UI text (Health.cs, HPScript.cs)
- **Universal Render Pipeline (URP)** 17.2.0: Graphics
- **Cinemachine** 3.1.5: Camera (may be used for dynamic focus)
- **VisualScripting** 1.9.7: Alternative scripting (some files reference Unity.VisualScripting)

### Asset Organization
- Scenes: Assets/Scenes/
- Scripts: Assets/Scripts/ (all game logic), Assets/Scripts New/ (archived?—clarify usage)
- Prefabs: Assets/Prefabs/, Assets/Prefabs 1/
- Sprites/Animations: Assets/Sprites/, Assets/animations/
- Audio: Assets/Sounds/
- UI Elements: Assets/TextMesh Pro/, Assets/New_Version_RetroChocolate_Textbox/

## Key Patterns to Preserve

1. **Wave progression scaling**: Each wave multiplies enemy count and divides spawn interval—respect this balance when tweaking difficulty
2. **Raycast-based targeting**: All weapons use Physics.Raycast; maintain LayerMask consistency
3. **Property-driven health**: Health changes trigger UI updates via property setters, not callbacks—keep this pattern
4. **Scene reset state**: `resetd.activeSelf` gate prevents input during UI overlays; check before allowing player/weapon actions

## Quick Reference: Essential Files by Role

| Task | Files |
|------|-------|
| Add enemy behavior | [entity.cs](../Assets/Scripts/entity.cs), [enemylookingplayer.cs](../Assets/Scripts/enemylookingplayer.cs), [MoveScript.cs](../Assets/Scripts/MoveScript.cs) |
| Adjust difficulty | [GeneratingEnemies.cs](../Assets/Scripts/GeneratingEnemies.cs) (wave scaling) |
| Modify player movement | [playermovement.cs](../Assets/Scripts/playermovement.cs) |
| Weapon mechanics | [RayCastGun.cs](../Assets/Scripts/RayCastGun.cs), [weaponchange.cs](../Assets/Scripts/weaponchange.cs) |
| UI/Health display | [Health.cs](../Assets/Scripts/Health.cs), [HPScript.cs](../Assets/Scripts/HPScript.cs) |
| Scene transitions | [Scenem.cs](../Assets/Scripts/Scenem.cs), [ChangeScene.cs](../Assets/Scripts/ChangeScene.cs) |
