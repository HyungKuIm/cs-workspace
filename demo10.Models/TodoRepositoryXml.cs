using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        public Task Add(Todo todo)
        {
            return Task.Run(async () =>
            {


                if (_todos.Any())
                {
                    todo.Id = _todos.Max(t => t.Id) + 1;
                }
                else
                {
                    todo.Id = 1;
                }
                _todos.Add(todo); //불필요 ?

                //XElement xml = XElement.Load(this._filePath);
                //XElement ele_todo = new XElement("todo", new XAttribute("id", todo.Id),
                //                            new XAttribute("isDone", todo.IsDone), todo.Title);
                //xml.Add(ele_todo);
                //xml.Save(this._filePath);

                //Serialize
                await TodoUtilities.XmlSerializeToFileAsync<ListTodo>(_filePath, new ListTodo { Todos = _todos });
            });
        }

        public List<Todo> GetAll()
        {
            _todos.Clear();

            //XElement xml = XElement.Load(this._filePath);
            //IEnumerable<XElement> todos = from item in xml.Elements("todo")
            //                                select item;
            //foreach (XElement item in todos)
            //{
            //    Todo todo = new Todo();
            //    todo.Id = int.Parse(item.Attribute("id").Value);
            //    todo.Title = item.Value;
            //    todo.IsDone = bool.Parse(item.Attribute("isDone").Value);
            //    _todos.Add(todo);
            //}
            //


            //return _todos;

            List<Todo> todoList = TodoUtilities.XmlDeserializedFromFile<ListTodo>(_filePath).Todos;
            _todos.AddRange(todoList);
            return _todos;
        }
    }
}
