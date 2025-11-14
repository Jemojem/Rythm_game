using UnityEngine;

public class NoteFactory
{
    NotePrefabBinding bindings;
    Transform parent;

    public NoteFactory(NotePrefabBinding bindings, Transform parent)
    {
        this.bindings = bindings;
        this.parent = parent;
    }

    public Note Create(Type noteType, Note.Keys key)
    {
        foreach(var binding in bindings.info)
        {
            if(binding.noteType == noteType)
            {
                var note = GameObject.Instantiate(binding.prefab, parent);
                note.Key = key;
                return note;
            }
        }

        Debug.LogError("No prefab for type " + noteType.ToString());
        return null;
    }

    public Note Create(SongInfo.NoteInfo noteInfo)
    {
        return Create(noteInfo.type, noteInfo.direction);
    }

    public enum Type
    {
        Basic,
        Long
    }
}
