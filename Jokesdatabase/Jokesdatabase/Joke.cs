using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jokesdatabase
{
    public class Joke
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Content { get; set; }
        
    }
}
