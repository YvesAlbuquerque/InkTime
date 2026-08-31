# InkTime AI Delivery Pipeline

Use this pipeline after root `AGENTS.md`. It keeps the renewed persistent comic-IP design, the existing Unity project, the mock-first AI strategy and Loomlight Flux migration evidence in the correct order.

InkTime currently includes Unity Assistant `2.9.0-pre.2`, which supports local Assistant skills, but the repository does **not** currently establish `com.unity.pipeline` as a dependency. Do not copy the ygamedev.com live-control assumptions into InkTime without repository evidence.

## Default flow

```text
README / design / roadmap / current issue
  -> recover current Unity evidence
  -> game-domain ownership + dependency check
  -> static work / local Assistant guidance / live Unity route
  -> inspect + rollback before non-trivial Editor mutation
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

## 5. Route Unity work honestly

Repository/GitHub AI work is suitable for design/docs, issue planning, pure domain C#, provider-independent contracts, mock logic and static analysis when runtime evidence is not claimed.

Unity Assistant local skills may provide project-specific guidance/workflows when they are discovered and explicitly enabled in the real Editor. Skill presence does not prove runtime validation.

Use an environment with the actual Unity project/Editor available when completion depends on import/compile/domain reload, scene/prefab/asset serialization, package/submodule resolution, Play Mode, export rendering, build or visual/runtime validation.

Run `unity-editor-change-gate` before non-trivial live mutation. For package changes run `unity-package-change`.

Do not assume live Unity CLI/Pipeline control exists in InkTime merely because another repository uses it. If tooling is unavailable, implementation may land only when repository policy permits it with explicit manual Unity debt; do not mark the owning validation gate complete.

## 6. Reuse generic official Unity skills selectively

Official `Unity-Technologies/skills` should be preferred for generic engine workflows when compatible with InkTime's pinned versions, rather than copied wholesale. Relevant examples include package management, UI-system routing and generic Unity operation guidance.

Apply these rules:

- current InkTime project/package evidence overrides upstream defaults;
- do not apply version-specific APIs outside their declared package/editor assumptions;
- do not install multiplayer/ads/IAP/cloud-service workflows merely because such skills exist;
- do not install a second community REST/MCP Editor-control runtime without a concrete capability gap and explicit validation need.

Community projects such as `Besty0728/Unity-Skills` are useful references for plan/dry-run, risk classification, rollback/audit and domain-reload recovery. Adopt the principles, not the entire control substrate by default.

## 7. Evaluate local Assistant skills after baseline recovery

A local skill should encode a repeated InkTime workflow, not duplicate root instructions. Evaluate candidates with a fixed project state and repeated with/without runs before keeping them.

Preferred first candidates after the reproducible Unity baseline is recovered:

- safe InkTime scene/prefab/asset mutation;
- package/baseline recovery guidance;
- later, structured Manual/AI/Hybrid comic-production authoring only after the mock vertical slice exists.

Do not add local skills that encourage feature work ahead of the issue dependency graph.

## 8. Keep export downstream

Structured publication data remains source of truth. PDF/digital export renders from it. Do not make PDF the storage model or infer print readiness from a successful digital export.

## 9. Close the loop

After merge reconcile issue/roadmap state and record the evidence that justifies any status increase. Historical code presence remains Scaffolded evidence until the relevant renewed workflow is exercised.

## Local skills

- `inktime-vertical-slice` — enforce game-domain, mock-first and Manual/AI/Hybrid invariants while advancing the renewed loop.
- `flux-migration-audit` — inventory YJackCore/Flux coupling and design a serialization-safe scoped migration before edits.
- `unity-editor-change-gate` — govern non-trivial Editor mutation, rollback, lifecycle reconnect and evidence.
- `unity-package-change` — keep package changes UPM-aware, scoped and baseline-safe.
