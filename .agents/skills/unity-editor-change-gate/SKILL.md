---
name: unity-editor-change-gate
description: "Prepare and verify AI-assisted Unity Editor mutations in InkTime with baseline awareness, rollback, serialization safety, package/submodule boundaries and explicit post-change evidence."
argument-hint: "[scene | prefab | asset | editor operation]"
user-invocable: true
---

# InkTime Unity Editor Change Gate

Use before a non-trivial Unity Editor mutation. InkTime's renewed workflows remain only as implemented as current Unity evidence proves; do not let an AI operation skip the baseline-recovery and Flux-migration dependencies recorded in the roadmap/issues.

## 1. Confirm the baseline and scope

1. Read root `AGENTS.md`, current issue/roadmap dependency and nearest implementation evidence.
2. Confirm the actual Unity project version/packages and whether the task is allowed at the current baseline state.
3. Identify the game-owned files/assets affected and whether `Assets/YJackCore/` is involved. The Flux submodule is read-only for game-specific work.
4. If the task needs import/compile/scene/prefab/runtime evidence, require a real Unity-capable environment before claiming completion.

## 2. Inspect before writing

Inspect the existing scene/prefab/asset/code state first. Prefer the Unity Editor as the serialization authority.

If a live automation surface is available, discover the exact operations it exposes; do not invent commands. InkTime currently does not treat `com.unity.pipeline` as an established dependency, so do not assume the same CLI control path as other Unity projects unless repository/package evidence changes.

## 3. Classify risk and rollback

Classify the mutation:

- `LOW` — small reversible property/object edit;
- `MEDIUM` — multi-object, prefab, asset, import/settings or package-adjacent change;
- `HIGH` — destructive asset work, serialization/GUID migration, submodule/framework migration or project/package version change.

For MEDIUM/HIGH work state:

- intended change set;
- affected assets/files/references;
- rollback path;
- compile/import/Play Mode validation needed;
- issue/dependency that authorizes the change.

Preserve `.meta` files, GUIDs and asset references. Do not edit Flux submodule source for InkTime requirements.

## 4. Execute and survive Unity lifecycle events

Prefer Editor-owned serialization over raw `.unity`, `.prefab` or `.asset` edits.

Compilation, asset reimport and Domain Reload may temporarily interrupt AI/Editor tooling. Reinspect state after reload instead of assuming the last operation succeeded.

If the requested action is genuinely trivial and one-off, precise manual Editor guidance may be safer than automation. Prefer automation for traversal, batch consistency, exact values, repeated work and evidence capture.

## 5. Verify

After the mutation verify as applicable:

- import/compile completes;
- no new relevant Console errors;
- expected scene/prefab/asset state is visible in Unity;
- `.meta` and references are intact;
- relevant Edit/Play Mode tests run;
- the renewed game loop still respects `InkGameRoot`, pure Domain state and game-owned authority;
- the Git diff contains only expected changes.

Do not promote status from static code presence alone.

## Verdict

Return `READY_TO_MUTATE`, `BLOCKED_BY_BASELINE`, `BLOCKED_BY_DEPENDENCY`, `MUTATION_COMPLETE_VALIDATION_PENDING`, or `VALIDATED`, with exact evidence and remaining Unity/manual validation.
