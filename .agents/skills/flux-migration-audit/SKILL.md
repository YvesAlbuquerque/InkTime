---
name: flux-migration-audit
description: "Audit InkTime's legacy Assets/YJackCore coupling against current Loomlight Flux before migration, preserving Unity serialization, submodule ownership, asmdefs, GUIDs and game/framework boundaries."
argument-hint: "[subsystem | path | issue | full]"
user-invocable: true
---

# Flux Migration Audit

## Procedure

1. Confirm the reproducible InkTime Unity baseline exists before treating migration findings as executable.
2. Inventory references to `Assets/YJackCore/`: namespaces, types, serialized components/assets, asmdefs, editor tooling, package/submodule paths and game adapters.
3. Read current Loomlight Flux `AGENTS.md`, package metadata, nearest architecture/API/docs and tests for each used capability.
4. Classify each coupling:
   - `KEEP_COMPAT` — legacy identifier/path must remain for serialization or compatibility;
   - `USE_CURRENT_FLUX` — direct current Flux surface fits;
   - `INKTIME_ADAPTER` — game-owned adapter required under `Assets/InkThroughTime/`;
   - `FLUX_GAP` — reusable framework capability is genuinely missing and should be proposed in Flux separately;
   - `REMOVE_UNUSED` — proven unused coupling can be removed safely.
5. Record serialization/GUID/`.meta`/asmdef/editor-runtime risks and migration order.
6. Never edit the Flux submodule for an InkTime-specific requirement.
7. Define Unity import/compile/scene/Play Mode checks required after each migration slice.
8. Do not call migration complete until relevant game workflows are validated in Unity.

## Output

A coupling matrix, scoped migration order, Flux follow-ups if any, rollback points and required Unity evidence.
