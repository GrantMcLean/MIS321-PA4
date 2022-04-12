namespace API.models
{
    public class ConnectionString
    {
        public string cs { get; set; }

        public ConnectionString()
        {
            string server = "w3epjhex7h2ccjxx.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "j66uf75skum9j7rz";
            string port = "3306";
            string userName = "nqn5nl2m6x2onhsz";
            string password = "qezj2hfuvc7o2e4a";

            cs = $@"server={server};user={userName};database={database};port={port};password={password};Convert Zero Datetime=True";
        }
    }
}