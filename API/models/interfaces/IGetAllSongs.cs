using System.Collections.Generic;

namespace API.models.interfaces
{
    public interface IGetAllSongs
    {
        List<Song> GetAllSongs();
    }
}