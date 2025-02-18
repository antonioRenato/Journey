﻿using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public ResponseShortTripJson Execute(RequestRegisterTripJson request)
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

            return new ResponseShortTripJson
            {
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Name = entity.Name,
                Id = entity.Id
            };
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ErrorOnValidationException("Nome não pode ser vazio");

            if (request.StartDate.Date < DateTime.UtcNow.Date)
                throw new ErrorOnValidationException("Data de começo não pode estar no passado!");

            if (request.EndDate.Date >= DateTime.UtcNow.Date)
                throw new ErrorOnValidationException("A viagem deve terminar após a data de inicio");
        }
    }
}
