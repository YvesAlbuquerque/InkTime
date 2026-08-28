# InkTime Design Direction

**Decision date:** 2026-08-26  
**Status:** Accepted direction; Documented  
**Implementation status:** Do not infer implementation from this document. See repository code, tests, Issues, and branch state.

## Product statement

InkTime is a game of creating and developing fictional comic intellectual properties. The player builds universes, characters, relationships, lore, and stories, then turns those elements into publications ranging from short strips to longer comics using human authorship, AI assistance, or a combination of both.

The game is not defined by AI generation. AI is one creative tool available inside a broader authorship, production, publishing, and continuity-management game.

## Accepted changes from the previous direction

The renewed direction changes InkTime in four important ways:

1. **Strips are a publication format, not the whole product.** InkTime must support longer-form comics as part of the same creative system.
2. **The IP becomes a central persistent game entity.** Characters, relationships, worldbuilding, history, and canon must survive across individual publications.
3. **Manual authorship becomes a first-class mode.** Players must be able to write scripts directly rather than being forced through AI generation.
4. **Publications can be exported as PDF.** The game should allow players to keep and share completed work outside the game, while preserving the structured internal representation as the source of truth.

## Design pillars

### Persistent fictional IP

The rewarding object is not an isolated generated strip. It is a fictional property that can accumulate identity and history over time.

An IP should eventually be able to hold:

- premise and creative identity;
- tone and visual direction;
- characters;
- character relationships;
- locations and factions;
- lore/canon facts;
- series and story arcs;
- publication history;
- continuity changes caused by published stories.

The first playable slice should implement only the minimum subset required to make persistence meaningful.

### Authorship with player authority

InkTime supports three authorship modes:

- **Manual** — the player writes and edits the structured script directly.
- **AI** — an AI system proposes or generates script content using relevant IP context.
- **Hybrid** — the player writes while invoking bounded assistance such as alternatives, dialogue rewrites, continuation, expansion, condensation, or panel splitting.

All three modes must produce the same canonical structured script. There should not be separate manual and AI content pipelines.

The player retains final authority over authored text, canon, composition, and publication.

### Publication as production

A publication is produced from structured story material rather than treated as a single opaque generation result.

The production model should support:

`IP -> Series -> Story/Arc -> Publication -> Script -> Pages -> Panels`

Not every level must be exposed in the first vertical slice. The model should, however, avoid making a strip-specific data structure the permanent foundation of the game.

### Continuity creates long-term play

Characters and lore should evolve across work. A publication can create new canon facts, alter relationships, establish events, or change character state.

Continuity changes must remain inspectable and attributable to the publication that introduced them. This gives the player an accumulating fictional history rather than a sequence of disconnected generations.

## Core loop

The intended long-term loop is:

`Create or develop IP -> Develop characters and lore -> Conceive story -> Write script -> Compose pages and panels -> Produce art and lettering -> Publish -> Audience/world reacts -> IP evolves -> Create next story`

The first vertical slice does not need the full audience or market simulation. It needs to prove that an IP can persist through more than one authored publication cycle.

## Domain model

### IP

The top-level creative property. It owns identity, high-level creative constraints, persistent fictional knowledge, and publication history.

Minimum useful fields for the first slice may include:

- identifier;
- title;
- premise;
- tone/style notes;
- characters;
- relationships;
- canon/lore facts;
- publications.

### Character

A persistent fictional person or entity, not prompt-only context.

Useful fields may include:

- name and identity;
- appearance notes;
- personality;
- goals;
- conflicts;
- narrative role;
- relationships;
- history/state relevant to continuity.

The first slice should avoid simulation-heavy character systems until persistent authorship proves value.

### Relationship

A persistent relation between characters or other relevant entities. Relationships should be able to change over time and, where useful, record why they changed.

### Lore / Canon Fact

A small, explicit continuity unit such as an event, rule, fact, place, relationship change, or established piece of history.

For the initial implementation, a canon fact should be simple enough to inspect, edit, attribute to a source publication, and include selectively in AI context.

### Series and Story/Arc

These organize longer creative work. A first slice may omit complex arc tooling while retaining data-model room for stories that extend beyond a single strip.

### Publication

A concrete publishable work derived from the IP.

Initial format support:

- **Strip** — short-form publication, normally a small number of panels/pages.
- **Comic** — longer-form publication with multiple pages and panels.

The data model may later distinguish forms such as one-shot, issue, chapter, or collection if gameplay requires it.

### Script

The canonical authored narrative representation shared by Manual, AI, and Hybrid modes.

Conceptually:

`Story -> Page -> Panel`

A panel can contain structured narrative material such as:

- action/description;
- participating characters;
- dialogue;
- captions;
- production/art notes where appropriate.

The script must remain editable after AI assistance.

### Page and Panel

Pages and panels are compositional units that connect script content to finished publication layout, art, balloons, captions, and visual sequencing.

The page/panel system should work for both strips and longer comics instead of duplicating layout pipelines by format.

## AI assistance model

AI should consume bounded, relevant context rather than an undifferentiated lore dump. Depending on the operation, useful context can include:

- IP premise and style/tone guidance;
- participating characters;
- relevant character relationships;
- relevant canon facts;
- current story/arc context;
- current publication brief;
- neighbouring script material.

AI outputs are proposals until accepted by the player.

Useful Hybrid actions include:

- continue a scene;
- propose alternatives;
- rewrite dialogue while preserving intent;
- expand or condense a beat;
- split narrative into panels;
- suggest captions;
- identify possible continuity conflicts;
- propose story beats from existing IP state.

Provider/runtime choices are implementation details behind InkTime-owned contracts and must not become the game-domain model.

## Manual authorship

Manual authorship is not an escape hatch from the game. A manually written script should continue through the same systems for page/panel composition, production, publication, export, continuity, and progression as an AI-assisted script.

The manual editor should therefore operate directly on the canonical structured script rather than producing a separate free-text artifact that later needs a different pipeline.

## Art, lettering, and composition

The renewed direction requires a structured path from script panels to finished visual pages, but does not yet choose a single art-generation strategy.

The system should preserve boundaries between:

- narrative/script data;
- visual assets;
- layout/composition;
- lettering/captions;
- AI or deterministic generators;
- export rendering.

This keeps manual, imported, procedural, and AI-assisted art options open without redefining the publication model.

## Canon and publication history

Publishing a work should create a durable history entry for the IP. Where a story establishes continuity, accepted changes should become explicit canon/lore entries or state changes rather than only remaining buried in generated text.

For early versions, prefer player-reviewed continuity updates over autonomous extraction and mutation.

## Persistence

The persistent save representation should support stable identifiers and versioning/migration so an IP can survive schema evolution.

The first slice must persist at least:

- IP identity;
- characters;
- relationships;
- canon facts;
- publications;
- structured scripts;
- page/panel structure;
- enough asset references to reopen authored work.

Do not use PDF as persistence.

## PDF export

PDF is an export target for a completed publication, not the canonical storage model.

Initial target: a digital-reading PDF generated from the structured publication/page representation.

The exporter should be downstream of the same page composition used by the game so exported work matches the authored publication as closely as practical.

Possible later exports include page images, CBZ, or web-oriented formats. These are future capabilities, not current commitments.

Print-ready production is explicitly deferred until requirements such as bleed, trim, DPI, colour management, font embedding/licensing, and printer validation are designed and tested.

## Progression and simulation

InkTime can eventually make publication consequences part of the game: audience response, reputation, trends, commercial choices, editorial constraints, recurring characters, franchise growth, or creative tensions.

These systems are not required to prove the renewed authoring/IP loop and should not block the first vertical slice.

## First vertical slice

The minimum coherent target is:

1. create or open one IP;
2. create persistent characters and relationships;
3. maintain a small set of editable canon/lore facts;
4. create a `Strip` or `Comic` publication;
5. author the same structured script manually or with AI assistance;
6. compose pages and panels;
7. produce a viewable publication using the current feasible art/lettering path;
8. export the publication to a digital PDF;
9. register the publication in IP history;
10. apply player-approved continuity changes and reopen the IP with those changes persisted.

A vertical slice is not **Validated** until the complete workflow is exercised and its evidence is recorded.

## Explicit non-goals for the first slice

Do not make the first renewed slice depend on:

- large-scale fandom/community simulation;
- sophisticated market/economy simulation;
- licensing and franchise management;
- film/animation adaptations;
- a giant wiki-like lore editor;
- autonomous canon mutation without player review;
- print-ready publishing;
- a specific external AI provider;
- proof that Loomlight Game Studio or Loomlight Nexus integration exists;
- migration of every historical InkTime/YJack asset before the playable loop can be validated.

## Relationship to Polite Goblin and Loomlight

InkTime is an independent game repository.

- YFramework owns shared doctrine, terminology, cross-repository decisions, The Y Framework methodology, and canonical status vocabulary.
- Loomlight Flux owns reusable Unity framework implementation.
- Loomlight Game Studio may eventually orchestrate production work around the game, but that does not make Game Studio the owner of InkTime's game design or implementation.
- Loomlight Nexus participation is optional and must not be assumed from AI features in InkTime.

## Validation questions

The renewed direction should be tested against concrete questions:

- Does creating an IP make later stories meaningfully easier or richer than generating isolated strips?
- Can a player create a complete publication without using AI?
- Can AI assistance use persistent context without taking authorship control away from the player?
- Can one data model support both a strip and a multi-page comic without parallel pipelines?
- Can a published work update continuity in a way the player can understand and control?
- Can a saved IP be reopened and continue from its previous fictional state?
- Can the finished publication be exported to a readable PDF that preserves the authored layout?

These questions define the validation target more strongly than raw feature count.
