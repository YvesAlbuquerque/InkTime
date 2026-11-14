# T.O.O.N. — The Office Of Nonsense — Design Direction

**Decision date:** 2026-11-09  
**Expanded:** 2026-11-13  
**Status:** Accepted direction; Documented  
**Former project names:** InkTime / Ink Through Time  
**Implementation status:** Do not infer implementation from this document. See code, tests, Issues, branch state, builds, and playable evidence.

## Product statement

**T.O.O.N. — The Office Of Nonsense** is a historical creative-studio management game about building one eccentric company across more than a century of changing media.

The player begins with a tiny office around 1900, hires generations of creative professionals, develops persistent fictional properties, manages money and production, and adapts as the studio expands from text and illustration into strips, comics, 2D animation, television/digital production, and eventually 3D/realtime-era work.

The studio is the long-lived protagonist. Productions, employees, relationships, technologies, facilities, and IPs change around it.

T.O.O.N. is not a professional animation-authoring application and is not defined by AI generation. It is a management simulation about keeping creative nonsense alive long enough to ship it.

## Naming decision

The owner selected **T.O.O.N. — The Office Of Nonsense** as the current game name.

The acronym and expansion are intentional:

- **T.O.O.N.** evokes cartoon media;
- **The Office** represents organization, departments, deadlines, budgets, contracts, and responsibility;
- **Of Nonsense** represents creative risk, exaggeration, humour, invention, and the unreliable personalities that make the work.

The central creative tension is:

> **Office gives nonsense structure. Nonsense keeps the office worth running.**

The name remains **Accepted direction, not commercially cleared**. Existing collision risk must remain explicit until proper clearance.

## Player dream

> Start with a room, a few strange people and a handful of ideas. Build T.O.O.N. across generations of media, survive the people and technologies that transform it, and leave behind a studio history that belongs to your campaign.

The player should want to say:

- “this is **my studio**”;
- “these are **my people**”;
- “we made **that**”;
- “that character has existed here for eighty years”;
- “this employee changed the company”;
- “this disaster became part of our history.”

## Principal pillar

### Doing — managing creative chaos

The primary play is choosing how to allocate people, money, time, creative freedom, technology, and organizational attention under uncertainty.

### Emotional payoff — attachment and legacy

The player should become attached to:

- the studio as an institution;
- recurring professionals;
- their relationships and careers;
- persistent IPs and characters;
- memorable productions;
- the visible history accumulated across decades.

## Soul rule

> **Every production and every person can change the office that made them.**

Consequences should persist in some combination of:

- studio finances and facilities;
- professional happiness, careers, relationships, absences, departures, or legacy;
- IP history, canon, audience recognition, and adaptation opportunities;
- technology and workflow choices;
- reputation and future opportunities;
- the studio archive.

## World opening, starting location and language

A new campaign should begin by presenting the world before presenting the studio.

The preferred opening direction is an interactive **globe/world view** around the campaign start date, from which the player chooses where T.O.O.N. begins.

The initial choice may be:

`World -> country/region -> city -> first studio`

The exact geographic granularity remains a design/production decision. The first implementation does not need every city on Earth.

### Starting location

Starting location should be a meaningful campaign input rather than cosmetic flavour.

It can influence, where supported by data and content:

- initial spoken/studio language;
- default language of produced works;
- available local talent;
- salary/rent and operating-cost pressures;
- initial audience/market;
- cultural opportunities and constraints;
- access to technologies/media;
- local professional networks;
- later expansion opportunities.

Real-world historical differences must not be invented casually. Any factual country/city/era modifiers require researched, reviewable data before becoming canonical gameplay rules.

### Language layers

Separate language into at least three concepts:

1. **Interface language** — menus, settings, tutorials and accessibility text.
2. **Studio/world language** — what professionals normally speak in the chosen location.
3. **Production language** — the language in which a particular work is created/released.

Starting location should set sensible defaults for studio/world and production language.

It may also suggest the interface language at first launch, but **the player must be able to change UI language independently**.

This allows examples such as:

- UI in Portuguese, studio in Tokyo, characters primarily speaking Japanese;
- UI in English, studio in Rio de Janeiro, productions primarily in Portuguese;
- a multilingual studio later creating a production in a language different from its home market.

### Dialogue and accessibility

Character dialogue can be voiced/spoken in the studio/world language while subtitles remain in the selected interface/subtitle language.

Where runtime voice generation is used, voice language/accent is part of the character/presentation layer and must remain separable from UI localization.

Do not make understanding the game's management systems depend on the player personally speaking the studio language.

### Productions and localization

A production should record its original language.

Later systems may support:

- subtitles;
- translation;
- dubbing;
- localized editions;
- multilingual staff;
- foreign distribution;
- remakes/adaptations for other markets.

These are expansion candidates, not first-slice requirements.

### Geographic growth

Starting location should not permanently trap the studio.

Later campaign possibilities may include:

- moving headquarters;
- opening branches;
- hiring internationally;
- co-productions;
- distributing work abroad;
- becoming a multinational creative studio.

These systems should be added only after the single-location studio loop is validated.

## Campaign and time

The target campaign spans approximately **1900–2030**. This is about 130 years of studio history, not 120; exact start/end dates and technology availability remain tunable design data rather than historical-simulation claims.

### Simulation clock and working day

T.O.O.N. should use a **continuous management-simulation clock** rather than advancing only when the player submits an action or ends a turn.

Accepted direction:

- time advances on its own during normal studio play;
- the player can manually accelerate simulation speed;
- when nobody is actively working, the game automatically fast-forwards through low-value downtime until the next meaningful work period/event;
- automatic fast-forward must stop before a relevant event, new work shift or player-required intervention, rather than skipping it;
- opening the main `Esc` menu pauses simulation;
- entering construction/build mode pauses simulation;
- pop-ups that require reading or a player choice, including Decision Events, pause simulation while presented;
- leaving/closing the game never advances campaign time in the background.

The goal is to preserve a living continuous studio without making the player wait through empty nights/weekends or lose time while making deliberate management/build decisions.

The visible studio day should matter.

Professionals can:

- arrive for work;
- perform assigned work;
- move through the studio;
- talk and socialize;
- eat/rest/use amenities;
- react to colleagues and the environment;
- leave at the end of their working day;
- arrive late, leave early or be absent when simulation state causes it.

T.O.O.N. should **not** become a full domestic-life simulation. Off-site life is represented primarily through state and events rather than a fully simulated city/home.

Nights, weekends and other low-interaction periods may be compressed, accelerated or skipped where that improves campaign pacing. The exact time scale and work calendar remain tuning parameters.

This creates a useful distinction:

`visible workplace simulation -> compressed off-site life -> persistent consequences back at work`

### Campaign-length target

The target for a first complete campaign is approximately **40 hours to the 2030 retrospective/end-state**.

This is a design target, not a guaranteed runtime claim. Validation must measure actual player pace once representative systems and generated productions exist.

At 1900–2030, a 40-hour campaign implies an average of roughly **3.25 in-game years per real-time hour**, but pacing should not be uniform. Early text/illustration/strip eras may move through time faster, while later productions can consume more real-time attention as teams, media and outputs become more complex.

The 40-hour budget includes more than management UI. It includes the player's time spent:

- running the studio;
- hiring, negotiating with and responding to professionals;
- making production and technology decisions;
- shaping/reviewing creative work;
- reading, viewing or watching completed T.O.O.N. productions;
- inspecting archive/history consequences;
- dealing with systemic events and relationships.

The campaign should feel like an evolving history of creative production, not a fixed linear tech tree.

### Media evolution

Potential media families include:

- text/humour writing;
- illustration/editorial art;
- strips;
- comics;
- early/silent animated work;
- sound and colour animation;
- television/serial production;
- digital 2D;
- hybrid digital production;
- 3D/CG;
- realtime/hybrid contemporary production.

Later media do not automatically invalidate earlier media. New capabilities expand the studio's options.

A 1970s T.O.O.N. may still publish comics. A 2020s T.O.O.N. may deliberately retain hand-drawn 2D while another department produces 3D work.

### Technology choice

Technology should create strategic choices, not passive unlock bonuses.

Early adoption may bring:

- high cost;
- training burden;
- workflow instability;
- competitive advantage;
- new creative possibilities.

Late adoption may bring:

- lower risk;
- lower cost;
- lost opportunities;
- staff frustration;
- audience or market lag.

## Historical context: global and local timelines

T.O.O.N. should treat real history as an active **context layer** around the player's fictional studio.

The campaign should maintain two coupled historical timelines:

1. **Global timeline** — major international events, technology shifts, economic cycles, media/market changes, wars, crises, cultural movements, communication/distribution changes, and other broadly relevant context.
2. **Local timeline** — country/region-specific events, market conditions, cultural movements, regulation, local technology/media adoption, labour conditions, economic shocks, and other context relevant to the chosen studio location.

The studio's own fictional history forms a third layer:

3. **Studio timeline** — hires, departures, relationships, productions, failures, successes, IP history, expansions, scandals, awards, technical transitions and other campaign-specific events.

The player should be able to understand these layers together:

`global history + local history + studio history -> creative context and market context`

### Historical events as structured context

Historical data should be represented as structured, sourced entries rather than free-form flavour text.

A historical-context entry may include:

- stable identifier;
- date or date range;
- geographic scope;
- event/category tags;
- factual summary;
- affected market/media domains;
- possible social/economic/technology pressures;
- source/provenance;
- confidence/review state;
- whether the effect is factual, inferred, or game-design interpretation.

Do not encode controversial interpretation as objective historical fact.

Where an event's gameplay effect is a design inference, keep the distinction explicit.

### Creative context

When a production is conceived or developed, the current historical slice can be exposed to the creative process.

Relevant inputs may include:

- current year/era;
- global events;
- local events;
- market conditions;
- available media/technology;
- cultural movements;
- studio location/language;
- existing studio/IP history;
- professionals assigned to the production;
- their relationships, beliefs, experiences and current states;
- prior audience response.

For runtime AI-assisted production, provide a **bounded, relevant context package**, not an unfiltered dump of the entire historical database.

Historical context can influence:

- themes;
- tone;
- subject matter;
- humour;
- character concerns;
- visual language;
- medium choice;
- production constraints;
- what employees propose or reject.

The player should retain creative agency. Historical context informs possibilities; it does not force one "correct" work.

### Effects on professionals

Real events may affect professionals through their personal context.

Possible consequences include:

- morale/stress;
- creative energy;
- attendance;
- finances;
- safety;
- political/social pressure;
- family obligations;
- migration;
- military/civic obligations where historically appropriate;
- access to materials/equipment;
- changes in audience or professional opportunity.

Effects should depend on the character and location rather than applying identical global penalties to everyone.

A global event may be background noise to one employee and life-changing to another.

### Market and audience reception

Historical context should participate in reception without becoming a deterministic lookup table.

A production's result may conceptually depend on a combination such as:

`craft/quality + audience fit + historical context + market conditions + medium/technology + studio reputation + distribution + novelty/timing + uncertainty`

Examples of context-sensitive reception:

- a theme becomes unusually resonant because of current events;
- a comedy arrives at the wrong cultural moment;
- a new medium benefits from novelty but reaches a smaller audience;
- economic hardship reduces spending while increasing demand for inexpensive entertainment;
- a local cultural movement creates an audience for work previously considered niche;
- a production created before a major event is received very differently if released afterward.

Do not reduce this to hidden arbitrary bonuses. The player should receive legible signals about why the market reacted as it did.

### History is backdrop, not predestination

The canonical historical timeline should remain stable unless the game explicitly adopts an alternate-history system in the future.

T.O.O.N. should generally answer:

> "What did your fictional studio do while real history was happening?"

rather than:

> "Can your cartoon studio rewrite world history?"

The studio can become culturally important inside the fictional campaign without casually replacing real historical causality.

### Historical tone and sensitivity

Real history can include war, persecution, disaster, political repression, economic collapse, discrimination and other serious events.

T.O.O.N. should not convert human suffering into a simplistic opportunity modifier such as `+20% comedy demand`.

For sensitive events:

- distinguish factual context from game-design interpretation;
- model concrete pressures before abstract market bonuses;
- consider asymmetric effects on professionals, audiences, materials, distribution and safety;
- avoid jokes whose only premise is the suffering of real victims;
- keep systemic comedy focused primarily on the fictional studio/cast rather than trivializing real tragedy;
- provide content/tone controls where historical material materially benefits from them;
- use reviewable sourced summaries rather than sensationalized AI-generated history.

Historical context can still create meaningful creative tension, irony and market change, but the simulation should remain legible about what is factual and what is an authored model.

### Historical research boundary

Because the campaign uses real countries, dates, markets and events, historical content requires a sourced data pipeline.

Do not let AI invent historical facts at runtime.

AI may synthesize from approved historical context, but factual entries should come from curated/reviewed data with provenance.

## Core systemic model

T.O.O.N. is built around five coupled systems:

### Studio

- cash and recurring costs;
- facilities;
- departments;
- equipment;
- reputation;
- archive;
- opportunities;
- long-term identity.

### People

- skills and roles;
- career progression;
- happiness/morale;
- creative energy;
- discipline;
- wildness/experimentation;
- relationships;
- demands and bargaining power;
- absences and outside-life consequences;
- aging/longevity rules;
- legacy.

### Productions

- medium;
- scope;
- schedule;
- budget;
- crew;
- creative direction;
- production pressures;
- quality;
- release result;
- persistent consequences.

### IPs

- identity;
- characters;
- premise/tone;
- canon where useful;
- adaptation history;
- audience recognition;
- ownership/credit history;
- media transformations over time.

### Time

- eras;
- changing production methods;
- new professional disciplines;
- cultural/market pressures;
- staff aging or non-aging;
- retirements and generations;
- long-term studio memory.

These systems must interact. A production decision should be able to affect people, money, future IP options, and studio history.

## Core loop

Long-term target:

`Choose opportunities -> develop/continue an IP -> assemble a crew -> manage people, money and technology -> solve creative/production conflicts -> release -> absorb consequences -> evolve studio/cast/IP -> advance into new opportunities and media`

The game should produce stories through simulation rather than requiring scripted narrative for every campaign event.

## Studio space, facilities and workplace culture

The studio is a physical system that grows with the company.

The player should be able to expand the workplace over time by acquiring space, building rooms/departments, and buying objects that affect both production capability and the people who work there.

Studio purchases fall into several broad categories.

### Production infrastructure

These directly enable or improve work:

- writing desks and editorial equipment;
- drawing/inking stations;
- cameras and animation equipment;
- sound/recording spaces;
- projection/review rooms;
- computers/workstations;
- render infrastructure;
- storage/archive capacity;
- specialist department rooms.

Production infrastructure should primarily affect what the studio can make, how efficiently it can make it, and what workflows become possible.

### Shared workplace amenities

These improve the lived experience of the office:

- break rooms;
- kitchen/coffee;
- lounge/rest spaces;
- better lighting;
- climate control;
- quiet rooms;
- music/radio;
- recreational objects;
- comfortable furniture.

These should influence morale, recovery, social interaction, concentration, or conflict rather than acting as universal flat bonuses.

### Professional-facing props and personalisation

Professionals may react differently to objects and spaces.

Examples:

- an artist may value reference shelves, plants, natural light, or a large drawing table;
- a writer may prefer privacy, books, a typewriter, cigarettes in an era where appropriate, or a chaotic shared room;
- an anxious prey character may dislike being seated beside a hunter;
- an immortal veteran may insist on keeping an obsolete desk or tool for decades;
- a technically minded employee may become happier when new equipment arrives;
- a nostalgic character may prefer older tools even after better technology exists.

A prop should ideally answer at least one of:

- does this help someone work;
- does this help someone recover;
- does this change social behaviour;
- does this express studio identity/history;
- does this satisfy or annoy a specific professional.

Avoid reducing every prop to generic `+X Creativity` or `+Y Happiness`.

### Culture and identity

Decoration can make the studio feel like **this campaign's T.O.O.N.** rather than a generic office.

Potential sources include:

- posters from old productions;
- framed strips/comic covers;
- awards;
- employee portraits;
- props from films;
- old equipment retained after replacement;
- memorials;
- joke signs and bureaucratic notices;
- department-specific decoration;
- souvenirs from failed/successful productions.

Historical objects can carry both emotional and mechanical value.

For example, preserving the original 1900 writing desk in a 2030 headquarters may:

- improve morale for nostalgic veterans;
- reinforce studio identity;
- irritate a modern producer who wants the space;
- become part of the archive/museum;
- trigger stories or memories tied to old productions.

### Space and adjacency

Room layout may influence the simulation where it creates meaningful decisions.

Possible effects include:

- shorter collaboration distance;
- concentration/noise;
- cross-department contact;
- social friction;
- exposure to predators/hunters;
- access to equipment;
- crowding;
- privacy;
- visibility/status of offices.

Do not make the player micromanage furniture placement purely for optimization unless the placement creates readable, interesting tradeoffs.

### Professional preferences

Professionals may have lightweight environmental preferences such as:

- likes quiet;
- likes crowds;
- wants natural light;
- hates clutter;
- loves clutter;
- prefers old technology;
- wants cutting-edge equipment;
- needs privacy;
- enjoys social spaces;
- wants prestige/status;
- strongly values a specific personal object.

These preferences should combine with personality, role, relationships, era and current state.

The same object may make one employee happier and another less productive.

### Growth over time

Studio expansion should be visible across the campaign.

A possible progression:

`one room -> shared office -> specialist rooms -> multi-department studio -> expanded lot/building -> modern production campus`

Growth should follow needs created by people, media and production scale rather than existing only as a linear upgrade tree.

## Studio professionals

Studio professionals are recurring characters, not interchangeable worker resources.

A professional may include:

- stable identity;
- visual/species/archetype identity;
- role/discipline;
- skills and strengths;
- happiness/morale;
- creative energy;
- discipline;
- wildness/experimentation;
- ambitions;
- salary/credit expectations;
- work history;
- relationships;
- life outside the studio;
- longevity/aging model;
- current assignment/state.

Depth should come from readable behaviour and history, not hundreds of opaque attributes.

## Character ontology and lifespan

T.O.O.N. intentionally allows different kinds of beings to coexist in one workplace.

Appearance/species and lifespan are separate concepts.

A character may visually be a:

- human;
- anthropomorphic animal;
- creature/monster;
- living object;
- other authored cartoon archetype.

Separately, the character has an **existence/longevity model**.

Candidate longevity models include:

### Mortal

Ages broadly like a human. Can grow older, retire, and die.

### Long-lived

Ages, but on a slower or non-human timescale.

### Cartoon-static

Can remain visually and biologically at roughly the same apparent age for decades or centuries unless a specific event changes them.

A grumpy elderly cartoon hired in 1930 may still be the same grumpy elderly cartoon in 2030.

### Conditional / rule-bound

Longevity follows a character-specific rule rather than ordinary biology. Examples might include magical, mechanical, cursed, resurrecting, or other cartoon-logical conditions.

The game should not require every employee to share one biological model.

This creates meaningful long-term cast structures:

- mortal employees create generations, succession, retirement, mentorship, and loss;
- immortal/static cartoons create institutional memory, ancient grudges, recurring mentorship, and comic continuity;
- mixed teams create relationships that can span radically different lifetimes.

Immortality must not imply immunity from all consequences. An immortal character may still:

- quit;
- be fired;
- be imprisoned;
- disappear;
- be injured;
- become unavailable;
- change profession;
- fall out with the studio;
- leave for a rival;
- return decades later.

## Management model and autonomous social simulation

The player is the **studio owner/manager**, not a puppeteer controlling individual workers like playable Sims.

The management layer should primarily let the player set context and constraints such as:

- role/discipline;
- production assignment and crew;
- priorities;
- schedule/budget pressure;
- compensation, credit and promotion;
- workspace/facility conditions;
- policies;
- direct management conversations;
- responses to important situations.

Professionals then execute and socialize with meaningful autonomy.

### Autonomous social behaviour

Professionals should initiate ordinary social interactions without explicit player commands.

They may:

- chat;
- joke;
- argue;
- flirt where appropriate;
- mentor;
- complain;
- reconcile;
- gossip;
- react to recent work/events;
- build or damage relationships over time.

The player influences the conditions under which relationships develop, but does not normally issue commands such as `Talk to X` or `Befriend Y`.

### Conversation presentation

Ordinary workplace conversation should primarily appear as **short comic-style speech bubbles**, not fully voiced dialogue.

Sound can support reactions, emotion and readability without requiring every generated line to be voiced.

The studio is allowed to have more social life than the player can observe. A player who is looking elsewhere may miss ordinary conversations. This is intentional: routine social simulation is ambient life, not mandatory information.

Important state changes must remain legible through behaviour, relationship UI, warnings and later consequences even when the player did not read every line.

### AI-generated conversation

Runtime AI can generate dialogue for ordinary social interactions so conversations reflect:

- character identity;
- current relationship;
- recent events;
- production context;
- historical/cultural context where relevant;
- mood and current state.

The language model must **not directly mutate authoritative gameplay attributes**.

An interaction resolves through a bounded game-owned result such as:

`conversation context -> generated dialogue -> structured interaction outcome -> deterministic simulation update`

Candidate outcomes include:

- bonding;
- disagreement;
- insult;
- support;
- mentorship;
- flirtation;
- intimidation;
- reconciliation;
- creative inspiration;
- tension increase.

The simulation owns the permitted magnitude and final change to relationships, morale, creative energy or other state.

### Preventive management

The player may prevent a later crisis by noticing context early and using normal management tools.

Examples:

- extend a deadline;
- reduce workload;
- change crew composition;
- grant leave;
- improve working conditions;
- adjust compensation or credit;
- change responsibilities;
- initiate a management conversation.

There is no abstract `Prevent Decision Event` button. Prevention emerges because the underlying causes changed.

### Decision Events

Routine interactions remain autonomous until a situation requires the **authority of the studio owner**.

A Decision Event is a game-authored or game-authored-template situation that:

- is triggered by legible simulation state;
- represents a crisis, conflict or consequential production/people decision requiring owner intervention;
- auto-pauses the simulation when formally presented;
- presents meaningful structured choices;
- has authored consequence boundaries;
- may use AI for contextual dialogue/flavour without giving AI authority over the rule outcome.

The preferred technical/content model is a **small library of parameterized event archetypes** rather than hundreds of bespoke events.

Examples include:

- serious creative disagreement;
- demand for credit or promotion;
- threat to resign;
- relationship conflict disrupting production;
- dangerous predator/prey escalation;
- request for creative control;
- production crisis caused by an outside-life event;
- ethical or commercial dispute;
- external offer affecting a key professional.

The simulation detects eligibility; the authored event definition owns roles, allowed choices and consequence bounds; AI contextualizes/dramatizes the event; the player chooses; deterministic game rules apply the result.

### Escalation and warning

Many Decision Events should emerge through an observable escalation:

`ordinary interaction -> developing problem -> attention warning -> Decision Event`

A discreet **attention marker** such as `!` can appear over the relevant professional or area when something potentially important is developing.

The marker means “something worth watching may be happening,” not “click now or lose the event.”

The player may investigate and use normal management actions before the crisis escalates.

If the situation ultimately requires owner authority, the game pauses and presents the Decision Event even if the player was looking elsewhere.

Some events are naturally sudden and may skip the warning stage.

This creates two complementary narrative layers:

`emergent autonomous social life + authored consequential decision points`

### Owner-initiated management conversations

The studio owner may directly call a professional into a management conversation.

These are **structured management actions**, not free-form roleplay and not direct control of the professional.

Candidate intents include:

- listen to concerns;
- praise;
- give feedback;
- warn/reprimand;
- discuss workload;
- negotiate expectations;
- discuss career development;
- address a relationship or production problem.

The player chooses the **intent**, not the exact wording.

Runtime AI may dramatize the conversation within that intent, but the allowed outcomes and state changes remain game-owned.

**Free-text player dialogue is not part of the intended interaction model.** T.O.O.N. should keep these conversations permanently structured rather than making unrestricted text input a required or alternate core mechanic.

## Relationships

Relationships are directional and should affect production.

### Relationship visibility

Use a **hybrid visibility model**:

- precise multi-dimensional values may exist internally for simulation;
- the player sees a small number of legible high-level relationship bars rather than raw numerical spreadsheets;
- qualitative sentiments/tags communicate important nuance;
- a relationship history explains the main causes of the current state.

Initial high-level visible bars should prioritize concepts such as:

- **Bond/Affection**;
- **Trust**.

Do not require displaying exact `72/100` values by default.

Overlay qualitative sentiments such as:

- friendship;
- rivalry;
- resentment;
- attraction;
- fear;
- mentorship;
- admiration;
- envy;
- professional respect;
- distrust.

This allows relationships that are intentionally contradictory, for example:

`high bond + low trust + rivalry + admiration`

The UI should expose causal history so the player can understand changes, for example:

- Trust decreased — took credit for their work;
- Bond increased — completed a difficult production together;
- Rivalry emerged — both want creative control over the same IP;
- Admiration increased — witnessed exceptional work.

Because relationships are directional, what A feels about B may differ substantially from what B feels about A.

The player should be able to infer relationship state from behaviour/conversation, while the relationship UI provides enough explicit information to make consequential events feel earned rather than arbitrary.

Potential relationship dimensions include:

- affection;
- trust;
- tension;
- rivalry;
- attraction where appropriate;
- fear.

A->B need not equal B->A.

Relationships can influence:

- collaboration quality;
- creative risk;
- rework;
- morale;
- willingness to accept assignments;
- demands for separation or partnership;
- resignations;
- conflicts;
- mentorship;
- romance;
- long-term loyalty.

Species/archetype may create **initial tendencies or pressures**, but it does not determine personality.

A cat and mouse may begin with a predatory/prey tension. They may later become the studio's greatest creative partnership.

A hunter may be extraordinarily talented while making multiple anthropomorphic employees uncomfortable or afraid.

## Office vs Nonsense in people

Creative value should not collapse into one stat.

Useful conceptual axes include:

- **Morale** — miserable to happy;
- **Creative Energy** — exhausted to inspired;
- **Wildness** — conservative to experimental;
- **Discipline** — chaotic to reliable.

Examples:

- high Wildness + high Discipline = rare creative powerhouse;
- high Wildness + low Discipline = brilliant but dangerous to schedule;
- low Wildness + high Discipline = dependable production specialist;
- low Wildness + low Discipline = organizational problem.

Player choices can shift these states over time.

Repeatedly rejecting a creator's ideas may make them less experimental, more resentful, or more likely to leave. Giving creative freedom may produce exceptional work or uncontrolled scope.

## Employee agency

Employees can make demands and choices.

Potential demands include:

- raises;
- promotions;
- credit;
- different roles;
- time off;
- more creative control;
- less overtime;
- refusal to work with someone;
- access to a desired IP or production;
- recognition for creating a character/property.

Talented employees should gain bargaining power.

Employees can:

- refuse;
- resign;
- leave for competitors;
- return later;
- retire;
- become unavailable mid-production.

The player's job is not to own people. It is to keep a functioning studio despite their agency.

## Life outside the studio

Characters have an off-screen life that can affect work without requiring a fully simulated city.

Examples include:

- family obligations;
- hobbies;
- second jobs;
- gambling/debt;
- political or union activity;
- criminal activity;
- secret heroism;
- secret villainy;
- relationships outside work;
- illness or injury;
- fame outside the studio.

These can produce readable events and absences.

A worker may arrive exhausted because they act as a hero at night. Their best friend at work may secretly be a villain whom they later arrest, creating an absence in the middle of production.

The simulation should preserve causal signals before severe consequences rather than using arbitrary destructive random events.

## Cartoon logic, predation and violence

Cartoon-world archetypes may create unusual workplace problems:

- predator/prey instincts;
- hunters working beside anthropomorphic animals;
- slapstick violence;
- absurd injuries;
- rivalry escalating into physical conflict;
- imprisonment or disappearance;
- relationships that become dangerous.

The tone should support cartoon exaggeration without making every conflict consequence-free.

Permanent death is not a universal rule because different character ontologies exist. Severe outcomes must follow the character's own existence model and should be causally legible where gameplay investment is at stake.

## Systemic comedy

Humour should emerge from simulation rules, character ontology, workplace pressures, and long-term consequences rather than relying mainly on disconnected scripted jokes.

Examples:

- a brilliant talking cricket may be fully mortal and have a naturally short lifespan, creating an absurd but strategically serious hiring decision;
- an apparently elderly cartoon may remain the same age for a century and become the office's permanent grumpy veteran;
- a mortal prodigy may have only a brief career while an immortal mediocre employee survives multiple generations;
- a predator/prey relationship can begin as a familiar cartoon gag and develop into friendship, fear, rivalry, mentorship, or catastrophe;
- a night-time hero may repeatedly arrive exhausted, while their best friend at work is secretly the villain responsible;
- a character may survive slapstick disasters that would kill a mortal colleague because their existence model follows different rules.

The joke should usually have a **gameplay consequence**.

A short-lived genius, for example, can force the player to decide whether to:

- hire them despite limited long-term availability;
- rush a production around their remaining career;
- pair them with an apprentice to preserve knowledge;
- pay a premium because their talent is rare;
- accept the risk that an unfinished production loses a critical contributor.

This principle keeps T.O.O.N.'s nonsense legible and consequential:

> **The world can be absurd, but the simulation should take its absurdity seriously.**

Avoid direct copies of protected cartoon characters. Familiar archetypes may be referenced structurally, but characters, names, designs, biographies, and specific jokes should be original.

## Careers and generations

Mortal and aging professionals can move through career stages such as:

`Recruit -> Junior -> Experienced -> Veteran -> Legend -> Retired`

Immortal/static cartoons may instead accumulate:

- expertise;
- influence;
- grudges;
- mentorship lineages;
- institutional status;
- outdated habits;
- resistance or enthusiasm toward new media.

A studio can therefore contain both generations of mortal workers and century-long cartoon veterans.

## Production scale and output length

T.O.O.N. should favor **small complete works** rather than attempting real-world production lengths.

The goal is that a player can finish many works across one campaign, actually consume them, remember them, compare adaptations, and optionally share favorites.

Target output scales are intentionally compact and remain subject to prototype validation:

| Medium | Initial target scale |
| --- | --- |
| Text / humour piece | roughly one screen / a few hundred words at most |
| Illustration / editorial piece | one finished image or compact set |
| Strip | **3–4 panels** |
| Short comic | **1–4 pages** |
| Storyboard / animatic | roughly 20–90 seconds |
| 2D animated short | roughly 30–120 seconds |
| 3D / realtime short | roughly 30–120 seconds |

These are **content-length targets**, not fixed in-game production-time rules.

A two-minute 3D short can require far more staff, equipment, cost and in-game calendar time than a two-minute 2D short. Production complexity should scale through:

- number and specialization of professionals;
- technology/equipment;
- pipeline stages;
- iteration/rework;
- relationships/conflicts;
- budget;
- schedule;
- creative ambition.

The player should not need to produce a feature-length film to feel that T.O.O.N. has entered a film/3D era. A compact, polished production can represent a much larger industrial capability while remaining practical to generate, watch and archive.

Production forms may later have rare exceptions beyond these normal targets, but long runtime should not become the default progression reward.

## Sharing productions

Completed productions should be designed as **shareable artifacts**.

The preferred first architecture is export-first rather than hard-wiring the game to individual social-network APIs.

A released work may produce a share package containing, where relevant:

- the final image/comic/video/text artifact;
- title and IP;
- studio year/era;
- selected credits;
- optional T.O.O.N. branding;
- a compact generated caption/description;
- a thumbnail/poster/card;
- provenance needed by the game to reconnect the shared artifact to the campaign.

The player should explicitly choose what is shared. Do not automatically upload productions or expose private save data.

Possible later platform-specific sharing integrations should remain adapters around a game-owned export/share contract so changing third-party APIs do not own the production system.

Social sharing can reinforce the fantasy: a player is not merely posting a procedural asset; they are showing **what their studio made**.

A useful share might communicate:

> title + year + medium + key credits + one memorable production fact

For example, the game could surface that a short was directed by a century-old immortal veteran, written by a short-lived cricket genius, or completed after the lead animator was arrested.

## Produced works as playable rewards

T.O.O.N. productions are not only abstract score cards.

Where technically and economically feasible, the player should be able to **consume the work the studio produced**:

- read generated/assembled text;
- read strips and comics;
- view storyboards or animatics;
- watch animated shorts/episodes or representative film outputs;
- later view 3D/realtime-era productions.

These outputs may be created through combinations of player direction, simulation, authored templates, procedural systems and runtime AI behind T.O.O.N.-owned contracts.

Watching/reading the work counts as part of the intended campaign experience and therefore part of the approximate 40-hour target.

The production itself is a reward, evidence of the studio's history, and feedback on prior player choices. It should preserve enough provenance to answer questions such as:

- which IP was used;
- which professionals contributed;
- what major creative/production choices shaped it;
- what media/technology was available;
- how the audience/reputation/economy responded;
- how later adaptations descend from it.

Consumption should be skippable/revisitable where practical. A player who wants to watch everything should be rewarded with context and attachment rather than punished with mandatory unskippable runtime.

## IP continuity across media

One persistent property may evolve through multiple media.

Example pattern:

`text character -> strip -> comic -> animated short -> television series -> digital revival -> 3D adaptation`

The adaptation history should remain visible. The studio archive should show how a property changed across decades and which professionals shaped each version.

A later adaptation should ideally make the lineage perceptible: the player should be able to compare the 1910s textual/illustrated form of an IP with its comic, 2D animation and eventual 3D incarnations.

## Cross-media identity consistency

Persistent IP only works if the player can recognize the same property and characters across decades and media.

Each important IP/character should therefore have a game-owned continuity package that can be consumed by manual tools, procedural systems and runtime AI adapters.

Useful identity evidence may include:

- stable character/IP identifiers;
- canonical names and relationships;
- premise/tone;
- visual anchors and silhouette traits;
- approved reference images where available;
- voice/language traits where relevant;
- recurring props/symbols;
- canon facts and adaptation constraints;
- deliberate changes introduced by a specific adaptation.

The goal is **continuity with evolution**, not pixel-identical reproduction.

A 1910 illustration and a 2025 3D adaptation should be allowed to look different while remaining recognizably descended from the same property.

When runtime AI generates media, provider-specific prompt tricks, seeds or model settings may assist consistency, but they must not become the canonical identity source. The canonical identity belongs to T.O.O.N.-owned data and approved artifacts.

## Historical archive and endgame

The archive is a major campaign payoff.

By 2030, the player should be able to inspect the history they created:

- first published work;
- first successful character;
- major failures;
- hits;
- cancelled projects;
- important employees;
- founders and retirees;
- century-old immortal staff;
- famous partnerships and feuds;
- technology transitions;
- different versions of the same IP;
- awards/reputation milestones where implemented;
- disastrous reboots;
- legendary productions.

The archive should make the campaign feel authored by the player's decisions.

## Art direction

The studio world should visually evolve with time while preserving T.O.O.N.'s authored identity.

Useful principles:

- strong silhouettes;
- expressive posing;
- macro-shape clarity;
- animation-aware movement;
- era-sensitive clothes, props, equipment and spaces;
- visible studio growth;
- old objects and rooms retained as historical traces;
- a mixture of institutional office language and cartoon absurdity.

Classic-cartoon structure can inform posing and graphic design without copying protected studio/character identities.

## Authorship and AI

Production intent, accepted generated artifacts and persistent consequences should converge on game-owned production data.

Runtime AI may be used heavily for text, image, audio, animation or other media generation. Provider/runtime choices remain implementation adapters and must not own:

- the game-domain model;
- studio progression;
- employee agency;
- historical truth;
- final release authority;
- irreversible canon/production decisions.

The player should retain meaningful creative direction and release authority. Where the workflow exposes intermediate proposals, they should be inspectable/accept-reject-editable.

Provider independence does **not** require a feature-complete manual authoring tool for every medium. Core simulation and persistence should be testable through deterministic fixtures/fallbacks even when representative final media normally uses AI generation.

## Persistence

Persistent state should support stable identifiers and version migration.

Long-term persistence must be able to represent at least:

- studio history;
- employees and their existence models;
- relationships;
- IPs and adaptation history;
- productions/releases;
- technology/media state;
- durable consequences.

Legacy `InkTime` saves/artifacts are migration evidence rather than a shipped compatibility promise. Preserve representative fixtures or extract useful data where valuable, but do not make full Unity-save compatibility a blocker for the Unreal game without explicit need.

## First validation slice

The first slice should not attempt 130 years.

It should prove the characteristic interaction among studio, people, production, and persistent consequence.

Minimum target:

1. one small studio;
2. 3–4 recurring professionals with distinct traits;
3. at least two meaningful relationships;
4. one IP;
5. one production;
6. one assignment decision;
7. one people/production conflict;
8. one player response with tradeoffs;
9. release;
10. one persistent studio/professional/IP consequence;
11. save/reopen;
12. one visual signal of historical continuity.

A second bounded prototype should later test one media/era transition.

## Explicit non-goals for the first slice

Do not require:

- a full 1900–2030 campaign;
- every historical medium;
- a complete animation DCC;
- deep city simulation;
- complete family simulation;
- hundreds of relationship variables;
- feature-film production depth;
- large autonomous AI pipelines;
- unproven Game Studio/Nexus integrations;
- production readiness.

## Engine and production strategy

T.O.O.N. is now intended to be built in **Unreal Engine**.

This is an accepted project direction, not an implementation claim. The current repository still contains a Unity-based scaffold until an Unreal project is bootstrapped and validated.

The Unreal project is also an explicit professional-development artifact: it should demonstrate practical engine competence through real game requirements rather than résumé-driven feature accumulation.

Development is intentionally **AI-heavy**. AI may be used extensively for code, content, research, tests, debugging, tooling, documentation, balancing and visual exploration.

Keep two boundaries explicit:

- **development-time AI** accelerates making the game;
- **runtime/player-facing AI** is a game feature and remains behind game-owned contracts.

AI acceleration must not erase technical ownership. Important systems should remain understandable, debuggable, maintainable and supported by actual compile/run/test/profile evidence.

See [Unreal + AI development strategy](unreal-ai-development-strategy.md).

## Relationship to Polite Goblin and Loomlight

T.O.O.N. is an independent game.

- **YFramework** owns shared terminology, naming/routing, doctrine, The Y Framework methodology, and status vocabulary.
- **Loomlight Flux** owns reusable Unity framework implementation but is legacy migration context for T.O.O.N.; the target game implementation is Unreal-owned.
- **Loomlight Game Studio** may orchestrate production work around T.O.O.N.; it does not own this game's design/runtime.
- **Loomlight Nexus** participation is optional and cannot be inferred from AI features.

## Validation questions

- Does the player feel they are running a living studio rather than filling production forms?
- Do people create meaningful production opportunities and problems?
- Can employees feel memorable without becoming unpredictable noise?
- Are serious outcomes causally readable?
- Does mixed mortality/immortality create interesting long-term stories?
- Does a new medium change staffing, equipment and production decisions rather than only adding a bonus?
- Can old media remain strategically relevant?
- Does one IP feel meaningfully transformed when adapted across eras?
- Does the studio visibly accumulate history?
- Does core simulation, persistence and reception remain coherent if a runtime AI provider is unavailable, replaced or degraded, even if generated-media fidelity temporarily falls back?
