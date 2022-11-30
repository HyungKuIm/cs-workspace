using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace demo10.Models
{
    public class TodoRepositoryXml : ITodoRepository
    {
        private readonly string _filePath;
        private static List<Todo> _todos = new List<Todo>();


        public TodoRepositoryXml(string filePath = @"C:/temp/Todos.xml")
        {
            this._filePath = filePath;
        }

        public void Add(Todo todo)
        {
           
            if (_todos.Any())
            {
                todo.Id = _todos.Max(t => t.Id) + 1;
            } 
            else
            {
                todo.Id = 1;
            }
            _todos.Add(todo);

            XmlDocument xml = new XmlDocument();
            xml.Load(this._filePath);
            XmlNode rootNode = xml.DocumentElement;

            XmlNode todoNode = xml.CreateElement("todo");
            XmlAttribute idAttr = xml.CreateAttribute("id");
            XmlAttribute isDoneAttr = xml.CreateAttribute("isDone");
            idAttr.Value = todo.Id.ToString();
            isDoneAttr.Value = todo.IsDone.ToString();
            todoNode.Attributes.Append(idAttr);
            todoNode.Attributes.Append(isDoneAttr);
            todoNode.InnerText = todo.Title;
            
            rootNode.AppendChild(todoNode);

            xml.Save(this._filePath);
        }

        public List<Todo> GetAll()
        {
            _todos.Clear();

            XmlDocument xml = new XmlDocument();
            xml.Load(this._filePath);
            string xpath = "//todos/todo";
            XmlNodeList nodes = xml.SelectNodes(xpath);
            foreach (XmlNode node in nodes)
            {
                Todo todo = new Todo();

                todo.Id = int.Parse(node.Attributes["id"].Value);
                todo.Title = node.InnerText;
                todo.IsDone = bool.Parse(node.Attributes["isDone"].Value);
                _todos.Add(todo);
            }
            return _todos;
        }
    }
}
