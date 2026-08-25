# InkTime

InkTime is an independent Unity game about creating and developing fictional comic IPs. The player builds characters, relationships, lore, and stories, then turns them into publications ranging from short strips to longer comics through manual authorship, AI assistance, or a combination of both.

AI is a creative tool inside InkTime, not the definition of the game. The renewed design keeps player authority over authored text, canon, composition, and publication.

## Current status

- **Product/design direction:** Accepted direction; Documented.
- **Continued development:** Planned through the roadmap and GitHub Issues.
- **Existing implementation:** treat conservatively as **Scaffolded** until the historical Unity project is audited and specific workflows are exercised.
- **Renewed IP/comics workflow:** not yet claimed as implemented.
- **Manual/AI/Hybrid authorship:** planned; implementation must use one structured script model.
- **Digital PDF export:** planned; print-ready publishing is explicitly out of scope until separately designed and validated.
- **Loomlight Flux migration:** planned for evidence-driven audit/migration; the repository still contains legacy YJack/YJackCore coupling.

InkTime currently targets Unity `6000.3.13f1`. The project still references the historical `Assets/YJackCore` submodule and contains legacy project/package baggage, so reproducibility and framework migration are the first development gates.

## Canonical project documents

- [Design direction](docs/design.md) — accepted game-design direction, domain model, authorship model, publication model, continuity, PDF export, vertical slice, and non-goals.
- [Development roadmap](docs/roadmap.md) — ordered recovery, implementation, and validation plan.
- [Agent instructions](AGENTS.md) — evidence, ownership, framework, Unity, and validation rules for work in this repository.
- [GitHub Issues](https://github.com/YvesAlbuquerque/InkTime/issues) — executable work queue.

## Core direction

The intended long-term creative loop is:

`Create/develop IP -> Develop characters and lore -> Conceive story -> Write script -> Compose pages and panels -> Produce art and lettering -> Publish -> Audience/world reacts -> IP evolves -> Next story`

The minimum renewed vertical slice focuses on the portion we can validate first:

`Create IP -> Characters/relationships/lore -> Create Strip or Comic -> Manual/AI/Hybrid script -> Compose pages/panels -> Produce readable publication -> Export PDF -> Publish into IP history -> Approve continuity changes -> Save/reopen`

## Domain shape

The long-term content hierarchy is conceptually:

`IP -> Series -> Story/Arc -> Publication -> Script -> Pages -> Panels`

A strip is therefore one publication format, not the root of the design. Longer-form comics share the same underlying authored/publication model where practical.

Characters, relationships, and canon/lore are persistent game entities. Published work can update continuity, but early implementations should keep those changes inspectable and player-approved.

## Authorship

InkTime supports three intended modes:

- **Manual** — direct editing of the structured script.
- **AI** — AI proposes/generates script material using bounded relevant IP context.
- **Hybrid** — the player writes while requesting local assistance such as alternatives, rewrites, continuation, expansion, condensation, or panel splitting.

All modes must operate on the same canonical script. Do not build separate manual and AI production pipelines.

## Export

The structured publication remains the source of truth. PDF is a downstream export renderer for completed work.

The first export target is a digital-reading PDF. Print-ready concerns such as bleed, trim, DPI, colour management, font embedding/licensing, and printer validation are deferred.

## Repository and framework boundaries

InkTime owns game-specific design, code, content, configuration, builds, and playable evidence.

YFramework owns shared Polite Goblin/Loomlight terminology, cross-repository decisions, The Y Framework methodology, and canonical status vocabulary.

Loomlight Flux is the canonical reusable Unity gameplay framework and low-code authoring substrate. InkTime still contains legacy YJack/YJackCore references; migration is a planned technical task and must not be described as complete until validated in this project.

## Immediate next step

Recover a trustworthy Unity baseline: audit repository hygiene and packages, remove or replace machine-local dependencies, inventory InkTime-specific code/assets and YJackCore coupling, then produce an evidence-backed migration plan toward Loomlight Flux before broad feature implementation.
