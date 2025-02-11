using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public void Execute(RequestRegisterTripJson request)
        {
            Validate(request);

            var dbContext = new JourneyDbContext();

            var entity = new Trip
            {
                Name = request.Name,
                EndDate = request.EndDate,
                StartDate = request.StartDate,
            };

            dbContext.Trips.Add(entity);
            dbContext.SaveChanges();
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new JourneyException("Nome não pode ser vazio");

            if (request.StartDate.Date < DateTime.UtcNow.Date)
                throw new JourneyException("Data de começo não pode estar no passado!");

            if (request.EndDate.Date >= DateTime.UtcNow.Date)
                throw new JourneyException("A viagem deve terminar após a data de inicio");
        }
    }
}
