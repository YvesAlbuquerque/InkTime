---
name: flux-migration-audit
description: "Legacy-only audit for T.O.O.N.'s checked-in Unity/Flux scaffold. Use only to classify migration evidence or retire old coupling; never route new Unreal gameplay work through Flux."
argument-hint: "[subsystem | path | issue | full]"
user-invocable: true
---

# Flux Migration Audit

> **Legacy-only skill.** Unreal Engine is the accepted target. If the task is new gameplay/architecture rather than migration evidence, stop and route to the Unreal plan instead.

## Procedure

1. Confirm the task genuinely concerns legacy Unity/Flux evidence; otherwise return `NOT_APPLICABLE_TARGET_IS_UNREAL`.
2. Inventory references to `Assets/YJackCore/`: namespaces, types, serialized components/assets, asmdefs, editor tooling, package/submodule paths and game adapters.
3. Read current Loomlight Flux `AGENTS.md`, package metadata, nearest architecture/API/docs and tests for each used capability.
4. Classify each coupling:
   - `PORT_CONCEPT` — engine-neutral idea worth re-expressing in Unreal;
   - `PRESERVE_EVIDENCE` — keep only as historical/validation evidence;
   - `EXTRACT_DATA` — useful authored/state data needs a bounded extraction path;
   - `RETIRE` — obsolete Unity/Flux coupling should not follow the project;
5. Record serialization/GUID/`.meta`/asmdef/editor-runtime risks and migration order.
6. Never edit the Flux submodule for a T.O.O.N.-specific requirement.
7. Define Unity validation only when a legacy extraction/retirement step actually mutates the Unity scaffold.
8. Never treat a Unity validation result as Unreal implementation evidence.

Legacy `Assets/InkThroughTime/` and `InkThroughTime.*` identifiers are compatibility surfaces, not the current game name.

## Output

A coupling matrix, scoped migration order, Flux follow-ups if any, rollback points and required Unity evidence.
