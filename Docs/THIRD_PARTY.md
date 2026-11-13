# T.O.O.N. — The Office Of Nonsense — Third-Party Notices

This document lists third-party packages, libraries, and tools currently present in the repository. The Unity items below belong to the **legacy scaffold currently checked in**; their presence does not make Unity the accepted target engine.

The project was formerly known as InkTime / Ink Through Time; historical package paths and notices may retain legacy compatibility names where required.

---

## Unity Packages (Unity Technologies)

The following packages are provided by Unity Technologies under the [Unity Package Distribution License](https://unity.com/legal/licenses/unity-package-distribution-license) or related Unity terms:

- `com.unity.render-pipelines.universal` — Universal Render Pipeline
- `com.unity.inputsystem` — Input System
- `com.unity.cinemachine` — Cinemachine
- `com.unity.ai.inference` — AI Inference
- `com.unity.ai.navigation` — AI Navigation
- `com.unity.behavior` — Behavior
- `com.unity.burst` — Burst Compiler
- `com.unity.mathematics` — Mathematics
- `com.unity.addressables` — Addressables
- `com.unity.localization` — Localization
- `com.unity.timeline` — Timeline
- `com.unity.visualeffectgraph` — Visual Effect Graph
- `com.unity.visualscripting` — Visual Scripting
- `com.unity.probuilder` — ProBuilder
- `com.unity.postprocessing` — Post Processing
- `com.unity.nuget.newtonsoft-json` — Newtonsoft Json.NET for Unity

## Third-Party Unity Packages

### Sirenix / Odin Inspector

- **Location:** `Assets/Plugins/Sirenix/`
- **License:** Commercial — Sirenix Software License
- **Website:** https://odininspector.com/

### UnityMeshSimplifier

- **Package:** `com.whinarn.unitymeshsimplifier`
- **Source:** https://github.com/Whinarn/UnityMeshSimplifier
- **License:** MIT License

## Framework

### Loomlight Flux

- **Compatibility location:** `Assets/YJackCore/` Git submodule
- **Canonical framework:** Loomlight Flux
- **License:** see the submodule's license
- **Usage:** reusable Unity gameplay/framework capabilities in the legacy scaffold; not the target Unreal runtime framework

## Notes

- Package presence does not prove a package is required by the accepted T.O.O.N. vertical slice.
- Historical `MockComicAIService` / local-inference scaffold does not prove the accepted cross-media runtime AI workflow is implemented.
- No cloud AI, telemetry, build, or release claim should be inferred from this notice.
