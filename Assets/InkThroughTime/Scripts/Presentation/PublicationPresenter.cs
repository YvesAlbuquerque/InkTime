using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InkThroughTime.Application;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Displays a published comic: title, synopsis, three panel images, and score breakdown.
    /// </summary>
    public class PublicationPresenter : MonoBehaviour
    {
        [Header("Comic Info")]
        [SerializeField] private TextMeshProUGUI _titleLabel;
        [SerializeField] private TextMeshProUGUI _synopsisLabel;
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private TextMeshProUGUI _revenueLabel;

        [Header("Panel Images")]
        [SerializeField] private RawImage _panel1;
        [SerializeField] private RawImage _panel2;
        [SerializeField] private RawImage _panel3;

        private InkThroughTime.Infrastructure.Persistence.ComicArtefactStore _artefactStore;

        private void Start()
        {
            var root = FindObjectOfType<InkGameRoot>();
            if (root != null)
                _artefactStore = new InkThroughTime.Infrastructure.Persistence.ComicArtefactStore();
        }

        /// <summary>
        /// Displays a published comic in this presenter.
        /// </summary>
        public void Display(PublishedComic comic)
        {
            if (comic == null) return;

            if (_titleLabel != null && comic.Plan != null)
                _titleLabel.text = comic.Plan.Title;

            if (_synopsisLabel != null && comic.Plan != null)
                _synopsisLabel.text = comic.Plan.Synopsis;

            if (_scoreLabel != null && comic.Score != null)
                _scoreLabel.text = $"Score: {comic.Score.WeightedTotal:P0}";

            if (_revenueLabel != null)
                _revenueLabel.text = $"Revenue: ${comic.Revenue:N0}";

            LoadPanelImage(_panel1, comic.PanelImagePaths?.Length > 0 ? comic.PanelImagePaths[0] : null);
            LoadPanelImage(_panel2, comic.PanelImagePaths?.Length > 1 ? comic.PanelImagePaths[1] : null);
            LoadPanelImage(_panel3, comic.PanelImagePaths?.Length > 2 ? comic.PanelImagePaths[2] : null);
        }

        private void LoadPanelImage(RawImage target, string relativePath)
        {
            if (target == null) return;
            if (string.IsNullOrEmpty(relativePath) || _artefactStore == null) return;

            var texture = _artefactStore.LoadPanel(relativePath);
            if (texture != null)
                target.texture = texture;
        }
    }
}
