# Ink Through Time — Third-Party Notices

This document lists all third-party packages, libraries, and tools used in the Ink Through Time project and their respective licenses.

---

## Unity Packages (Unity Technologies)

The following packages are provided by Unity Technologies under the [Unity Package Distribution License](https://unity.com/legal/licenses/unity-package-distribution-license) or related Unity terms:

- `com.unity.render-pipelines.universal` — Universal Render Pipeline
- `com.unity.inputsystem` — Input System
- `com.unity.cinemachine` — Cinemachine
- `com.unity.ai.inference` — AI Inference (on-device model inference)
- `com.unity.ai.navigation` — AI Navigation
- `com.unity.behavior` — Behavior (behavior trees)
- `com.unity.burst` — Burst Compiler
- `com.unity.mathematics` — Mathematics library
- `com.unity.addressables` — Addressable Asset System
- `com.unity.localization` — Localization
- `com.unity.timeline` — Timeline
- `com.unity.visualeffectgraph` — Visual Effect Graph
- `com.unity.visualscripting` — Visual Scripting
- `com.unity.probuilder` — ProBuilder
- `com.unity.postprocessing` — Post Processing Stack
- `com.unity.nuget.newtonsoft-json` — Newtonsoft Json.NET for Unity

---

## Third-Party Unity Packages

### Sirenix / Odin Inspector
- **Location:** `Assets/Plugins/Sirenix/`
- **License:** Commercial — Sirenix Software License
- **Website:** https://odininspector.com/

### UnityMeshSimplifier
- **Package:** `com.whinarn.unitymeshsimplifier`
- **Source:** https://github.com/Whinarn/UnityMeshSimplifier
- **License:** MIT License

---

## Framework

### Loomlight Flux (YJackCore)
- **Location:** `Assets/YJackCore/` (Git submodule)
- **Repository:** https://github.com/YvesAlbuquerque/YJackCore
- **License:** See `Assets/YJackCore/LICENSE.md`
- **Usage:** Reusable Unity gameplay framework (Observable<T>, event channels, save system, scene flow, audio)

---

## Notes

- This project does not include cloud AI services, telemetry, or required network access.
- All AI stages in Milestone 1 use `MockComicAIService` — no third-party AI API is required.
- Future local AI inference uses `com.unity.ai.inference` (on-device, no cloud dependency).
