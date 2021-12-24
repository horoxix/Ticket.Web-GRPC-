using AutoMapper;
using EventService.Interfaces;
using Grpc.AspNetCore.Server;
using Grpc.Core;

namespace EventService
{
    public class EventGrpcService : Events.EventsBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public EventGrpcService(IEventRepository eventRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public override async Task<GetAllEventsResponse> GetAll(GetAllEventsRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsResponse();
            var eventEntities = await _eventRepository.GetEvents(0);
            response.Events.Add(_mapper.Map<List<Event>>(eventEntities));
            return response;
        }

        public override async Task<GetAllEventsByCategoryIdResponse> GetAllByCategoryId(GetAllEventsByCategoryIdRequest request, ServerCallContext context)
        {
            var response = new GetAllEventsByCategoryIdResponse();
            var eventEntities = await _eventRepository.GetEvents(request.CategoryId);
            response.Events.Add(_mapper.Map<List<Event>>(eventEntities));
            return response;
        }

        public override async Task<GetByEventIdResponse> GetByEventId(GetByEventIdRequest request, ServerCallContext context)
        {
            var response = new GetByEventIdResponse();
            var eventEntity = await _eventRepository.GetEventById(request.EventId);
            response.Event = _mapper.Map<Event>(eventEntity);
            return response;
        }

        public override async Task<GetAllCategoriesResponse> GetAllCategories(GetAllCategoriesRequest request, ServerCallContext context)
        {
            var response = new GetAllCategoriesResponse();
            var categoryEntities = await _categoryRepository.GetAllCategories();
            response.Categories.Add(_mapper.Map<List<Category>>(categoryEntities));
            return response;
        }
    }
}
