namespace Ticket.Web.Models.Views
{
    public class EventListModel
    {
        public IEnumerable<EventService.Event> Events { get; set; }
        public int SelectedCategory { get; set; }
        public IEnumerable<EventService.Category> Categories { get; set; }
        public int NumberOfItems { get; set; }
    }
}
