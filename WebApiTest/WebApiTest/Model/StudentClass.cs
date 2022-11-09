using System;

namespace WebApiTest.Model
{
    public class StudentClass 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StudentClassId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}
