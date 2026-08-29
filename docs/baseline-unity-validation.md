# InkTime Unity Baseline Validation

**Date:** 2026-08-29
**Issue:** #2 - Recover a reproducible Unity project baseline
**Scope:** local Unity/import/repository evidence supplementing [the static audit](baseline-static-audit.md)
**Status:** Blocked - project compilation is reproducible after the recorded fixes, but the configured entry scene has missing scripts and the legacy domain tests were not discovered by the Unity Test Runner.

## Validation Context

- Branch: `codex/validate-unity-baseline`
- Starting commit: `5a678298597df9569ac5551bc350b80ebe19d4ca` (`docs: record baseline static audit for renewed InkTime`)
- Unity project version: `6000.3.13f1` (`8c4f11e4fb20`)
- Editor used: `D:\Unity\6000.3.13f1_AND_IL2\Editor\Unity.exe`
- Validation checkout: a disposable clone at `C:\itb`; the source branch was not opened in Unity.

## Facts

### Clean checkout and submodules

The first exercised command was:

```powershell
git clone --recurse-submodules git@github.com:YvesAlbuquerque/InkTime.git C:\Users\Yves.Albuquerque\AppData\Local\Temp\InkTime-baseline-clean-clone
```

It authenticated to `git@github.com:YvesAlbuquerque/YJackCore.git` and reached submodule checkout, but failed because Windows reported `Filename too long` for multiple YJackCore `EditorIcons` assets. This was a path-length failure, not an SSH authentication failure.

The following succeeded:

```powershell
git -c core.longpaths=true clone --recurse-submodules git@github.com:YvesAlbuquerque/InkTime.git C:\itb
```

It checked out:

- InkTime: `5a678298597df9569ac5551bc350b80ebe19d4ca`
- `Assets/YJackCore`: `672a5d8bdd808d2ee8aa58ed626bc651ce7b7e05`
- nested `Assets/YJackCore/Scripts/Editor/PDM`: `a22f0e3e30e995ac9906edc6868c1022126573a2`

Manual prerequisite: clone at a short path and enable Git long paths for the clone command or local Git configuration. SSH access to the YJackCore repository is also required.

### Package resolution and compilation

Unity resolved 105 packages from the clean clone. The initial import failed with `CS0246` errors for `TMPro` and `TextMeshProUGUI` in `InkThroughTime.Presentation`.

Root cause: Unity's `Unity.TextMeshPro` assembly compiled, but `Assets/InkThroughTime/Scripts/Presentation/InkThroughTime.Presentation.asmdef` did not declare that assembly reference.

After the repair below, this command completed successfully:

```powershell
unity test C:\itb --mode EditMode --filter InkThroughTime.DomainTests --output C:\itb\TestResults\DomainTests-after-tmp-reference.xml --editor-version 6000.3.13f1 --timeout 1800 --json
```

The command forced package resolution and a Unity compilation. It produced zero tests because `InkThroughTime.DomainTests` is not a valid fixture name; it is compile evidence only.

The successful direct batch probe also compiled the full project with the pinned Editor and completed with exit code `0`.

The resolved import still reports pre-existing warnings from third-party/template content, including obsolete YJackCore APIs, unresolved package sample `.asmref` targets from Cinemachine and Entities, and a duplicate `System.Runtime.CompilerServices.Unsafe.dll` version between AI Assistant and Collections test content. These warnings were not changed in this issue.

### Build Settings and main scene

Unity reports exactly one enabled build scene:

```text
Assets/_Scenes/Main.unity
```

The batch Editor opened that scene and found:

- 10 root objects, 158 scene objects, and 188 `MonoBehaviour` components;
- root objects `GameLayer`, `SceneLayer`, `CoreLayer`, `ViewLayer`, `VirtualPad`, `EventSystem`, `NetworkManager`, `ExplosionFlashExample`, `Camera`, and `Capsule`;
- four missing scripts, all on the legacy `NetworkManager` transport hierarchy:
  - `NetworkManager`
  - `NetworkManager/Transports/UnetTransport2`
  - `NetworkManager/Transports/UTP`
  - `NetworkManager/Transports/Relay UTP`

This classifies `Main.unity` as historical YJack/template content, not a reasonable renewed InkTime entrypoint. No scene replacement or serialized rewrite was made in #2.

### Serialized-reference findings

Using Unity `AssetDatabase.GetDependencies` against `Assets/_Scenes/Main.unity` and all prefabs, the following InkThroughTime scripts had no serialized consumers:

- `InkGameRoot`
- `GameSession`
- `ProjectState`
- `PublishedComic`
- `IpState`
- `CalendarState`
- `StudioState`
- `EmployeeState`

This is evidence for the current main scene and prefab set only. It does not authorize deletion: ScriptableObject and non-prefab asset consumers remain a later migration/reference-audit concern.

### Tests

The expected `Assets/InkThroughTime/Scripts/Tests/DomainTests.cs` compiles into `InkThroughTime.Tests.dll` with 20 `[Test]` methods. Unity Test Runner discovery remains incomplete in this checkout:

- filtered Unity CLI attempts returned `0` tests;
- an unfiltered Unity CLI EditMode run executed only one unrelated `AddressableAssets.DocExampleCode.TestStub.RequiredTest` test (`1` passed, `0` failed);
- a direct Unity `-runTests` batch invocation exited `0` but did not produce its requested NUnit XML result.

No InkThroughTime domain test is recorded as executed. The test-discovery cause remains unknown and must be resolved before treating the legacy-domain tests as baseline validation.

### Package classification

- Required by the current imported framework source: Input System, Cinemachine, URP, Visual Scripting, and Addressables have YJackCore code or package define integration. Addressables paths are guarded by `ADDRESSABLES`; active runtime use was not demonstrated.
- Game-specific candidate: `com.unity.ai.inference` is mentioned by the InkThroughTime local AI placeholder, but no renewed AI workflow is validated.
- Actively configured project feature: Visual Scripting settings reference its assemblies.
- Unknown/template baggage pending a later audit: Ads, Purchasing, Microsoft GDK, Economy, Friends, Behavior, Entities, ProBuilder, Post Processing, VFX Graph, Localization, and several feature bundles. Package presence is not evidence of current InkTime use.

No package was uninstalled or upgraded.

## Fixes Performed

1. Added the missing `Unity.TextMeshPro` reference to `InkThroughTime.Presentation.asmdef`, eliminating the clean-import `TMPro` compiler errors.
2. Removed stale `com.unity.sentis` and local `com.yvesalbuquerque.autolod` entries from `Packages/packages-lock.json`. Unity removed both automatically during the clean import because neither remains in `Packages/manifest.json`; retaining them made a fresh checkout dirty after resolution.

## Remaining Blockers and Risks

- `Assets/_Scenes/Main.unity` has four missing networking transport scripts and is legacy/template content.
- Current Build Settings do not point to a renewed InkTime scene.
- The current InkThroughTime test assembly compiles but is not discovered by the exercised Unity Test Runner commands.
- Clean checkout is Windows-path-sensitive because of long YJackCore asset paths; the short-path/long-path Git requirement must be followed.
- A player build, Play Mode smoke test, and renewed design validation were not run. They are outside the evidence available for the current legacy entry scene.
- No Unity MCP/Pipeline Editor instance was available; the Editor was inspected through isolated batch commands instead.

## Unknowns

- Why the Unity Test Runner omits `InkThroughTime.Tests` while compiling its DLL.
- Whether ScriptableObjects or other non-prefab assets serialize additional references to the legacy scaffold.
- Whether the missing `NetworkManager` transport scripts can be restored with the current package set or should be removed as part of a later scene decision.
- Whether a player build will succeed once a valid entry scene is selected.

## Acceptance-Criterion Status

| Criterion | Status | Evidence |
| --- | --- | --- |
| Repository/project inventory includes Unity scene/reference evidence | Passed with limitations | Pinned Editor import, batch scene probe, and targeted dependency checks completed. |
| Known absolute package dependency is absent | Passed | It is absent from the manifest and was removed as stale lock metadata. |
| Historical/template files are classified before removal | Passed with limitations | Main scene and scaffold references were classified; no broad deletion occurred. |
| Clean-checkout setup is documented from an exercised checkout | Passed | Short-path clone with Git long paths and recursive submodule checkout succeeded. |
| Remaining import/compile/build-setting blockers are explicit | Passed | TextMeshPro blocker fixed; legacy scene, test discovery, and build-entrypoint risks recorded. |

Issue #2 remains open because the legacy entry scene is not usable as a trustworthy project baseline and the existing InkThroughTime tests have not been executed.
