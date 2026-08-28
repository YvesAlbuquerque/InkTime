using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using InkThroughTime.Domain;

namespace InkThroughTime.Infrastructure.Persistence
{
    /// <summary>
    /// Serializes and deserializes GameSession to/from JSON.
    /// Save file is stored at Application.persistentDataPath/InkTime/save.json.
    /// </summary>
    public class InkSaveService
    {
        private const string SaveDirectory = "InkTime";
        private const string SaveFileName = "save.json";
        private const int CurrentSaveVersion = 1;

        private string SavePath =>
            Path.Combine(Application.persistentDataPath, SaveDirectory, SaveFileName);

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.None,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include
        };

        /// <summary>
        /// Serializes and saves the current GameSession to disk.
        /// </summary>
        public void Save(GameSession session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));

            try
            {
                string dir = Path.GetDirectoryName(SavePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string json = JsonConvert.SerializeObject(session, _settings);
                File.WriteAllText(SavePath, json);
                Debug.Log($"[InkSaveService] Saved to {SavePath}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[InkSaveService] Save failed: {ex.Message}");
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
            target.Employees = source.Employees;
            target.Projects = source.Projects;
            target.PublishedComics = source.PublishedComics;
            target.IpCatalogue = source.IpCatalogue;
        }
    }
}
