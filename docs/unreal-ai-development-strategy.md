# Unreal + AI Development Strategy

**Status:** Accepted direction; Planned  
**Decision date:** 2026-11-13  
**Implementation status:** The repository still contains a Unity-based scaffold. This document does not claim an Unreal migration has been implemented or validated.

## Purpose

T.O.O.N. is intended to become the owner's first substantial Unreal Engine game project and an important professional portfolio artifact.

The project should therefore optimize for two outcomes at once:

1. build the strongest version of T.O.O.N.; and
2. create credible evidence of practical Unreal Engine competence.

AI will be used aggressively throughout development, but AI acceleration must not erase technical understanding, authorship, debugging ability, or evidence of engineering ownership.

## Engine direction

**Target engine:** Unreal Engine.

The exact Unreal version remains **TBD until project bootstrap and validation**. Do not claim a version, successful migration, build, package, or runtime behaviour until exercised.

The current Unity project, Loomlight Flux submodule, Unity serialization, and legacy InkTime implementation are **migration source evidence**, not the target runtime architecture.

Do not begin new T.O.O.N. gameplay architecture on Loomlight Flux after the Unreal direction is adopted.

Before removing Unity assets or code:

- inventory reusable design/domain knowledge separately from Unity-specific implementation;
- preserve historical evidence;
- identify save/data concepts worth porting;
- protect anything required to understand already validated work;
- define an Unreal bootstrap and migration boundary.

## Professional evidence goals

T.O.O.N. should demonstrate real Unreal competence rather than only a finished artifact produced by agents.

Useful evidence should eventually include, where relevant to the game:

- C++ gameplay/domain systems;
- correct use of Unreal object lifetime and reflection;
- `UObject`, `USTRUCT`, `UCLASS`, `UPROPERTY`, and `UFUNCTION` where appropriate;
- data-driven authoring with Unreal-native assets/configuration;
- Blueprint use where it improves iteration rather than replacing all architecture;
- subsystem/service ownership with clear lifetimes;
- persistence/save architecture;
- UMG or other appropriate UI implementation;
- editor tooling where it materially improves production;
- profiling and optimization evidence;
- automated or deterministic tests where practical;
- packaging/build evidence;
- debugging notes for non-trivial failures;
- technical decisions that explain why the architecture exists.

Do not add Unreal systems only to create a checklist. Every portfolio-relevant system must still serve the game.

## AI-heavy development

AI may be used extensively for:

- research;
- architecture alternatives;
- code drafting;
- refactors;
- test generation;
- debugging hypotheses;
- documentation;
- gameplay/content ideation;
- event and dialogue drafting;
- concept art and visual exploration;
- placeholder assets;
- data generation;
- balancing analysis;
- repetitive editor/data tasks;
- build/log analysis;
- review and critique.

### Ownership rule

Generated output is not evidence by itself.

For important technical work, preserve enough evidence to show:

- what problem was being solved;
- what architecture was selected;
- what AI proposed;
- what was reviewed or changed;
- what actually compiled/ran;
- what profiling/testing evidence exists;
- what limitations remain.

AI-generated code should be understandable enough to debug and maintain. If no responsible maintainer can explain a critical system, it is not ready merely because it works once.

## Development AI vs runtime AI

Keep these separate.

### Development-time AI

AI used by the team/agents to make T.O.O.N. faster and better.

This can be pervasive and does not need to be a player-facing feature.

### Runtime/player-facing AI

AI used inside T.O.O.N. for creative proposals, generated text/art, simulation assistance, or other player-facing behaviour.

Runtime AI must remain behind game-owned contracts and data models. Provider-specific APIs must not own the game domain.

Manual/non-AI paths should remain possible for proof-critical gameplay unless a future explicit design decision changes that boundary.

## AI provenance and reproducibility

For important generated content or code, prefer preserving:

- source prompt/context where useful;
- generating tool/model/provider when operationally relevant;
- generated artifact version;
- human edits/approval state;
- deterministic source data where possible.

Do not require heavyweight provenance for every trivial asset. Apply it where reproducibility, ownership, licensing, debugging, or game continuity materially benefits.

## Unreal learning discipline

Because this is the owner's first Unreal project, do not optimize only for short-term agent speed.

When a task introduces a core Unreal concept, implementation should leave enough explanation/evidence to make the concept reusable later.

Prefer learning through real T.O.O.N. requirements rather than isolated tutorial architecture.

Priority concepts likely include:

- Unreal project/module structure;
- C++/Blueprint boundaries;
- object ownership and garbage collection;
- reflection and serialization;
- delegates/events;
- Data Assets/Data Tables where appropriate;
- subsystems and lifecycle;
- UI;
- save/persistence;
- async work;
- asset references/loading;
- profiling;
- packaging.

Multiplayer/replication, Gameplay Ability System, Mass, or other major frameworks should not be introduced merely for résumé breadth. Add them only if T.O.O.N. develops a genuine requirement.

## First Unreal proof

The first Unreal milestone should be deliberately small:

1. clean Unreal project bootstrap;
2. reproducible build/open instructions;
3. one T.O.O.N.-owned C++ module;
4. one serializable studio state;
5. 2–3 professionals represented by data;
6. one relationship/production event;
7. one simple player decision;
8. visible consequence in UI/world;
9. save/reload;
10. packaged or standalone run if practical for the milestone.

This is an engine/architecture proof, not the full vertical slice.

## Validation rule

Never claim Unreal competence from repository conversion alone.

Meaningful validation requires exercised evidence such as:

- editor opens;
- project compiles;
- relevant automated/manual test runs;
- save/load works;
- representative gameplay interaction works;
- profiler/build/package evidence where claimed.

The project should make AI leverage visible as an advantage while keeping human technical ownership equally visible.
