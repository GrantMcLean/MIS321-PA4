using API.models.interfaces;
using MySql.Data.MySqlClient;

namespace API.models
{
    public class SongDatabaseHandler : IGetAllSongs, IGetSong, IAddSong, IDeleteSong, IEditSong
    {
        public void AddSong(string songTitle)
        {

            Song newSong = new Song() {SongTitle = songTitle, SongTimestamp = DateTime.Now, Deleted = "n", Favorited = "n"};

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @$"INSERT INTO songs (title, timestampnow, deleted, favorited) VALUES (@Title, @TimeStamp, @Deleted, @Favorited)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@Title", newSong.SongTitle);
            cmd.Parameters.AddWithValue("@TimeStamp", newSong.SongTimestamp);
            cmd.Parameters.AddWithValue("@Deleted", newSong.Deleted);
            cmd.Parameters.AddWithValue("@Favorited", newSong.Favorited);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        public void DeleteSong(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE songs SET deleted = 'y' WHERE id=@ID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Prepare();

            MySqlDataReader rdr = cmd.ExecuteReader();
        }

        public void EditSong(int id)
        {
             ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE songs SET favorited = 'y' WHERE id=@ID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Prepare();

            MySqlDataReader rdr = cmd.ExecuteReader();
        }

        public List<Song> GetAllSongs()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT id, title, timestampnow, deleted, favorited FROM songs";

            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Song> mySongs = new List<Song>(){};

            while (rdr.Read())
            {
                if(rdr.GetString(3)!="y")
                {
                mySongs.Add(new Song() {SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorited = rdr.GetString(4) });
                }
            }
            return mySongs;
        }

        public Song GetSong(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT id, title, timestampnow, deleted, favorited FROM songs WHERE id = @ID";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Prepare();

            MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Song() {SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorited = rdr.GetString(4)};

        }
    }
}