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
    /// Defaults to Application.persistentDataPath/InkTime/save.json and supports
    /// an explicit path for deterministic validation.
    /// </summary>
    public class InkSaveService
    {
        private const string SaveDirectory = "InkTime";
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

        /// <summary>
        /// Exposes the resolved path for diagnostics and deterministic validation.
        /// </summary>
        public string ResolvedSavePath => SavePath;

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include
        };

        /// <summary>
        /// Serializes and saves the current GameSession to disk.
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
                Debug.Log($"[InkSaveService] Saved to {SavePath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[InkSaveService] Save failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Attempts to load a saved GameSession from disk into the provided instance.
        /// Returns true if a valid save was found and loaded.
        /// </summary>
        public bool TryLoad(GameSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (!File.Exists(SavePath)) return false;

            try
            {
                string json = File.ReadAllText(SavePath);
                var loaded = JsonConvert.DeserializeObject<GameSession>(json, _settings);

                if (loaded == null || loaded.SaveVersion > CurrentSaveVersion)
                {
                    Debug.LogWarning("[InkSaveService] Save file is incompatible; starting fresh.");
                    return false;
                }

                CopyInto(loaded, session);
                Debug.Log($"[InkSaveService] Loaded from {SavePath}");
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"[InkSaveService] Load failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes the save file.
        /// </summary>
        public void DeleteSave()
        {
            if (File.Exists(SavePath))
                File.Delete(SavePath);
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
