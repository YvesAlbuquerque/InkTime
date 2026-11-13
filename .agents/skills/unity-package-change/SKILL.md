---
name: unity-package-change
description: "Legacy-only package-change gate for T.O.O.N.'s checked-in Unity scaffold during migration/extraction. Do not add Unity dependencies for new Unreal-target work."
argument-hint: "[package id | add | remove | upgrade | dependency problem]"
user-invocable: true
---

# T.O.O.N. Unity Package Change

> **Legacy-only skill.** Unreal Engine is the accepted target.

Use only when a migration/extraction task explicitly requires diagnosing or minimally changing packages in the old Unity scaffold. Do not modernize the Unity dependency set or add packages for new T.O.O.N. features.

T.O.O.N. currently has a broad historical package set and a legacy Flux/YJackCore submodule. Package work must be evidence-driven and should not be bundled into unrelated feature work.

## 1. Inspect current package evidence

Read:

- `Packages/manifest.json`;
- `Packages/packages-lock.json` when available;
- `ProjectSettings/ProjectVersion.txt`;
- the current issue/roadmap dependency;
- package-related baseline/migration audit evidence.

Identify why the package change is needed and which current package/version/coupling it affects.

## 2. Reject common bad changes

Block or challenge:

- machine-specific absolute `file:` dependencies;
- installing both `com.unity.sentis` and `com.unity.ai.inference`;
- broad package upgrades unrelated to the issue;
- package changes intended only to modernize the repository while baseline evidence is incomplete;
- adding cloud/network/telemetry dependencies that conflict with the current project direction;
- treating the Flux submodule as a package to modify for game-specific behavior.

## 3. Prefer Unity/UPM-aware resolution

When a real Unity environment is available, prefer the Unity Package Manager API/Editor-aware workflow over casually writing `Packages/manifest.json` by hand.

If only static repository work is available, a manifest change may be prepared only with explicit `MANUAL_UNITY_RESOLUTION_REQUIRED`; do not claim the package resolved.

## 4. Define the validation chain

For a package mutation require, as applicable:

1. package resolution succeeds in the actual project;
2. lockfile changes are expected and reviewed;
3. import/compile completes with no new relevant errors;
4. asmdef/compile-symbol behavior remains valid;
5. affected scenes/assets/prefabs retain references;
6. relevant Edit/Play Mode tests pass;
7. Flux submodule configuration remains intact;
8. Git diff contains no unexpected package/generated changes.

Package presence is not feature validation.
