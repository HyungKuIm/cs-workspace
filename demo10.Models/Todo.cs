using System.Collections.Generic;
using System.Xml.Serialization;

namespace demo10.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

    [XmlRoot(ElementName ="todos")]
    public class ListTodo
    {
        [XmlElement(ElementName ="todo")]
        public List<Todo> Todos { get; set; }
    }
}