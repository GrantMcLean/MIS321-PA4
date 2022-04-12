using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.models.interfaces;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class songsController : ControllerBase
    {
        // GET: api/songs
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IGetAllSongs readObject = new ReadSongData();
            return readObject.GetAllSongs();
        }

        // GET: api/songs/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            IGetSong readObject = new ReadSongData();
            return readObject.GetSong(id);
        }

        // POST: api/songs
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            IAddSong writeObject = new ReadSongData();
            writeObject.AddSong(value.SongTitle);
        }

        // PUT: api/songs/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id)
        {
            IEditSong editObject = new ReadSongData();
            editObject.EditSong(id);
        }

        // DELETE: api/songs/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            System.Console.WriteLine(id);
            IDeleteSong deleteObject = new ReadSongData();
            deleteObject.DeleteSong(id);
        }
    }
}
