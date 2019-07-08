using System;
using System.Collections.Generic;
using System.Text;

namespace nanoORMTest.Composers
{
    class DefaultEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public DefaultEntity(string Name, DateTime Date, int Id)
        {
            this.Name = Name;
            this.Date = Date;
            this.Id = Id;
        }

        public DefaultEntity() { }
    }
}
