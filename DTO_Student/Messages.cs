using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Student
{
    public class Messages
    {
        private string id, date, title, description;



        public Messages(string id, string date, string title, string description)
        {
            this.id = id;
            this.date = date;
            this.title = title;
            this.description = description;
        }

        public Messages()
        {
        }

        public string Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

    }
}
