# T.O.O.N. — The Office Of Nonsense — Development Roadmap

**Rebased:** 2026-11-13  
**Design dependency:** [T.O.O.N. Design Direction](design.md)  
**Roadmap status:** Planned  
**Former project names:** InkTime / Ink Through Time

This roadmap preserves validated/recovered technical work while rebasing future game work around the accepted historical living-studio direction.

## Sequencing principles

- Preserve evidence already earned; do not pretend the repository started over.
- Treat the studio as the long-lived protagonist.
- Do not expand historical comic-specific architecture merely because scaffold code exists.
- Re-evaluate useful legacy calendar, employee, economy, equipment, and era concepts against the new design instead of automatically discarding them.
- Keep persistent IP and save compatibility where useful.
- Treat professionals as recurring agents with careers, relationships, demands, outside lives, and explicit longevity models.
- New media expand the studio's options; they do not automatically obsolete old media.
- Validate one characteristic studio/people/production interaction before attempting a full 1900–2030 campaign.
- Preserve Unity serialization/GUID/`.meta` evidence until migration intentionally removes it; do not confuse preservation with continued Unity development.
- Treat Unreal bootstrap as a separate proof before porting broad gameplay.
- Never claim implementation or validation from documentation alone.

## Phase 0 — Recovered technical baseline

### 0.1 Reproducible Unity baseline — completed evidence

Issue #2 / associated merged work established the current Unity baseline and documented historical limitations.

### 0.2 Loomlight Flux audit — completed evidence

Issue #3 / PR #25 documented the host/framework boundary.

### 0.3 Scoped Flux host upgrade — completed historical evidence

Issue #4 / PR #26 validated the bounded Unity/Flux host upgrade at the recorded Flux pin. This remains historical migration evidence; it does not define the target Unreal architecture.

### 0.4 Unreal bootstrap — planned

Unreal Engine is now the accepted target engine. Before porting broad gameplay, prove:

- a clean Unreal project bootstrap;
- exact engine version recorded after validation;
- reproducible open/build instructions;
- one T.O.O.N.-owned C++ module;
- one serializable studio state;
- one simple relationship/production decision;
- visible consequence;
- save/reload;
- standalone/package evidence where practical for the milestone.

Do not claim the migration complete because a `.uproject` exists.

See `docs/unreal-ai-development-strategy.md`.

## Phase 1 — Creative identity and representative proof

### 1.1 Accepted concept

Accepted direction now includes:

- **T.O.O.N. — The Office Of Nonsense** as current project/public name;
- studio/company fantasy as the primary frame;
- campaign target approximately 1900–2030;
- media evolution from text/illustration through strips/comics, animation, digital and 3D/realtime-era production;
- persistent IPs that can cross media;
- recurring professionals with agency, relationships and outside lives;
- mixed character longevity, including mortal, long-lived, cartoon-static and rule-bound existence models;
- management of people, productions, studio/economy and technology as coupled systems;
- historical archive/legacy as a major campaign payoff.

Commercial/legal name clearance remains unresolved and separate.

### 1.2 Representative visual target

Minimum visual target:

- one small early-era T.O.O.N. office;
- 3–4 distinct professionals;
- at least one immortal/static cartoon and one mortal character;
- visible relationship tension or affinity;
- one active production;
- a production board/decision surface;
- institutional **Office** language plus visible **Nonsense**;
- one retained historical object/trace suggesting future continuity.

**Exit evidence:** owner-reviewed visual/interactive artifact with recorded corrections.

### 1.3 World-start and language proof

Prototype the campaign opening as a bounded world/location selection.

Minimum proof:

- world/globe presentation;
- choose one of a small validated set of starting locations;
- starting location supplies a default studio/world language;
- one production inherits a default production language;
- interface/subtitle language remains independently selectable;
- character dialogue can display/voice in the studio language while management UI stays understandable in the player's UI language.

Do not require a complete historical world simulation.

Any location-specific economic, cultural, technology or legal modifiers must be backed by researched data before being treated as factual gameplay rules.

## Phase 2 — Unreal domain foundation

All new target implementation in this phase is Unreal-owned. Port concepts, not Unity architecture by default.

Professional evidence should emerge naturally from game requirements: C++ ownership, Unreal reflection/serialization, data-driven authoring, Blueprint boundaries, save/persistence, UI, profiling and debugging where relevant.

AI may accelerate implementation heavily, but generated code/assets are not validation evidence.

### 2.1 Continuous simulation clock and working-day proof

Prove a bounded management clock before long-era simulation.

Minimum behaviour:

- simulation time advances continuously at normal speed;
- at least one player-selected accelerated speed exists;
- when nobody is actively working, low-value downtime automatically fast-forwards toward the next meaningful work period/event;
- fast-forward returns to normal speed before a relevant event, the next work shift or a required player decision;
- opening the main `Esc` menu pauses simulation;
- construction/build mode pauses simulation;
- a Decision Event or other choice/read pop-up pauses simulation while presented;
- a professional visibly arrives, works/socializes/rests and leaves;
- off-site time is compressed/abstracted rather than fully simulated;
- no real-world/background progression occurs while the game is closed.

Validate pacing before selecting final day length, fast-forward threshold or speed multipliers.

### 2.2 Autonomous social interaction proof

Prove one ordinary social interaction that does not require a direct player command.

Minimum path:

`simulation chooses interaction -> speech-bubble dialogue -> bounded AI output or deterministic fixture -> structured outcome -> game-owned state change`

Requirements:

- ordinary conversation is presented primarily through comic-style speech bubbles;
- reaction/emotion audio may support the interaction without fully voiced generated dialogue;
- the interaction may occur outside the player's camera and be missed;
- AI/provider output cannot directly write relationship or morale values;
- the game owns allowed outcomes and magnitude;
- one relationship change is legible through high-level Bond/Affection and Trust indicators, qualitative sentiments and causal history;
- the underlying simulation can retain precise directional values without displaying raw numbers by default;
- deterministic fixtures remain available for tests/provider-unavailable cases.

### 2.3 Decision Event escalation proof

Prove one parameterized Decision Event archetype driven by emergent simulation state.

Minimum path:

`ordinary social/production state -> escalating condition -> optional ! attention marker -> owner-required threshold -> auto-pause -> structured choice -> deterministic consequence`

Requirements:

- the event exists because studio-owner authority is required;
- the player may act preventively through normal management before escalation;
- no abstract “prevent event” action exists;
- warning state is observable for an escalating event;
- sudden events may bypass warning when appropriate;
- event roles/options/consequence bounds are authored;
- AI may contextualize dialogue but cannot invent rule consequences;
- the event is presented even if the player was observing another area.

### 2.4 Owner-initiated management conversation proof

Prove one direct conversation initiated by the studio owner.

The player selects a structured intent such as:

- listen;
- praise;
- feedback;
- warn;
- workload discussion;
- expectations/career discussion.

Requirements:

- no unrestricted free-text dialogue input;
- AI may dramatize the selected intent;
- outcomes remain bounded and game-owned;
- the result can affect a relevant professional/relationship state;
- the interaction reads as management rather than direct Sim-style puppeteering.

## Phase 3 — Persistent studio and people foundation## Phase 3 — Persistent studio and people foundation

### 3.1 Revalidate persistent IP foundation

The merged minimum IP model remains directionally useful. Revalidate it against:

- cross-media adaptation history;
- persistent characters/properties;
- production/release history;
- long campaign timescale.

### 3.2 Minimal Professional model

Implement the smallest serializable professional model needed for the proof:

- stable identity;
- role/discipline;
- visual/species/archetype identity reference;
- compact skill representation;
- morale;
- creative energy;
- discipline;
- wildness/experimentation;
- current assignment/state;
- salary/credit expectations where gameplay requires them;
- longevity/existence model;
- career/history hooks.

### 3.3 Minimal Relationship model

Prove a directional relationship representation with only the dimensions needed for the first slice.

Candidate internal dimensions:

- affection/bond;
- trust;
- tension;
- rivalry;
- fear;
- attraction where appropriate.

The first player-facing proof should use a **hybrid visibility model**:

- a small number of readable high-level bars such as Bond and Trust;
- at least one qualitative sentiment/tag;
- a short causal history explaining why the state changed;
- no requirement to expose exact raw numeric values;
- directional asymmetry visible for A->B vs B->A where it creates a meaningful difference.

The proof must show one relationship affecting a production decision or outcome and let the player understand the causal path.

### 3.4 Outside-life hooks

Implement a bounded event source for off-screen life without simulating a full city.

First proof should support one outside-life condition affecting attendance, energy, relationship or production state.

### 3.5 Versioned persistence

Define Unreal-owned versioned persistence for current T.O.O.N. domain state.

Legacy `InkTime` data is migration source evidence, not an automatic compatibility requirement. Preserve a representative fixture or extraction path only if it materially helps recover useful authored/state data.

**Exit evidence:** current Unreal save/reload survives schema-relevant changes; any claimed legacy import is exercised explicitly.

## Phase 4 — First production-management proof

### 4.1 Medium-neutral Production model

Avoid hard-coding the first proof exclusively around animation.

The minimum production representation should support:

- medium/type;
- IP reference;
- crew;
- schedule;
- budget;
- creative/quality state;
- release/result;
- persistent consequences.

Detailed media-specific structures should be adapters or submodels introduced only when required. Do not require full manual DCC authoring for every medium; deterministic fixtures can prove the core production contract while runtime AI supplies representative media where appropriate.

### 4.2 One people/production conflict

Implement one causally legible production problem driven by people.

Examples:

- creative disagreement;
- predatory/prey tension;
- demand for credit;
- salary dispute;
- exhaustion from outside life;
- refusal to work with another employee;
- highly talented but unreliable employee;
- sudden absence.

### 4.3 Player tradeoff

The player must receive at least two materially different responses that trade among:

- schedule;
- money;
- morale;
- creative potential;
- relationship state;
- risk of departure;
- production quality.

### 4.4 Release and durable consequence

Completing the production should alter at least one of:

- studio state;
- professional state;
- relationship state;
- IP history;
- future opportunity.

Save/reopen must preserve it.

## Phase 5 — Historical time and generations

### 5.1 Calendar/era reinterpretation

Audit the legacy calendar/era scaffold.

Do not restore old fixed-era behaviour blindly. Keep only patterns that support the new campaign.

The calendar must eventually support:

- long-form year progression;
- era/media availability;
- staff aging where applicable;
- retirement/death where applicable;
- immortality/static-age models;
- historical archive timestamps.

### 5.2 Career progression

Prove bounded career progression such as:

`Recruit -> Junior -> Experienced -> Veteran -> Legend -> Retired`

Not every character uses every stage. Immortal/static cartoons may accumulate influence and history without aging normally.

### 5.3 Mortality and longevity

Implement existence rules as explicit data/behaviour, not species hard-coding.

Minimum models to prove:

- Mortal;
- Cartoon-static.

Later candidates:

- Long-lived;
- Conditional/rule-bound.

### 5.4 Succession and institutional memory

Demonstrate one long-term consequence in which:

- one employee leaves/retires/dies; and/or
- one immortal/static employee persists;

and the studio retains their influence through history, relationships, IP credit, mentorship or archive evidence.

### 5.5 Historical-context data proof

Before attempting a full historical database, implement a small sourced context set for one location and one bounded period.

The proof should include:

- at least one global timeline entry;
- at least one local/country timeline entry;
- explicit date/geographic scope;
- source/provenance metadata;
- separation between factual data and game-design interpretation;
- one professional state affected by context;
- one production prompt/context package affected by context;
- one reception result that explains how historical/market context contributed.

Runtime AI must consume only approved structured context for historical facts. Do not permit unsourced historical invention to become simulation state.

### 5.6 Reception model proof

Prototype a legible reception model combining several factors rather than direct historical modifiers.

Candidate inputs:

- production quality/craft;
- audience/market fit;
- historical context;
- medium and available technology;
- studio reputation;
- distribution/reach;
- novelty/timing;
- uncertainty.

The result should expose a human-readable explanation of the strongest contributing factors.

## Phase 6 — Media evolution

### 6.1 First media transition

Do not attempt the whole history.

Prototype one transition, for example:

`text/illustration -> strip`

or:

`comic -> early animation`

The transition should require at least one meaningful change in:

- staffing;
- equipment/facility;
- cost;
- workflow;
- opportunity;
- creative possibility.

### 6.2 Technology adoption choice

Prove one early-vs-late adoption tradeoff.

New technology should carry advantages and costs rather than a flat upgrade.

### 6.3 Cross-media IP adaptation

Adapt one persistent IP into a second medium and preserve the relationship between versions.

**Exit evidence:** archive/history can show both works as part of one property lineage.

### 6.4 Cross-media identity consistency proof

Before broad adaptation support, prove that one persistent IP/character remains recognizably continuous across two media.

The proof should preserve:

- stable IP/character identifiers;
- canonical visual/narrative anchors;
- explicit adaptation changes;
- provenance/reference artifacts used by runtime generation;
- player-readable lineage in the archive.

Do not treat provider-specific seeds/prompts as the canonical identity source.

### 6.5 Compact production-output validation


Before scaling content generation, validate representative output sizes.

Initial targets:

- text: one-screen / a few hundred words at most;
- strip: **3–4 panels**;
- short comic: **1–4 pages**;
- animatic: roughly 20–90 seconds;
- 2D animation: roughly 30–120 seconds;
- 3D/realtime short: roughly 30–120 seconds.

Measure separately:

- player consumption time;
- runtime generation time/cost;
- in-game production time;
- archive/storage footprint;
- quality consistency;
- whether the work feels complete enough to remember/share.

Do not equate content duration with in-game production complexity.

### 6.6 Shareable production artifact

Prototype a provider-neutral export/share contract for at least one completed work.

The first proof should support:

- final artifact export;
- title/year/credits metadata;
- thumbnail/poster/share card where relevant;
- optional generated caption;
- explicit player approval before export/share;
- no private save-state leakage.

Direct posting to specific social networks is optional and should come later behind adapters rather than becoming a core dependency.

## Phase 7 — Studio economy and organization

### 7.1 Economy

Re-evaluate legacy cash/salary/bankruptcy ideas.

The first renewed economy should support production and people choices without becoming a spreadsheet-only game.

Candidate pressures:

- salaries;
- equipment investment;
- facility expansion;
- production budget;
- training;
- technology adoption;
- failed releases.

### 7.2 Departments, facilities and physical growth

Grow from one-room office toward specialized rooms, departments and larger premises only after the first production proof works.

Facilities should change what the studio can do, not exist as decorative unlocks.

The studio-growth proof should eventually distinguish:

- production infrastructure;
- shared amenities;
- professional-facing props/personalisation;
- archive/history objects;
- pure visual decoration.

At least one non-production object should affect a professional differently based on their preferences/state rather than providing a universal flat bonus.

### 7.3 Workplace environment and preferences

Prototype lightweight environmental preferences before building a large furnishing simulation.

The first proof should test a small set such as:

- quiet vs social space;
- old vs new technology preference;
- clutter tolerance;
- privacy/status preference;
- one specific personal object/amenity.

Validate whether environmental choices produce readable effects on morale, recovery, creativity, concentration, or relationships without forcing excessive furniture micromanagement.

### 7.4 Employee bargaining and agency

Introduce:

- raises;
- promotions;
- credit;
- role requests;
- refusals;
- resignations;
- return/re-hire opportunities.

The studio should have to retain talent rather than simply own it.

## Phase 8 — Presentation and historical continuity

### 8.1 Evolving studio world

Validate visible studio transformation across at least two time periods.

### 8.2 Character presentation

Validate:

- strong silhouettes;
- profession;
- personality;
- relationship promise;
- longevity distinction;
- era-sensitive presentation without flattening identity.

### 8.3 Institutional history

Use:

- boards;
- posters;
- awards;
- photographs/portraits;
- archived productions;
- retired equipment;
- renamed rooms;
- memorials or preserved desks;
- employee credits;

to make past decisions visible in the present.

## Phase 9 — Integrated vertical-slice validation

Required workflow:

`Open studio -> recurring crew -> one relationship pressure -> one IP -> one production -> assignment/tradeoff -> release -> durable consequence -> save/reopen`

The first integrated slice does **not** need to span the full campaign.

Record:

- Unreal Engine/editor version;
- exact branch/commit;
- setup;
- commands/tests actually run;
- representative visual evidence;
- save/reload result;
- known failures and limitations.

Only exercised scope may move to **Validated**.

## Campaign-length validation

The accepted design target is approximately **40 hours for a complete 1900–2030 campaign**, including time spent managing the studio and consuming completed productions.

Do not tune pacing from calendar math alone. The current conceptual average is about **3.25 in-game years per real-time hour**, but the real validation target is experiential:

- early eras should establish the studio without dragging;
- media transitions should feel meaningful;
- people/relationship stories need time to develop;
- later productions may justify more player attention;
- watching/reading produced work counts toward campaign time;
- optional archive review can extend beyond the core target.

Once a representative production pipeline exists, measure:

- real time per in-game decade;
- real time per production type;
- management time vs production-review/consumption time;
- skip/revisit behaviour;
- frequency of meaningful people events;
- whether 40 hours produces enough generational and media change to feel like a century-scale history.

## Phase 10 — Historical campaign proof

After the vertical slice is stable, prove a bounded multi-era campaign containing:

- at least one technology/media transition;
- at least one mortal career transition;
- at least one persistent immortal/static employee;
- one IP adapted across media;
- visible archive/history accumulation;
- at least one produced work the player can actually read/view/watch;
- measured real-time pacing for management plus production consumption.

Only then should the project expand toward a full 1900–2030 campaign.

## Deferred until proofs earn expansion

- every historical medium;
- deep city simulation;
- complete family simulation;
- hundreds of relationship variables;
- large fandom/community systems;
- feature-film-scale production depth;
- complete animation DCC functionality;
- large autonomous AI pipelines;
- unproven Game Studio/Nexus integrations;
- aggressive technical identifier renames without migration evidence.

## Technical rename work

The public name is accepted and the GitHub repository route is now `YvesAlbuquerque/TOON`. Remaining compatibility-sensitive identifiers require a bounded migration:

- `Assets/InkThroughTime/` path;
- `InkThroughTime.*` namespaces and asmdefs;
- `InkGameRoot`, `InkSaveService`, and other legacy type names;
- `InkTime` save/artifact directories;
- old local skill names/paths;
- serialized references and downstream docs.

Do not claim these migrated until the Unreal replacement path is exercised and any retained compatibility/data migration is tested. Unity compile evidence remains historical evidence, not Unreal validation.
