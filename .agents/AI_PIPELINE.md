# T.O.O.N. AI Delivery Pipeline

Use this after root `AGENTS.md`. It keeps the accepted historical living-studio direction, Unreal target, AI-heavy production strategy, provider independence, and evidence discipline in the correct order.

## Default flow

```text
README / design / roadmap / current issue
  -> identify current engine/migration status
  -> identify the smallest T.O.O.N. gameplay or production outcome
  -> preserve game/provider ownership boundaries
  -> define game-owned state/contracts
  -> deterministic fixture or bounded proposal path
  -> runtime AI adapter only where the feature needs it
  -> Unreal/runtime validation where claimed
  -> evidence + roadmap/issue reconciliation
```

## 1. Do not let the historical Unity/comic scaffold define the game

Existing `Comic*`, `Publication`, `Page`, `Panel`, `Ink*`, `InkThroughTime.*` and Flux-host code are legacy scaffold evidence.

The target production core is medium-neutral:

`IP -> Production -> Medium -> Crew -> Stages -> Release -> Reception -> Legacy`

Panels, storyboard/shots, 3D assets and other medium-specific concepts are bounded submodels introduced only when gameplay requires them.

Do not mechanically rename Unity/comic concepts into Unreal when the semantic model should change.

## 2. Separate development-time AI from runtime AI

Development-time AI may be used aggressively for research, code, tests, debugging, tools, content, balancing and documentation.

Runtime/player-facing AI may generate or transform production content, but:

- provider SDK/schema stays behind T.O.O.N.-owned contracts;
- historical facts come from approved structured context rather than runtime invention;
- accepted production state/history remains game-owned;
- player/human authority remains explicit for creative direction and release;
- Game Studio/Nexus integration is never inferred merely because AI is present.

## 3. Provider independence does not mean building a DCC

Do not require feature-complete manual authoring for every medium just to prove architectural independence.

For a runtime-AI-assisted stage:

1. define the T.O.O.N.-owned request/result contract;
2. prove persistence/simulation semantics with deterministic fixtures or bounded mocks;
3. exercise proposal/accept/reject/edit behaviour where the design exposes it;
4. connect the provider adapter only after the game-owned boundary exists;
5. validate the actual generated output separately from the domain contract.

Provider success is not game-loop validation.

## 4. Route Unreal work honestly

The accepted target engine is Unreal Engine. The exact version remains TBD until bootstrap/validation.

Use real Unreal evidence when completion depends on compile/reflection/serialization, Blueprints, asset references, Editor behaviour, save/load, packaging, profiling, visual output or runtime interaction.

The current Unity project and `Assets/YJackCore/` Flux submodule remain historical migration evidence. Do not build new T.O.O.N. architecture on Flux.

## 5. Historical context

Production generation may consume bounded context from:

- current year/era;
- global timeline;
- local/country timeline;
- studio location/language;
- market/media conditions;
- IP history;
- assigned professionals and relationships;
- prior reception.

Do not dump the whole historical database into prompts and do not allow runtime AI to invent canonical historical facts.

## 6. Current first proof

Prefer a compact proof with:

- one small studio;
- 3–4 recurring professionals;
- one IP;
- one compact production;
- one relationship/production pressure;
- one meaningful player tradeoff;
- one viewable/readable result;
- release/reception;
- one durable consequence;
- save/reopen.

Do not expand into a professional DCC, full 130-year campaign, complete historical world simulation or large autonomous agent pipeline before this works.

## 7. Close the loop

After implementation, reconcile Issues/roadmap and record only evidence actually obtained.

## Local skills

- `toon-vertical-slice` — protect the historical living-studio fantasy, medium-neutral production core, persistent studio/IP/cast state and evidence-based Unreal status.
- `flux-migration-audit` — legacy Unity/Flux migration/audit evidence only.
- `unity-editor-change-gate` — legacy Unity mutation/evidence work only while the scaffold still exists.
- `unity-package-change` — legacy Unity package work only where explicitly required by migration evidence.
