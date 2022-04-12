using MySql.Data.MySqlClient;

namespace API.models.interfaces
{
    public interface IAddSong
    {
        void AddSong(string songTitle);
    }
}