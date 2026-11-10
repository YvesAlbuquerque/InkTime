using System;
using System.IO;
using UnityEngine;

namespace InkThroughTime.Infrastructure.Persistence
{
    /// <summary>
    /// Legacy comic-panel artefact store retained while T.O.O.N.'s animation-production
    /// artefact model is redesigned. New files use the T.O.O.N. storage root; reads fall
    /// back to the former InkTime root for compatibility.
    /// </summary>
    public class ComicArtefactStore
    {
        private const string ComicsSubDirectory = "TOON/Comics";
        private const string LegacyComicsSubDirectory = "InkTime/Comics";

        private string ComicsRoot =>
            Path.Combine(Application.persistentDataPath, ComicsSubDirectory);

        private string LegacyComicsRoot =>
            Path.Combine(Application.persistentDataPath, LegacyComicsSubDirectory);

        /// <summary>
        /// Returns the canonical absolute T.O.O.N. path for a relative artefact path.
        /// </summary>
        public string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return string.Empty;
            return Path.Combine(ComicsRoot, relativePath);
        }

        /// <summary>
        /// Saves a PNG texture under the canonical T.O.O.N. compatibility store.
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
        /// Loads from the canonical T.O.O.N. root, falling back to the former InkTime root.
        /// </summary>
        public Texture2D LoadPanel(string relativePath)
        {
            string absolutePath = ResolveExistingPath(relativePath);
            if (string.IsNullOrEmpty(absolutePath)) return null;

            byte[] bytes = File.ReadAllBytes(absolutePath);
            var texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            return texture;
        }

        public bool PanelExists(string relativePath)
        {
            return !string.IsNullOrEmpty(ResolveExistingPath(relativePath));
        }

        public void DeleteProject(string projectId)
        {
            string dir = Path.Combine(ComicsRoot, projectId);
            if (Directory.Exists(dir))
                Directory.Delete(dir, recursive: true);

            string legacyDir = Path.Combine(LegacyComicsRoot, projectId);
            if (Directory.Exists(legacyDir))
                Directory.Delete(legacyDir, recursive: true);
        }

        private string ResolveExistingPath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return string.Empty;

            string current = Path.Combine(ComicsRoot, relativePath);
            if (File.Exists(current)) return current;

            string legacy = Path.Combine(LegacyComicsRoot, relativePath);
            return File.Exists(legacy) ? legacy : string.Empty;
        }
    }
}
