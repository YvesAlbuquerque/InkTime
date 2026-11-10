using System;
using System.IO;
using UnityEngine;

namespace InkThroughTime.Infrastructure.Persistence
{
    /// <summary>
    /// Stores and retrieves generated comic panel image files.
    /// All paths are stored relative to the ComicsRoot directory.
    /// ComicsRoot = Application.persistentDataPath/InkTime/Comics/
    /// </summary>
    public class ComicArtefactStore
    {
        private const string ComicsSubDirectory = "InkTime/Comics";

        private string ComicsRoot =>
            Path.Combine(Application.persistentDataPath, ComicsSubDirectory);

        /// <summary>
        /// Returns the absolute path for a given relative comic artefact path.
        /// </summary>
        public string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return string.Empty;
            return Path.Combine(ComicsRoot, relativePath);
        }

        /// <summary>
        /// Saves a PNG texture as a comic panel artefact.
        /// Returns the relative path stored in PublishedComic.PanelImagePaths.
        /// </summary>
        public string SavePanel(Texture2D texture, string projectId, int panelIndex)
        {
            if (texture == null) throw new ArgumentNullException(nameof(texture));

            string dir = Path.Combine(ComicsRoot, projectId);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string fileName = $"panel_{panelIndex + 1}.png";
            string absolutePath = Path.Combine(dir, fileName);
            string relativePath = Path.Combine(projectId, fileName);

            byte[] pngBytes = texture.EncodeToPNG();
            File.WriteAllBytes(absolutePath, pngBytes);

            return relativePath;
        }

        /// <summary>
        /// Loads a comic panel texture from a relative path.
        /// Returns null if the file does not exist (fallback handled by caller).
        /// </summary>
        public Texture2D LoadPanel(string relativePath)
        {
            string absolutePath = GetAbsolutePath(relativePath);
            if (!File.Exists(absolutePath)) return null;

            byte[] bytes = File.ReadAllBytes(absolutePath);
            var texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            return texture;
        }

        /// <summary>
        /// Returns true if a panel image exists at the given relative path.
        /// </summary>
        public bool PanelExists(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return false;
            return File.Exists(GetAbsolutePath(relativePath));
        }

        /// <summary>
        /// Deletes all panel artefacts for a specific project.
        /// </summary>
        public void DeleteProject(string projectId)
        {
            string dir = Path.Combine(ComicsRoot, projectId);
            if (Directory.Exists(dir))
                Directory.Delete(dir, recursive: true);
        }
    }
}
