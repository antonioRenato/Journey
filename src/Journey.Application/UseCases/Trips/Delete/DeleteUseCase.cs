using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete
{
    public class DeleteUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new JourneyDbContext();

            var trip = dbContext.Trips.Include(x => x.Activities).FirstOrDefault(trip => trip.Id == id);

            if (trip == null) 
            {
                throw new NotFoundException("ID não encontrado para ser deletado");
            }

            dbContext.Remove(trip);
            dbContext.SaveChanges();
        }
    }
}
