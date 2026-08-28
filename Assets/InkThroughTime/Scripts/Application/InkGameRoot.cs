using System;
using UnityEngine;
using InkThroughTime.Domain;
using InkThroughTime.Infrastructure.AI;
using InkThroughTime.Infrastructure.Persistence;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Game-specific composition root. Wires all services and presenters.
    /// Place this MonoBehaviour on the InkGameRoot GameObject in the main scene.
    /// </summary>
    public class InkGameRoot : MonoBehaviour
    {
        [Header("Services")]
        [SerializeField] private SimulationClockConfig _clockConfig;

        // Runtime service instances (constructed, not FindObjectOfType)
        private GameSession _session;
        private SimulationClock _clock;
        private GameFlowController _flowController;
        private ProductionService _productionService;
        private EconomyService _economyService;
        private CatalogueService _catalogueService;
        private OpportunityService _opportunityService;
        private AiCoordinator _aiCoordinator;
        private InkSaveService _saveService;
        private ComicArtefactStore _artefactStore;

        private void Awake()
        {
            ComposeServices();
        }

        private void Start()
        {
            _saveService.TryLoad(_session);
            _clock.Start();
        }

        private void OnDestroy()
        {
            _clock?.Stop();
            _aiCoordinator?.Dispose();
        }

        private void ComposeServices()
        {
            _session = new GameSession();
            _artefactStore = new ComicArtefactStore();
            _saveService = new InkSaveService();

            IComicAIService aiService = new MockComicAIService();
            _aiCoordinator = new AiCoordinator(aiService);

            _economyService = new EconomyService(_session);
            _catalogueService = new CatalogueService(_session);
            _productionService = new ProductionService(_session, _aiCoordinator, _artefactStore);
            _opportunityService = new OpportunityService(_session);
            _flowController = new GameFlowController(
                _session, _economyService, _catalogueService, _opportunityService);

            _clock = new SimulationClock(_clockConfig, _flowController, _productionService, _session);
        }

        private void Update()
        {
            _clock?.Tick(Time.deltaTime);
        }

        // Public accessors for presenters
        public GameSession Session => _session;
        public SimulationClock Clock => _clock;
        public GameFlowController FlowController => _flowController;
        public ProductionService ProductionService => _productionService;
        public EconomyService EconomyService => _economyService;
        public CatalogueService CatalogueService => _catalogueService;
        public OpportunityService OpportunityService => _opportunityService;
    }
}
