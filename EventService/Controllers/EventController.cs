using AutoMapper;
using EventService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.EventDto>>> Get([FromQuery] int categoryId)
        {
            var result = await _eventRepository.GetEvents(categoryId);
            return Ok(_mapper.Map<List<Models.EventDto>>(result));
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<Models.EventDto>> GetById(int eventId)
        {
            var result = await _eventRepository.GetEventById(eventId);
            return Ok(_mapper.Map<Models.EventDto>(result));
        }
    }
}
