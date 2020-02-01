using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using imrg_web.Models;

namespace imrg_web.BLL.Calendar
{
    public class JsonEventModel
    {
        public string id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string title { get; set; }

        public string url { get; set; }

        public static JsonEventModel Create(Event @event)
        {
            var model = new JsonEventModel();
            model.id = @event.EventId.ToString();
            model.start = @event.StartDateTime.ToString("o");
            model.end = @event.EndDateTime.ToString("o");
            model.title = @event.EventName;
            model.url = $"/events/details?id={model.id}";

            return model;
        }


        public static List<JsonEventModel> CreateList(List<Event> @events)
        {
            var models = new List<JsonEventModel>();
            foreach(var @event in @events)
            {
                models.Add(Create(@event));
            }
            return models;
        }
    }
}