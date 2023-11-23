using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static int _eventId=0;
        private static List<Event> events= new List<Event> ();
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }


        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            Console.WriteLine("enter post");
            events.Add(new Event { Id = _eventId++, Title = newEvent.Title,Start=newEvent.Start,End=newEvent.End });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put( int id,[FromBody] Event newEvent)
        {
            Console.WriteLine("enter");
            Event tmp;
            tmp = events.Find((x) => {
                if (x.Id == id)
                {
                    x.Title = newEvent.Title;
                    x.Start = newEvent.Start;
                    x.End = newEvent.End;
                }
            return true;    
            });
           
            //todo
            //find event by id
            //update event properties
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event tmp;
            tmp = events.Find((x) =>   (x.Id == id)    );
              
            
            events.Remove(tmp); 
            //todo
            //find event by id
            //delete event from list
        }
    }
}
