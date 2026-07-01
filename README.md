# YJack

**YJack** is a Unity 6+ game development framework built on a **four-layer architecture** that enforces clean separation of concerns, testability, and reusability across projects.

```
┌─────────────────────────────────────────────┐
│            Game Layer (Global)              │  GameManager, SaveSystem, SceneFlow, Audio, Settings
├─────────────────────────────────────────────┤
│            Scene Layer (Gameplay)           │  BaseLevelManager, SlotSystem, TurnBased, Teams
├─────────────────────────────────────────────┤
│            Core Layer (Engine)              │  CoreManager, Camera, Character, Controllers
├─────────────────────────────────────────────┤
│              View Layer (UI/HUD)            │  ViewManager, uGUI, Minimap, VFX
└─────────────────────────────────────────────┘
         ↕ Shared (cross-cutting)
   BaseStatus, Extension Methods, Filters, ScriptableObjects
```

Dependencies flow **upward only** — lower layers may reference upper layers, but never the reverse.

---

## Features

- **Reactive ScriptableObject system** — `BaseStatus<T>` with events, implicit conversion, save/load
- **Async save system** — `ISaveAndLoad` interface, JSON serialization, file/cloud providers, XOR encryption, `CancellationToken` support
- **Scene flow management** — async loading, preloading, network variants, memory cleanup
- **Turn-based game system** — generic turn queue, state machine integration
- **Slot system** — inventory/grid management with drag-and-drop support
- **Real-time profiler** — FPS, CPU, GPU, memory, battery monitoring
- **Performance-first extensions** — `AggressiveInlining`, non-alloc APIs, shared buffers
- **Custom inspector attributes** — `[ReadOnly]`, `[ProgressBar]`, `[HelpBox]`, `[Separator]`, polymorphic `[SerializeReference]`
- **ScriptableObject event channels** — fully decoupled `GameEvent<T>` assets

---

## Requirements

- **Unity 6000.0+** (Unity 6)
- **Newtonsoft.Json** (for save system serialization)

---

## Getting Started

1. Import YJack into your Unity project
2. Place the `GameManager` prefab in your scene
3. Access any sub-system via `GameManager`:

```csharp
GameManager.SaveSystem.Save();
GameManager.AudioManager.Play("sfx_click");
GameManager.SceneManager.LoadLevel("MainMenu");
```

4. Implement `ISaveAndLoad` on any MonoBehaviour to participate in the save system — no registration needed:

```csharp
public class PlayerData : MonoBehaviour, ISaveAndLoad
{
    public string GetSaveGroup() => "Player";
    public void Save(Dictionary<string, object> data) { data["hp"] = health; }
    public void Load(Dictionary<string, object> data) { if (data != null) health = (int)data["hp"]; }
}
```

---

## Documentation

### Core Documents

| Document | Description |
|---|---|
| **[Architecture Guide](Assets/YJackCore/ARCHITECTURE.md)** | Full technical reference — all 25 sections covering every system, pattern, and design decision |
| **[Contributing Guide](Assets/YJackCore/CONTRIBUTING.md)** | Quick-reference for contributors — coding conventions, PR checklist, lifecycle rules |
| **[Changelog](Assets/YJackCore/CHANGELOG.md)** | Version history |

### Layer Deep-Dives

Each layer has its own detailed document with sub-system breakdowns, code patterns, and recommendations:

| Document | Layer |
|---|---|
| **[GameLayer.md](Assets/YJackCore/GameLayer.md)** | GameManager, SaveSystem, Audio, Settings, SceneFlow, DevMode |
| **[SceneLayer.md](Assets/YJackCore/SceneLayer.md)** | BaseLevelManager, SlotSystem, TurnBased, Teams, Weather |
| **[CoreLayer.md](Assets/YJackCore/CoreLayer.md)** | CoreManager, Camera, Character, Controllers, Input |
| **[ViewLayer.md](Assets/YJackCore/ViewLayer.md)** | ViewManager, uGUI, Minimap, VFX, Audio UI |

---

## Project Structure

```
Assets/YJackCore/
├── Scripts/
│   ├── Shared/              # Cross-cutting: BaseStatus<T>, extensions, filters, interfaces
│   ├── Runtime/
│   │   ├── GameLayer/       # GameManager, SaveSystem, Audio, Settings, DevMode
│   │   ├── SceneLayer/      # BaseLevelManager, SlotSystem, TurnBased, Teams
│   │   ├── CoreLayer/       # CoreManager, Camera, Character, Controllers
│   │   ├── ViewLayer/       # ViewManager, uGUI, Minimap, VFX
│   │   └── Utilities/       # Singleton<T>, InterfaceHelper, RoundBuffer<T>
│   ├── Editor/              # Custom inspectors, drawers, editor tools
│   └── Tests/Runtime/       # NUnit runtime tests
├── ARCHITECTURE.md
├── CONTRIBUTING.md
└── README.md
```

---

## License

See [LICENSE](Assets/YJackCore/LICENSE.md) for details.

---

## Links

- [YGameDev — Unity Game Architecture](https://www.ygamedev.com/post/2015/08/01/unity-game-architecture-part-i)


