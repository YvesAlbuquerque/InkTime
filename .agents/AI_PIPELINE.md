# T.O.O.N. AI Delivery Pipeline

Use this after root `AGENTS.md`. It keeps the accepted cartoon-animation-studio direction, the existing Unity scaffold, provider-independent AI boundary, and Loomlight Flux evidence in the correct order.

## Default flow

```text
README / design / roadmap / current issue
  -> inspect current Unity evidence
  -> identify the smallest T.O.O.N. production outcome
  -> preserve game/framework ownership boundaries
  -> manual/shared domain path first
  -> deterministic/mock proposal path
  -> AI/provider adapter only after the shared path exists
  -> Unity/runtime validation where required
  -> evidence + roadmap reconciliation
```

## 1. Do not let the historical comic scaffold define the game

Existing `Comic*`, `Publication`, `Page`, `Panel`, `Ink*`, or `InkThroughTime.*` types are historical scaffold evidence. Reuse only when they fit the accepted T.O.O.N. animation-production model.

Target conceptual hierarchy:

`IP -> Production -> Script -> Storyboard -> Sequence/Shot -> Result`

Do not mechanically rename comic concepts when the semantic model should change.

## 2. One architecture for Manual, AI-assisted and Hybrid work

The authoritative data is game-owned.

- Manual work edits it directly.
- AI-assisted/Hybrid work proposes bounded changes to the same structure.
- Provider results do not become canonical until accepted.
- AI never owns cash, progression, studio authority, release decisions, or irreversible creative commitments.

## 3. Prove the workflow before inference

For an AI-assisted stage:

1. define the T.O.O.N.-owned request/result contract;
2. prove the underlying manual/shared production state;
3. add a deterministic/mock proposal path;
4. exercise accept/reject/edit behaviour;
5. only then connect local or external inference when explicitly in scope.

Provider success is not game-loop validation.

## 4. Protect the Flux boundary

`Assets/YJackCore/` is the read-only Loomlight Flux compatibility submodule.

Search Flux before inventing reusable infrastructure, but keep studio, professional, production, IP, and creative semantics game-owned.

## 5. Route Unity work honestly

Repository work can cover docs, issues, pure domain C#, static analysis, and provider-independent contracts where runtime evidence is not claimed.

Use the real Unity project/Editor when completion depends on import/compile/domain reload, scene/prefab/asset serialization, package/submodule resolution, Play Mode, build, visual output, or save migration.

## 6. Current first proof

Prefer a compact proof with:

- one studio space;
- a small recurring cartoon crew;
- one IP;
- one short production;
- one script/storyboard path;
- one production decision/problem;
- release;
- one persistent visible consequence;
- save/reopen.

Do not expand into a professional DCC or large studio simulator before this works.

## 7. Close the loop

After implementation, reconcile Issues/roadmap and record only the evidence actually obtained.

## Local skills

- `toon-vertical-slice` — protect the animation-studio fantasy, persistent studio/IP/cast state, and shared Manual/AI/Hybrid structure.
- `flux-migration-audit` — serialization-safe Flux migration/audit.
- `unity-editor-change-gate` — non-trivial Editor mutation and rollback/evidence.
- `unity-package-change` — scoped package changes.
