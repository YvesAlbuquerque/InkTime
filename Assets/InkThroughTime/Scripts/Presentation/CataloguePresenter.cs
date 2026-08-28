using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InkThroughTime.Application;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Displays the archive wall: all published comics, sorted by publication date.
    /// Opens a detail view via PublicationPresenter on click.
    /// </summary>
    public class CataloguePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _comicThumbnailPrefab;
        [SerializeField] private Transform _archiveContainer;
        [SerializeField] private PublicationPresenter _detailView;

        private InkGameRoot _root;

        private void Start()
        {
            _root = FindObjectOfType<InkGameRoot>();
            if (_root == null) return;

            _root.ProductionService.OnComicPublished += HandleComicPublished;
            RebuildArchive();
        }

        private void OnDestroy()
        {
            if (_root != null)
                _root.ProductionService.OnComicPublished -= HandleComicPublished;
        }

        private void HandleComicPublished(PublishedComic comic) => AddThumbnail(comic);

        private void RebuildArchive()
        {
            foreach (Transform child in _archiveContainer)
                Destroy(child.gameObject);

            foreach (var comic in _root.Session.PublishedComics)
                AddThumbnail(comic);
        }

        private void AddThumbnail(PublishedComic comic)
        {
            if (_comicThumbnailPrefab == null || _archiveContainer == null) return;

            var go = Instantiate(_comicThumbnailPrefab, _archiveContainer);
            var btn = go.GetComponent<Button>();
            if (btn != null)
            {
                var captured = comic;
                btn.onClick.AddListener(() => ShowDetail(captured));
            }

            var label = go.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null && comic.Plan != null)
                label.text = comic.Plan.Title;
        }

        private void ShowDetail(PublishedComic comic)
        {
            if (_detailView != null)
                _detailView.Display(comic);
        }
    }
}
