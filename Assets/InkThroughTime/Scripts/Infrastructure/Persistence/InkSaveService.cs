using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using InkThroughTime.Domain;

namespace InkThroughTime.Infrastructure.Persistence
{
    /// <summary>
    /// Serializes and deserializes GameSession to/from JSON.
    /// New saves default to Application.persistentDataPath/TOON/save.json.
    /// The former InkTime location is retained as a read/delete compatibility fallback.
    /// An explicit path may be supplied for deterministic validation.
    /// </summary>
    public class InkSaveService
    {
        private const string SaveDirectory = "TOON";
        private const string LegacySaveDirectory = "InkTime";
        private const string SaveFileName = "save.json";
        private const int CurrentSaveVersion = 1;

        private readonly string _savePathOverride;

        public InkSaveService(string savePathOverride = null)
        {
            _savePathOverride = savePathOverride;
        }

        private string SavePath =>
            !string.IsNullOrWhiteSpace(_savePathOverride)
                ? _savePathOverride
                : Path.Combine(Application.persistentDataPath, SaveDirectory, SaveFileName);

        private string LegacySavePath =>
            !string.IsNullOrWhiteSpace(_savePathOverride)
                ? _savePathOverride
                : Path.Combine(Application.persistentDataPath, LegacySaveDirectory, SaveFileName);

        /// <summary>
        /// Exposes the current canonical save path for diagnostics and deterministic validation.
        /// </summary>
        public string ResolvedSavePath => SavePath;

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include
        };

        /// <summary>
        /// Serializes and saves the current GameSession to the canonical T.O.O.N. path.
        /// Returns false when writing fails.
        /// </summary>
        public bool Save(GameSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));

            try
            {
                string dir = Path.GetDirectoryName(SavePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string json = JsonConvert.SerializeObject(session, _settings);
                File.WriteAllText(SavePath, json);
                Debug.Log($"[InkSaveService] Saved T.O.O.N. state to {SavePath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[InkSaveService] Save failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Attempts to load a saved GameSession.
        /// The canonical T.O.O.N. path wins; when it does not exist, the former InkTime
        /// path is tried so existing local saves are not silently abandoned by the rename.
        /// </summary>
        public bool TryLoad(GameSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));

            string loadPath = ResolveLoadPath();
            if (string.IsNullOrEmpty(loadPath)) return false;

            try
            {
                string json = File.ReadAllText(loadPath);
                var loaded = JsonConvert.DeserializeObject<GameSession>(json, _settings);

                if (loaded == null || loaded.SaveVersion > CurrentSaveVersion)
                {
                    Debug.LogWarning("[InkSaveService] Save file is incompatible; starting fresh.");
                    return false;
                }

                CopyInto(loaded, session);
                Debug.Log($"[InkSaveService] Loaded T.O.O.N. state from {loadPath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[InkSaveService] Load failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes the canonical save and, when using default paths, the legacy InkTime save.
        /// </summary>
        public void DeleteSave()
        {
            if (File.Exists(SavePath))
                File.Delete(SavePath);

            if (string.IsNullOrWhiteSpace(_savePathOverride) &&
                !string.Equals(LegacySavePath, SavePath, StringComparison.OrdinalIgnoreCase) &&
                File.Exists(LegacySavePath))
            {
                File.Delete(LegacySavePath);
            }
        }

        private string ResolveLoadPath()
        {
            if (File.Exists(SavePath))
                return SavePath;

            if (string.IsNullOrWhiteSpace(_savePathOverride) && File.Exists(LegacySavePath))
                return LegacySavePath;

            return null;
        }

        private static void CopyInto(GameSession source, GameSession target)
        {
            target.SaveVersion = source.SaveVersion;
            target.Calendar = source.Calendar;
            target.Studio = source.Studio;
            target.Employees = source.Employees ?? new List<EmployeeState>();
            target.Projects = source.Projects ?? new List<ProjectState>();
            target.PublishedComics = source.PublishedComics ?? new List<PublishedComic>();
            target.IpCatalogue = source.IpCatalogue ?? new List<IpState>();
            target.LegacyIpProgression =
                source.LegacyIpProgression ?? new List<LegacyIpProgressionState>();
        }
    }
}
