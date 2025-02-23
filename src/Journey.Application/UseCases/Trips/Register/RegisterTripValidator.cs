using FluentValidation;
using Journey.Communication.Requests;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripValidator : AbstractValidator<RequestRegisterTripJson>
    {
        public RegisterTripValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Nome não pode ser vazio");

            RuleFor(request => request.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .WithMessage("Data de começo não pode estar no passado!");

            RuleFor(request => request.EndDate)
                .LessThanOrEqualTo(DateTime.UtcNow.Date)
                .WithMessage("A viagem não pode terminar antes da data atual");

            RuleFor(request => request)
                .Must(request => request.EndDate.Date >= request.StartDate.Date)
                .WithMessage("A viagem deve terminar após a data de inicio");
        }
    }
}
