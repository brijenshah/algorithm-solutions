using System;

namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTimeOffset.UtcNow;
            UpdatedOn = DateTimeOffset.UtcNow;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public bool Complete { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool Deleted { get; set; }
    }
}