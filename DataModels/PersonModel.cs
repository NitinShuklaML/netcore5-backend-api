using System;
using System.ComponentModel.DataAnnotations;

namespace KeyPathAPI.DataModels
{
    public class PersonModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }        
        public int Age { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ModifiedOnUtc { get; set; }
    }
}
