# InkTime Loomlight Flux Upgrade Validation

**Date:** 2026-09-06
**Issue:** #4 - Scoped Loomlight Flux host upgrade
**Status:** Ready with limitations - the host compiles and retained serialized assets passed targeted inspection; the consumer PR depends on Flux PR #674 and Unity's batch test runner did not emit a result report.

## Deterministic state

- InkTime starting commit: `69bd914eff1ea5f0656bbf5542bfdd0eade476aa`.
- Previous Flux gitlink: `672a5d8bdd808d2ee8aa58ed626bc651ce7b7e05`.
- Current Flux `develop` candidate resolved at execution: `9d6c1c91492c64f268b1a2db8ed12e63ca7c6e73`.
- Validated Flux pin: `939fd34eb1176fd65cd38867d4b514d0fc1ecf50`.
- The validated pin is the one-file test-compile correction in [Flux PR #674](https://github.com/YvesAlbuquerque/Loomlight-Flux/pull/674). The InkTime PR must not merge before that Flux PR is merged.

`Assets/YJackCore` remains the intentional legacy compatibility path for the pinned Loomlight Flux repository. It was not moved to `Packages/` and no Flux source was edited from the InkTime checkout.

## Migration change

`.gitmodules` now uses the canonical remote:

```text
git@github.com:YvesAlbuquerque/Loomlight-Flux.git
```

The submodule was synchronized and updated recursively. Its nested PDM gitlink advanced from `a22f0e3e30e995ac9906edc6868c1022126573a2` to `9a2650de540312c79ac7abcf1fc04efa65cf78e2` as part of the selected Flux commit.

## Unity 6000.3.13f1 evidence

The pinned Editor `D:\Unity\6000.3.13f1_AND_IL2\Editor\Unity.exe` resolved the host Package Manager and compiled the host assemblies, including:

- `Loomlight.Flux.Base.dll`
- `Loomlight.Flux.Runtime.dll`
- `Loomlight.Flux.Editor.dll`
- `Loomlight.Flux.Tests.dll`
- all `InkThroughTime.*` assemblies

The initial target commit `9d6c1c9...` failed only in `Loomlight.Flux.Tests.dll`:

```text
SaveSyncCoordinatorTests.cs(24,17): error CS0118: 'SaveSystem' is a namespace but is used like a type
SaveSyncCoordinatorTests.cs(25,17): error CS0118: 'UserProfile' is a namespace but is used like a type
```

This was a Flux-owned test namespace-shadowing defect, corrected by Flux PR #674. The validated pin compiles the test assembly in this host.

The resolved package set still reports the baseline warnings for the Cinemachine sample `.asmref`, Entities `.asmref`, and duplicate `System.Runtime.CompilerServices.Unsafe.dll`. No API-updater migration was reported. These warnings are not attributed to the Flux upgrade.

## Serialized host-asset gate

An editor-time probe loaded `Assets/LoomlightFlux/ScriptableObject/Data/Editor/EventCategorySettings.asset` as `Loomlight.Flux.Core.EventCategorySettings` and retained its authored empty category list. Its GUID remains `c4af9a8d33c40c2499f6ab7efc862904`.

The same probe inspected retained `Assets/InkThroughTime`, `Assets/LoomlightFlux`, and `Assets/_Scenes` assets:

- missing components: 4, all in the historical `Assets/_Scenes/Main.unity` NetworkManager transport hierarchy;
- missing ScriptableObject/controller assets: 0;
- assets with missing managed-reference types: 0.

The four `Main.unity` missing components are the pre-existing baseline debt documented in `baseline-unity-validation.md`; no new missing framework references were found. The scene was not saved or redesigned.

## Focused test result

The following command was run after the Flux test fix:

```powershell
unity test D:\Projects\InkTime-flux-upgrade --mode EditMode --filter Loomlight.Flux.Tests.GameLayer.EventCategorySettingsTests --output C:\Users\Yves.Albuquerque\AppData\Local\Temp\InkTime-flux-upgrade-event-category-tests-fixed.xml --editor-version 6000.3.13f1 --timeout 1800 --json
```

Unity compiled `Loomlight.Flux.Tests.dll`, but the batch test runner did not produce the requested NUnit XML report and had to be stopped after compilation. Therefore **zero tests are claimed as executed**. The compile failure fixed by Flux PR #674 is covered by the host assembly compile evidence; test runtime behavior still needs a functioning Unity Test Runner report.

## Decision

Issue #4 can close after both PRs merge, because its scoped framework-host migration, compile gate, and serialized asset gate passed. It does not validate a renewed InkTime vertical slice, player build, Play Mode loop, or historical `Main.unity` repair.

A package-installation-path migration is worth considering only as a separate task after this pin is merged. Keeping `Assets/YJackCore` during the version jump made serialized risk and framework-version regressions attributable.
