---
name: unity-editor-change-gate
description: "Legacy-only safety gate for mutations to T.O.O.N.'s checked-in Unity scaffold during migration/extraction. Not for new Unreal gameplay work."
argument-hint: "[scene | prefab | asset | editor operation]"
user-invocable: true
---

# T.O.O.N. Unity Editor Change Gate

> **Legacy-only skill.** Unreal Engine is the accepted target. Use this only when migration/extraction explicitly requires changing the old Unity scaffold.

If the requested task is new T.O.O.N. gameplay, presentation, AI, persistence or production architecture, do not mutate Unity; route to the Unreal roadmap.

## 1. Confirm baseline and scope

1. Read root `AGENTS.md`, current issue/roadmap dependency and nearest implementation evidence.
2. Confirm actual Unity version/packages and whether the task is allowed at the current baseline.
3. Identify game-owned files/assets affected and whether `Assets/YJackCore/` is involved.
4. If the task needs import/compile/scene/prefab/runtime evidence, require a real Unity-capable environment before claiming completion.

## 2. Inspect before writing

Inspect existing scene/prefab/asset/code state first. Prefer the Unity Editor as serialization authority.

Do not assume a live CLI/Pipeline control path unless repository/package evidence establishes one.

## 3. Classify risk and rollback

Classify the mutation:

- `LOW` — small reversible property/object edit;
- `MEDIUM` — multi-object, prefab, asset, import/settings or package-adjacent change;
- `HIGH` — destructive asset work, serialization/GUID migration, namespace/assembly migration, submodule/framework migration or project/package version change.

For MEDIUM/HIGH work state:

- intended change set;
- affected assets/files/references;
- rollback path;
- compile/import/Play Mode validation needed;
- issue/dependency authorizing the change.

Preserve `.meta` files, GUIDs and asset references. Never edit Flux submodule source for game-specific requirements.

## 4. Execute and survive Unity lifecycle events

Prefer Editor-owned serialization over raw `.unity`, `.prefab` or `.asset` edits.

Compilation, asset reimport and Domain Reload may temporarily interrupt tooling. Reinspect state after reload instead of assuming success.

## 5. Verify

After mutation verify as applicable:

- import/compile completes;
- no new relevant Console errors;
- expected scene/prefab/asset state is visible;
- `.meta` and references are intact;
- relevant Edit/Play Mode tests run;
- the game still respects game-owned authority and the accepted T.O.O.N. design;
- Git diff contains only expected changes.

Do not promote status from static code presence alone.

## Verdict

Return `READY_TO_MUTATE`, `BLOCKED_BY_BASELINE`, `BLOCKED_BY_DEPENDENCY`, `MUTATION_COMPLETE_VALIDATION_PENDING`, or `VALIDATED`, with exact evidence and remaining Unity/manual validation.
