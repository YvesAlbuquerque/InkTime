# InkTime AI Delivery Pipeline

Use this pipeline after root `AGENTS.md`. It keeps the renewed persistent comic-IP design, the existing Unity project, the mock-first AI strategy and Loomlight Flux migration evidence in the correct order.

## Default flow

```text
README / design / roadmap / current issue
  -> recover current Unity evidence
  -> game-domain ownership + dependency check
  -> static work vs live Unity work route
  -> smallest vertical-slice step
  -> MockComicAIService first
  -> focused tests / Unity validation as required
  -> PR / roadmap / evidence reconciliation
```

## 1. Do not skip the baseline

Implementation claims begin with current Unity/project evidence, not renewed design docs or historical stubs. Follow the owning roadmap dependency order. Until the reproducible baseline is recovered, broad feature work should remain planning/audit only where it depends on unknown project health.

## 2. Keep one game architecture for Manual, AI and Hybrid authorship

The persistent game model remains based on IP, Series, Story/Arc, Publication, structured Script, Pages and Panels as needed by the vertical slice.

Manual, AI and Hybrid authorship use the same authoritative structured publication/script model. AI providers are adapters that propose/generate bounded content; they do not own cash, progression, sales, canon acceptance, publication decisions or other gameplay state.

## 3. Mock before inference

For every AI-assisted production stage:

1. define the InkTime-owned request/result contract;
2. implement/extend `MockComicAIService` behavior sufficient for the vertical slice;
3. validate the complete game loop with deterministic/mock outputs;
4. introduce `LocalComicAIService` only after the mock path proves the workflow;
5. keep cloud AI APIs/accounts/required network access out unless a later explicit decision changes scope.

Provider capability is not game-loop validation.

## 4. Protect the Flux boundary

`Assets/YJackCore/` is the read-only Loomlight Flux submodule. Search it for reusable capabilities before adding game-local helpers, but never edit the submodule for InkTime-specific requirements.

Migration work must inventory actual coupling, inspect current Flux evidence and preserve serialization, GUIDs, `.meta`, asmdefs and asset references. Game-specific adapters belong under `Assets/InkThroughTime/`.

## 5. Choose static versus live Unity work honestly

Repository/GitHub AI work is suitable for design/docs, issue planning, pure domain C#, provider-independent contracts, mock logic and static analysis when runtime evidence is not claimed.

Use an environment with the actual Unity project/CLI/Editor available when completion depends on import/compile/domain reload, scene/prefab/asset serialization, package/submodule resolution, Play Mode, export rendering, build or visual/runtime validation.

If that environment is unavailable, implementation may land only when repository policy permits it with explicit manual Unity debt; do not mark the owning validation gate complete.

## 6. Keep export downstream

Structured publication data remains source of truth. PDF/digital export renders from it. Do not make PDF the storage model or infer print readiness from a successful digital export.

## 7. Close the loop

After merge reconcile issue/roadmap state and record the evidence that justifies any status increase. Historical code presence remains Scaffolded evidence until the relevant renewed workflow is exercised.

## Skills added by this pass

- `inktime-vertical-slice` — enforce game-domain, mock-first and Manual/AI/Hybrid invariants while advancing the renewed loop.
- `flux-migration-audit` — inventory YJackCore/Flux coupling and design a serialization-safe scoped migration before edits.
