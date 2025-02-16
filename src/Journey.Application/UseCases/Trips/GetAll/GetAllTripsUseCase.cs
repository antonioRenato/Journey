using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.GetAll
{
    public class GetAllTripsUseCase
    {
        public ResponseTripsJson Execute()
        {
            var dbContext = new JourneyDbContext();

            var trips = dbContext.Trips.ToList();

            return new ResponseTripsJson
            {
                Trips = trips.Select(trip => new ResponseShortTripJson
                {
                    Id = trip.Id,
                    StartDate = trip.StartDate,
                    EndDate = trip.EndDate,
                    Name = trip.Name
                }).ToList()
            };
        }
    }
}
